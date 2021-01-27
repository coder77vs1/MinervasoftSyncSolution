using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ScanLauncher.Core
{
    public class FileHelper
    {
        public static bool CreateFile(string fullPath, string context)
        {
            bool result = false;

            try
            {
                using (FileStream fs = File.Create(fullPath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(context);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public static bool ExistsDirectory(string path)
        {
            bool result = false;

            try
            {
                if (Directory.Exists(path) == false)
                    Directory.CreateDirectory(path);

                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public static bool ExistsFile(string path)
        {
            bool result = false;

            try
            {
                result = File.Exists(path);
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public static void FileDelete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch
            {
            }
        }

        public static bool DirectoryDelete(string path)
        {
            bool result = false;

            try
            {
                Directory.Delete(path, true);
                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public static string PathCombine(string path1, string path2)
        {
            return Path.Combine(path1, path2);
        }

        public static string ReadFile(string path)
        {
            string sResult = string.Empty;

            if (File.Exists(path))
            {   
                StreamReader sr = null;

                try
                {
                    sr = new StreamReader(path);
                    sResult = sr.ReadToEnd();
                }
                finally
                {
                    if (sr != null) sr.Close();
                }
            }

            return sResult;
        }

        public static bool CreateResourceFile(string path, string context)
        {
            bool result = false;

            StreamWriter sw = null;
            try
            {
                File.Delete(path);

                sw = File.CreateText(path);
                sw.WriteLine(context);
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (sw != null) sw.Close();
            }

            return result;
        }

        public static string GetNewTempPath(string newDir)
        { 
            return Path.Combine(Path.GetTempPath(), newDir);
        }

        public static void ClearTempPathByStartsWith(string value)
        {
            string[] directories = Directory.GetDirectories(Path.GetTempPath());
            var target = directories.Where(x =>
                x.ToString().IndexOf(value, System.StringComparison.CurrentCultureIgnoreCase) > 0).ToList();

            foreach (var item in target)
            {
                Directory.Delete(item.ToString(), true);
            }
        }

        public static string GetDownloadTempPath(string tempPath, string fileName)
        {
            // 폴더 없으면 생성
            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }

            string downFileName = fileName;

            return Path.Combine(tempPath, downFileName);
        }

        public static bool FileMove(string sourceFile, string destFile)
        {
            bool result = false;

            try
            {
                //다운로드 파일 체크
                if (ExistsFile(sourceFile))
                {
                    //폴더 없으면 생성
                    ExistsDirectory(Path.GetDirectoryName(destFile));

                    //파일 있으면 삭제
                    if (ExistsFile(destFile))
                        FileDelete(destFile);

                    //파일 복사
                    File.Copy(sourceFile, destFile, true);
                    result = true;
                }
            }
            catch
            { }

            return result;
        }

        public static bool WriteFile(string path, string context)
        {
            bool result = false;

            StreamWriter sw = null;
            try
            {
                File.Delete(path);

                sw = File.CreateText(path);
                sw.WriteLine(context);
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (sw != null) sw.Close();
            }

            return result;
        }
    }
}
