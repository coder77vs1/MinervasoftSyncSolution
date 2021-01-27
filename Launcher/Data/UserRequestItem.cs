namespace ScanLauncher.Data
{
    public class UserRequestItem
    {
        #region Input

        /// <summary>
        /// 기관코드
        /// </summary>
        public string corrInsttCd { get; set; } = string.Empty;

        /// <summary>
        /// 사용자아이디
        /// </summary>
        public string usrId { get; set; } = string.Empty;
        #endregion

        #region Output

        /// <summary>
        /// 암호화 키
        /// </summary>
        public string privateKey { get; set; } = "";
        /// <summary>
        /// 실패구분 (1/2/3)
        /// (DB/File/Server)
        /// </summary>
        public string errorCode { get; set; } = "";

        /// <summary>
        /// 인터페이스 결과 (성공:0)
        /// </summary>
        public string resultcode { get; set; } = "0";

        /// <summary>
        /// 인터페이스 결과메세지
        /// </summary>
        public string resultmessage { get; set; } = "";

        /// <summary>
        /// 암호화 데이터 (요청)
        /// </summary>
        public string encData { get; set; } = string.Empty;

        /// <summary>
        /// 암호화 데이터 (회신)
        /// </summary>
        public string ENC_DATA { get; set; } = string.Empty;
        #endregion
    }
}
