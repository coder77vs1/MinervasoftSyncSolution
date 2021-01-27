using System.Collections.Generic;

namespace ScanLauncher.Data
{
    public class RequestItem
    {
        /// <summary>
        /// 기관코드
        /// </summary>
        public string CORR_INSTT_CD { get; set; } = string.Empty;

        /// <summary>
        /// 기관명
        /// </summary>
        public string CORR_INSTT_NM { get; set; } = string.Empty;

        /// <summary>
        /// 대분류
        /// </summary>
        public string LCLAS_CD { get; set; } = string.Empty;

        /// <summary>
        /// 중분류
        /// </summary>
        public string MLSFC_CD { get; set; } = string.Empty;

        /// <summary>
        /// 소분류
        /// </summary>
        public string SCLAS_CD { get; set; } = string.Empty;        

        /// <summary>
        /// 사용자아이디
        /// </summary>
        public string USR_ID { get; set; } = string.Empty;

        /// <summary>
        /// 사용자명
        /// </summary>
        public string USR_NM { get; set; } = string.Empty;

        /// <summary>
        /// 부서코드
        /// </summary>
        public string DEPT_CD { get; set; } = string.Empty;

        /// <summary>
        /// 부서명
        /// </summary>
        public string DEPT_NM { get; set; } = string.Empty;

        /// <summary>
        /// 모드
        /// </summary>
        public string R_MODE { get; set; } = string.Empty;

        /// <summary>
        /// 관리자
        /// </summary>
        public string ADM_YN { get; set; } = string.Empty;

        /// <summary>
        /// 매개변수
        /// </summary>
        public IDictionary<string, string> QueryString { get; set; } = new Dictionary<string, string>();
    }
}