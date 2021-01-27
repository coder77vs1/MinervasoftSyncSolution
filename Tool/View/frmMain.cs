using MinervasoftSyncApp.Common;
using MinervasoftSyncApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinervasoftSyncApp.View
{
    public partial class frmMain : BaseForm
    {
        public frmMain()
        {
            InitializeComponent();
            //환경설정 초기화
            InitializeConfig();
        }

        /// <summary>
        /// 실행경로
        /// </summary>
        public string PRODUCT_RESOURCE { get; set; }

        /// <summary>
        /// 리소스파일 명
        /// </summary>
        public string PRODUCT_RESOURCE_FILE { get; set; }

        /// <summary>
        /// 소스
        /// </summary>
        private List<SourceItem> sourceData { get; set; }

        /// <summary>
        /// 배포자료
        /// </summary>
        private List<PublishFileItem> publishData { get; set; }

        /// <summary>
        /// 등록 가능한 확장자
        /// </summary>
        private List<string> extensionAry { get; set; }

        /// <summary>
        /// 활성화 프로그램
        /// </summary>
        private DSResource.ApplicationRow activeApplicationRow { get; set; }

        #region Initialize
        /// <summary>
        /// 환경설정 초기화 함수
        /// </summary>
        public void InitializeConfig()
        {
            PRODUCT_RESOURCE = System.Windows.Forms.Application.StartupPath;
            PRODUCT_RESOURCE_FILE = string.Empty;

            sourceData = new List<SourceItem>();
            publishData = new List<PublishFileItem>();
            extensionAry = new List<string>();
        }
        #endregion

        #region Events

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct
            {
                ResourcePath = PRODUCT_RESOURCE,
                StartPosition = FormStartPosition.CenterScreen
            };

            frm.ShowDialog(this);
        }

        private void btnApplication_Click(object sender, EventArgs e)
        {
            frmApplication frm = new frmApplication
            {
                ResourcePath = PRODUCT_RESOURCE,
                StartPosition = FormStartPosition.CenterScreen
            };

            frm.ShowDialog(this);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmSetting frm = new frmSetting
            {
                ResourcePath = PRODUCT_RESOURCE,
                StartPosition = FormStartPosition.CenterScreen
            };

            frm.ShowDialog(this);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            ClearControls();

            PRODUCT_RESOURCE_FILE = OpenFilePathByXml(this.ResourcePath);

            if (File.Exists(PRODUCT_RESOURCE_FILE))
            {
                try
                {
                    this.dsResource1.Clear();
                    this.extensionAry = new List<string>();

                    this.dsResource1.ReadXml(PRODUCT_RESOURCE_FILE);

                    if (this.dsResource1.Config.Rows.Count > 0)
                    {
                        var obj = this.dsResource1.Config[0].CertificationExe;
                        var ary = obj.Split(';');

                        foreach (var item in ary)
                        {
                            if (string.IsNullOrEmpty(item.Trim()) == false)
                            {
                                this.extensionAry.Add(item.Trim());
                            }
                        }
                    }

                    if (this.extensionAry.Count == 0)
                    {
                        MessageBox.Show("등록 가능한 확장자 정보가 없습니다.");
                        return;
                    }

                    if (this.dsResource1.Application.Rows.Count == 0)
                    {
                        MessageBox.Show("등록 가능한 프로그램 정보가 없습니다.");
                        return;
                    }

                    //프로그램 가져오기
                    GetResourceData();
                }
                catch
                {
                    MessageBox.Show("ERROR!");
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            ClearControls();

            activeApplicationRow = ((listBox1.SelectedItem as System.Data.DataRowView).Row as DSResource.ApplicationRow);

            txtApplicationId.Tag = activeApplicationRow;
            txtApplicationId.Text = activeApplicationRow.ApplicationId;
            txtApplicationName.Text = activeApplicationRow.ApplicationName;
            txtApplicationKey.Text = activeApplicationRow.ApplicationKey;
            txtApplicationType.Text = activeApplicationRow.ApplicationType;
            txtServerUrl.Text = activeApplicationRow.ServerUrl;
            txtClientPath.Text = activeApplicationRow.ServerUrl;
            txtReleasePath.Text = activeApplicationRow.ReleasePath;

            //소스리스트
            SetSourceItem(activeApplicationRow.ApplicationId);
        }

        #endregion

        #region Mothed

        /// <summary>
        /// 컨트롤 초기화
        /// </summary>
        protected override void ClearControls()
        {
            this.txtApplicationId.Tag = string.Empty;
            this.txtApplicationId.Text = string.Empty;
            this.txtApplicationName.Text = string.Empty;
            this.txtApplicationKey.Text = string.Empty;
            this.txtApplicationType.Text = string.Empty;
            this.txtServerUrl.Text = string.Empty;
            this.txtClientPath.Text = string.Empty;
            this.txtReleasePath.Text = string.Empty;
        }

        /// <summary>
        /// 프로그램 가져오기
        /// </summary>
        private void GetResourceData()
        {
            try
            {
                sourceData = new List<SourceItem>();
                publishData = new List<PublishFileItem>();

                this.dataGridView1.DataSource = null;

                foreach (var row in this.dsResource1.Application)
                {
                    GetResourceItems(row);
                }

                //소스리스트
                SetSourceItem(this.dsResource1.Application[0].ApplicationId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetResourceItems(DSResource.ApplicationRow row)
        {
            addSourceItem(row.ApplicationId, row.ReleasePath);

            string[] dirs = Directory.GetDirectories(row.ReleasePath);

            foreach (string dir in dirs)
            {
                string[] dirsEx = Directory.GetDirectories(dir);

                addSourceItem(row.ApplicationId, dir);

                foreach (string dir2 in dirsEx)
                {
                    addSourceItem(row.ApplicationId, dir2);
                }
            }
        }

        /// <summary>
        /// 소스리스트
        /// </summary>
        /// <param name="applicationId"></param>
        private void SetSourceItem(string applicationId)
        {
            //this.dataGridView1.DataSource = sourceData;
            var data = sourceData.FindAll(x => x.ApplicationId.Equals(applicationId));
            this.dataGridView1.DataSource = data;

            //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

            this.dataGridView1.Columns["ApplicationId"].Visible = false;
            this.dataGridView1.Columns["FileName"].ReadOnly = true;
            this.dataGridView1.Columns["FileName"].Width = 200;
            this.dataGridView1.Columns["FileName"].ReadOnly = true;
            this.dataGridView1.Columns["CurrentPath"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns["Use"].Width = 50;
            this.dataGridView1.Columns["SpecialFileType"].Visible = false;
        }

        /// <summary>
        /// 확장자 체크
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool checkExtension(string path)
        {
            bool result = false;

            string ext = Path.GetExtension(path);

            if (string.IsNullOrEmpty(ext))
            {
                result = true;
            }
            else
            {
                var ary = this.extensionAry.FindAll(x => x.ToLower().Equals(ext, StringComparison.CurrentCultureIgnoreCase));
                result = (ary.Count > 0);
            }

            return result;
        }

        /// <summary>
        /// 객체에 파일 추가
        /// </summary>
        /// <param name="dir"></param>
        private void addSourceItem(string applicationId, string dir)
        {
            //제외 대상 폴더 명
            if (dir.IndexOf(".") == 0 || dir.IndexOf("svn") > 0) return;

            var files = Directory.GetFiles(dir);

            foreach (var item in files)
            {
                if (checkExtension(item))
                {
                    sourceData.Add(new SourceItem
                    {
                        ApplicationId = applicationId,
                        FileName = Path.GetFileName(item),
                        CurrentPath = item
                    });
                }
            }
        }
        #endregion
    }
}