using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsymmetricEncryption
{
    public class FileOperations
    {
        public static string GetPathFileWrite()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            string path = "";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                path = saveFileDialog1.FileName;
            return path;
        }

        public static string GetFileContent()
        {
            string path = GetPathFileRead();
            return File.ReadAllText(path);
        }
        public static void WriteFileContent(string content)
        {
            string path = GetPathFileWrite();
            StreamWriter writer = new StreamWriter(path);
            writer.Write(content);
            writer.Close();
            writer.Dispose();
        }

        public static string GetPathFileRead()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            string path = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                path = openFileDialog1.FileName;
            return path;
        }
        public static byte[] GetFileContentByte(string path)//чтение файла, результат байты
        {
            FileStream fs = File.OpenRead(path);
            byte[] checkContent = new byte[CheckSize(path)];
            int i = fs.Read(checkContent, 0, checkContent.Length);
            fs.Close();
            return checkContent;
        }
        private static long CheckSize(string path) => new FileInfo(path).Length; //размер файла


    }
}
