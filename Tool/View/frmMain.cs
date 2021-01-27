using MinervasoftSyncApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinervasoftSyncApp.View
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();


            //DSResource ds = new DSResource();

            //for (int i = 0; i < 20; i++)
            //{
            //    ds.Product.Rows.Add(i.ToString(), "", "", "", "", "");
            //}
            //ds.WriteXml(@"E:\01_Solution\2021\01_미네르바_배포\Source\MinervasoftSyncSolution\Resource\resource.xml");
        }

        public readonly string PRODUCT_RESOURCE = @"E:\01_Solution\2021\01_미네르바_배포\Source\MinervasoftSyncSolution\Resource\resource.xml";


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
    }
}