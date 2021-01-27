using ScanLauncher.Config;
using ScanLauncher.Core;
using ScanLauncher.Data;
using ScanLauncher.Event;
using ScanLauncher.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ScanLauncher.Service
{
    /// <summary>
    /// 최신버전 동기화 서비스
    /// </summary>
    public class AutoSyncService : IDisposable
    {
        public List<PublishFileItem> SpecialFiles { get; private set; }
        public SyncResourceData SyncResourceData { get; private set; }
        public string TempDirectory { get; private set; }
        public PublishProcessStatus SyncStatus { get; private set; }
        public bool IsDownloadAll { get; private set; }        
        public static readonly int Maximum = 9;
        public event SyncStateEventHandler SyncStateChanged;
        public event SyncStateEventHandler SyncProcessEnd;
        private string stateMessage = string.Empty;

        public AutoSyncService()            
        {
            InitializeResource();
        }

        private void InitializeResource()
        {
            SyncResourceData = new SyncResourceData
            {
                ClientConfig = new PublishData
                {
                    Files = new List<PublishFileItem>()
                },

                ServerConfig = new PublishData
                {
                    Files = new List<PublishFileItem>()
                }
            };

            SpecialFiles = new List<PublishFileItem>();
        }

        private void OnStatusUpdate(string stepName, PublishProcessStatus status, string message = "")
        {
            
            SyncStatus = status;
            SetStateMessage(message);
            stepName = GetProcessStateDisplayMessage(stepName);

            string stepTitle = string.Empty;

            switch (stepName)
            {
                default:
                    break;
            }

            SyncStateChanged?.Invoke(this, new SyncStateEventArgs { 
                StepName = stepName,
                Status = status,
                Message = message
            });
        }

        private void OnProcessEnd(string stepName, PublishProcessStatus status, string message = "")
        {
            SyncStatus = status;

            SyncProcessEnd?.Invoke(this, new SyncStateEventArgs
            {
                StepName = stepName,
                Status = status,
                Message = string.IsNullOrEmpty(message) ? stateMessage : message
            });
        }

        public bool CheckClientResource()
        {
            try
            {
                GetClientData();
                CheckClientData();

                return (IsDownloadAll) ? false : true;
            }
            catch
            {
                return false;
            }
        }

        public bool ClearClientPublishPath()
        {
            try
            {   
                return FileHelper.DirectoryDelete(ApplicationConfig.ClientPublishDirectory);
            }
            catch
            {
                return false;
            }
        }

        public bool ClearClientConfig()
        {
            try
            {
                FileHelper.FileDelete(ApplicationConfig.ClientPublishPath);
                FileHelper.FileDelete(ApplicationConfig.ClientProcessPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Start(SyncResourceData syncResourceData, string tempDirectory)
        {
            bool result = false;
            SyncResourceData = syncResourceData;
            TempDirectory = tempDirectory;
            SpecialFiles = new List<PublishFileItem>();
            IsDownloadAll = false;

            try
            {
                //프로세서 종료
                ProcessHelper.ProcessKill(ApplicationConfig.SolutionTitle);

                if (GetClientData() && CheckClientData())
                {
                    //서버파일 다운로드
                    if (GetServerData())
                    {
                        //업데이트 대상 체크
                        if (CheckVersion())
                        {
                            if (SyncServerFileDownload() && SyncServerFileMove())
                            {
                                //배포파일 업데이트
                                if (SyncPublishRelease())
                                {
                                    //파일동기화 확인
                                    result = CheckSyncFileExists();
                                    //관리파일 생성 (.config) /체크필요 없음.
                                    //SyncSpecialContext();
                                }
                            }
                        }
                        else
                        {
                            //업데이트 대상이 없음, 정상
                            result = true;
                        }
                    }
                }

                if(result)
                    OnProcessEnd("ScanLauncher.Service", PublishProcessStatus.Complete, "Successful");
                else
                    OnProcessEnd("ScanLauncher.Service", PublishProcessStatus.Fail);
            }
            catch (Exception ex)
            {
                OnProcessEnd("ScanLauncher.Service", PublishProcessStatus.Fail, ex.Message);
            }
        }

        /// <summary>
        /// 로컬 Release 조회
        /// </summary>
        /// <returns></returns>
        private bool GetClientData()
        {
            try
            {                
                var resource = FileHelper.ReadFile(ApplicationConfig.ClientPublishPath);

                // 1.1 check : 파일이 존재 하지 않음 체크
                if (string.IsNullOrEmpty(resource))
                {
                    IsDownloadAll = true;
                    SyncResourceData.ClientConfig = new PublishData
                    {
                        PublishDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:sss"),
                        BuildVersion = DateTime.Now.Ticks,
                        Files = new List<PublishFileItem>()
                    };
                }
                else
                {
                    IsDownloadAll = false;
                    SyncResourceData.ClientConfig = JsonHelper.JsonDeserizlizer<PublishData>(resource);
                }
                
                OnStatusUpdate("GetClientData", PublishProcessStatus.Client_True);
            }
            catch (Exception ex)
            {
                OnStatusUpdate("GetClientData", PublishProcessStatus.Fail, ex.Message);
            }

            return GetSyncStatusBoolean();
        }

        private bool CheckVersion()
        {
            bool result = false;

            try
            {
                //전체다운로드 모드 이면 버전체크를 하지 않는다
                if (IsDownloadAll)
                {
                    result = true;
                }
                else
                {
                    //로컬 버전과 서버 버전을 비교 한다
                    if (SyncResourceData.ClientConfig.BuildVersion < SyncResourceData.ServerConfig.BuildVersion)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                OnStatusUpdate("CheckVersion", PublishProcessStatus.Fail, ex.Message);
            }

            return result;
        }

        //1.2 true : 파일이 존재 하면 리스트 내의 파일이 있는지 체크
        private bool CheckClientData()
        {
            try
            {
                for (int i = 0; i < SyncResourceData.ClientConfig.Files.Count; i++)
                {   
                    var rExistsFile = FileHelper.ExistsFile(SyncResourceData.ClientConfig.Files[i].ClientPath);
                    SyncResourceData.ClientConfig.Files[i].ExistsFile = rExistsFile;

                    //로컬에 파일이 없으면 전체 다운로드 모드로 전환 한다
                    if (rExistsFile == false)
                        IsDownloadAll = true;
                }

                OnStatusUpdate("CheckClientData", PublishProcessStatus.Client_True);
            }
            catch (Exception ex)
            {
                OnStatusUpdate("CheckClientData", PublishProcessStatus.Fail, ex.Message);
            }

            return GetSyncStatusBoolean();
        }

        /// <summary>
        /// 파일동기화 확인
        /// </summary>
        /// <returns></returns>
        private bool CheckSyncFileExists()
        {
            bool result = true;
            try
            {
                for (int i = 0; i < SyncResourceData.ServerConfig.Files.Count; i++)
                {
                    if (FileHelper.ExistsFile(SyncResourceData.ServerConfig.Files[i].ClientPath) == false)
                    {
                        result = false;
                        break;
                    }

                    if (string.IsNullOrEmpty(SyncResourceData.ClientConfig.Files[i].SpecialFileType) == false)
                    {
                        SpecialFiles.Add(SyncResourceData.ClientConfig.Files[i]);
                    }
                }

                //if(result)
                if(true)
                    OnStatusUpdate("CheckSyncFileExists", PublishProcessStatus.Exists_True);
                else
                    OnStatusUpdate("CheckSyncFileExists", PublishProcessStatus.Exists_False);
            }
            catch (Exception ex)
            {
                OnStatusUpdate("CheckClientData", PublishProcessStatus.Fail, ex.Message);
            }

            return GetSyncStatusBoolean();
        }

        private bool GetServerData()
        {
            try
            {
                // 개발자모드일경우 호출X
                if(ApplicationConfig.Mode == "D")
                {
                    stateMessage = "";
                    OnStatusUpdate("GetServerData", PublishProcessStatus.Service_True);
                }
                else
                {
                    var resource = WebClientHelper.WebClientReadFile(ApplicationConfig.ServerPublishFilePath);

                    if (string.IsNullOrEmpty(resource))
                    {
                        stateMessage = "";
                        OnStatusUpdate("GetServerData", PublishProcessStatus.Service_False);
                    }
                    else
                    {
                        SyncResourceData.ServerPublishRelease = resource;
                        SyncResourceData.ServerConfig = JsonHelper.JsonDeserizlizer<PublishData>(resource);
                        OnStatusUpdate("GetServerData", PublishProcessStatus.Service_True);
                    }
                }
            }
            catch (Exception ex)
            {
                OnStatusUpdate("GetServerData", PublishProcessStatus.Fail, ex.Message);
            }

            return GetSyncStatusBoolean();
        }

        private bool SyncServerFileDownload()
        {
            try
            {
                // 개발자모드일경우 호출X
                if (ApplicationConfig.Mode == "D")
                {
                    OnStatusUpdate("SyncServerFileDownload", PublishProcessStatus.Download_True);
                }
                else
                {
                    using (HttpRequestHelper client = new HttpRequestHelper())
                    {
                        string serverPath = ApplicationConfig.ServerPublishPath;
                        string path;
                        string downpath = string.Empty;

                        for (int i = 0; i < SyncResourceData.ServerConfig.Files.Count; i++)
                        {
                            path = ApplicationConfig.ServerPublishPath + SyncResourceData.ServerConfig.Files[i].ServerUrl;

                            if (IsDownloadAll)
                            {
                                downpath = client.DownloadFile(path, TempDirectory, SyncResourceData.ServerConfig.Files[i].FileName);
                            }
                            else
                            {
                                if (GetDownloadFlag(SyncResourceData.ServerConfig.Files[i].PublishState))
                                    downpath = client.DownloadFile(path, TempDirectory, SyncResourceData.ServerConfig.Files[i].FileName);
                                else
                                    downpath = string.Empty;
                            }

                            if (string.IsNullOrEmpty(downpath))
                            {
                                SyncResourceData.ServerConfig.Files[i].State = SyncFileStatus.Empty.ToString();
                            }
                            else
                            {
                                SyncResourceData.ServerConfig.Files[i].State = SyncFileStatus.Download.ToString();
                                SyncResourceData.ServerConfig.Files[i].DownloadPath = downpath;
                            }
                        }

                        OnStatusUpdate("SyncServerFileDownload", PublishProcessStatus.Download_True);
                    }
                }
                
            }
            catch (Exception ex)
            {
                OnStatusUpdate("SyncServerFileDownload", PublishProcessStatus.Fail, ex.Message);
            }

            return GetSyncStatusBoolean();
        }

        private bool SyncServerFileMove()
        {
            //foreach (PublishFileItem file in SyncResourceData.ServerConfig.Files.FindAll(x => x.State.Equals(PublishProcessState.Download_True.ToString())))
            //{
            //    var result = FileHelper.FileMove(file.DownloadPath, file.ClientPath);
            //}

            bool result = false;

            try
            {
                for (int i = 0; i < SyncResourceData.ServerConfig.Files.Count; i++)
                {
                    if (SyncResourceData.ServerConfig.Files[i].State.Equals(SyncFileStatus.Download.ToString()))
                    {
                        Thread.Sleep(1);

                        result = FileHelper.FileMove(SyncResourceData.ServerConfig.Files[i].DownloadPath, SyncResourceData.ServerConfig.Files[i].ClientPath);

                        if (result)
                            SyncResourceData.ServerConfig.Files[i].State = SyncFileStatus.Update.ToString();
                        else
                        {
                            SyncResourceData.ServerConfig.Files[i].State = SyncFileStatus.Fail.ToString();
                            break;
                        }
                    }
                }

                // 개발자모드일경우 호출X
                if (ApplicationConfig.Mode == "D")
                {
                    result = true;
                }

                if (result)
                    OnStatusUpdate("SyncServerFileMove", PublishProcessStatus.FileMove_True);
                else
                    OnStatusUpdate("SyncServerFileMove", PublishProcessStatus.FileMove_False);
            }
            catch (Exception ex)
            {
                OnStatusUpdate("SyncServerFileMove", PublishProcessStatus.Fail, ex.Message);
            }

            return GetSyncStatusBoolean();
        }

        private void SyncSpecialContext()
        {
            if (SpecialFiles != null && SpecialFiles.Count > 0)
            {
                try
                {
                    foreach (var item in SpecialFiles)
                    {
                        string context = SpecialContext.GetSpecialcContext(item.FileName);

                        if (string.IsNullOrEmpty(context) == false)
                        {
                            FileHelper.CreateFile(item.ClientPath, context);
                        }

                        Thread.Sleep(1);
                    }
                }
                finally
                { }
            }
        }

        private bool SyncPublishRelease()
        {
            try
            {
                var context = JsonHelper.JsonSerizlizer<PublishData>(SyncResourceData.ServerConfig);
                bool result = FileHelper.CreateResourceFile(ApplicationConfig.ClientPublishPath, context);

                if (result)
                    OnStatusUpdate("SyncPublishRelease", PublishProcessStatus.Release_True);
                else
                    OnStatusUpdate("SyncPublishRelease", PublishProcessStatus.Release_False);
            }
            catch (Exception ex)
            {
                OnStatusUpdate("SyncPublishRelease", PublishProcessStatus.Fail, ex.Message);
            }

            return GetSyncStatusBoolean();
        }

        private bool GetDownloadFlag(string value)
        {
            bool result1 = false;
            bool result2 = Boolean.TryParse(value, out result1);

            return (result1 && result2) ? true : false;
        }

        private bool GetSyncStatusBoolean()
        {
            bool result;

            switch (SyncStatus)
            {
                case PublishProcessStatus.Default:
                case PublishProcessStatus.Client_True:
                case PublishProcessStatus.Service_True:
                case PublishProcessStatus.Download_True:
                case PublishProcessStatus.FileMove_True:
                case PublishProcessStatus.Release_True:
                case PublishProcessStatus.Exists_True:
                case PublishProcessStatus.Complete:
                    result = true;
                    break;
                case PublishProcessStatus.Client_False:
                case PublishProcessStatus.Service_False:
                case PublishProcessStatus.Download_False:
                case PublishProcessStatus.FileMove_False:
                case PublishProcessStatus.Release_False:
                case PublishProcessStatus.Exists_False:
                case PublishProcessStatus.Fail:
                    result = false;
                    break;
                default:
                    result = false;
                    break;
            }

            return result;
        }

        private void SetStateMessage(string message)
        {
            switch (SyncStatus)
            {
                case PublishProcessStatus.Client_False:
                    stateMessage = string.IsNullOrEmpty(message) ? "Client File Error [1000-1]" : message;
                    break;
                case PublishProcessStatus.Service_False:
                    stateMessage = string.IsNullOrEmpty(message) ? "Service File Error [1000-2]" : message;
                    break;
                case PublishProcessStatus.Download_False:
                    stateMessage = string.IsNullOrEmpty(message) ? "Download File Error [1000-3]" : message;
                    break;
                case PublishProcessStatus.FileMove_False:
                    stateMessage = string.IsNullOrEmpty(message) ? "File Move Error [1000-4]" : message;
                    break;
                case PublishProcessStatus.Release_False:
                    stateMessage = string.IsNullOrEmpty(message) ? "Release File Create Error [1000-5]" : message;
                    break;
                case PublishProcessStatus.Exists_False:
                    stateMessage = string.IsNullOrEmpty(message) ? "Cleint File Exists Error [1000-6]" : message;
                    break;
                default:
                    break;
            }
        }

        private string GetProcessStateDisplayMessage(string step)
        {
            string message = string.Empty;

            switch (step)
            {
                case "GetClientData": 
                    message = "로컬 설정파일 확인"; break;
                case "CheckVersion":
                    message = "버전 체크"; break;
                case "CheckClientData":
                    message = "로컬 파일 체크"; break;
                case "GetServerData":
                    message = "서버 설정파일 확인"; break;
                case "SyncServerFileDownload":
                    message = "최신 파일 다운로드"; break;
                case "SyncServerFileMove":
                    message = "다운로드 파일 이동"; break;
                case "SyncPublishRelease":
                    message = "설정파일 동기화"; break;
                case "CheckSyncFileExists":
                    message = "로컬 파일 확인"; break;
                default:
                    message = ""; break;
            }

            return message;
        }


        public void Dispose()
        {
            SyncResourceData = null;
            SpecialFiles = null;
        }
    }
}
