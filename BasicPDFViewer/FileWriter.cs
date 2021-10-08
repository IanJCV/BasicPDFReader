using System;
using System.IO;
using System.Text;

namespace BasicPDFViewer
{
    public static class FileWriter
    {
        public static string DEFAULT_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\JCVPDF Reader\\folders.txt";

        public static string WriteFile(string path, string contents)
        {
            FileInfo fi = new FileInfo(path);

            if (!fi.Directory.Exists)
            {
                Directory.CreateDirectory(fi.DirectoryName);
            }

            using (StreamWriter sw = new StreamWriter(fi.FullName, false, Encoding.UTF8))
            {
                sw.Write(contents);
                return contents;
            }
        }

        public static string ReadFile(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    return sr.ReadToEnd();
                }
            }
            else
            {
                return WriteFile(path, Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            }

            throw new Exception("The file seems to be in a quantum state. Something's gotta be wrong.");
        }
    }
}