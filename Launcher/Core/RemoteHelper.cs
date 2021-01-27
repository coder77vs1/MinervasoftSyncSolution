using System;

namespace ScanLauncher.Core
{
    public class RemoteHelper : MarshalByRefObject
    {
        private static int _processId = -1;
        private static string _clickonceVersion = string.Empty;
        private static string _userId = string.Empty;
        private static string _context = string.Empty;

        public int GetProcessId()
        {
            return _processId;
        }

        public string GetCurrentUserId()
        {
            return _userId;
        }

        public string GetCurrentAuthData()
        {
            return _context;
        }

        public string GetCurrentClickOnceVersion()
        {
            return _clickonceVersion;
        }

        public void SetCurrentAuthData(string userid, int processid, string context, string clickonceversion)
        {
            if (processid > 0)
            {
                _userId = userid;
                _processId = processid;
                _context = context;
                _clickonceVersion = clickonceversion;
            }
            else
            {
                throw new Exception("Setid : RemoteHelper Server Error : " + processid.ToString());
            }
        }
    }
}
