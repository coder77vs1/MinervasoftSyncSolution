namespace ScanLauncher.Config
{
    public class KeyContext
    {
        public class QueryKey
        {
            /// <summary>
            /// 프로세서 아이디
            /// </summary>
            public const string ProcessId = "pid";

            /// <summary>
            /// 키아이디
            /// </summary>
            public const string SecurityId = "sid";

            /// <summary>
            /// 요청정보(교정기관/사용자아이디)
            /// </summary>
            public const string AuthCode = "auth";

            /// <summary>
            /// 대분류
            /// </summary>
            public const string Mode = "mode";

            /// <summary>
            /// 중분류
            /// </summary>
            public const string Mlsfc = "mlsfc";

            /// <summary>
            /// 소분류
            /// </summary>
            public const string Sclas = "sclas";

            /// <summary>
            /// 요청모드
            /// </summary>
            public const string RequestMode = "rmode";
        }
    }
}
