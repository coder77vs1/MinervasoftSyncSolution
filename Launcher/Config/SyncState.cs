namespace ScanLauncher.Config
{
    public enum PublishProcessStatus : int
    {
        Default,
        Client_True,
        Client_False,
        Service_True,
        Service_False,
        Download_True,
        Download_False,
        FileMove_True,
        FileMove_False,
        Release_True,
        Release_False,
        Complete,
        Fail,
        Exists_True,
        Exists_False,
    }

    public enum SyncFileStatus
    {
        Download,
        Exists,
        Update,
        Fail,
        Empty,
    }

    public enum BusinessProcessMode
    {
        //사회심리 
        REH,
        //영치구매
        PRO,
        //수용기록
        ACR,
        //의료정보
        MED,
        //기본
        DEF,
    }

    public enum LauncherStatus
    { 
        //실행중
        IsRuning,
        //오류
        Error,
        //경고
        Warning,
        //정보
        Information,
    }

    /// <summary>
    /// 런처 실행 상태
    /// </summary>
    public enum LauncherRunStatus
    {
        /// <summary>
        /// 대기
        /// </summary>
        Standby,
        /// <summary>
        /// 실행중
        /// </summary>
        IsRuning,
        /// <summary>
        /// 오류
        /// </summary>
        Error,
    }
}
