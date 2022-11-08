using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TextChange
{
    internal class TextRedactor
    {
        string dir;
        public TextRedactor(string dir)
        {
                this.dir = dir;
        }

        public void Write(string message)
        {
            StreamWriter textFileWriter = new StreamWriter(dir, true);
            textFileWriter.WriteLine(message);
            textFileWriter.Close();
        }
        public string Read(int line)
        {
            StreamReader textFileReader = new StreamReader(dir);
            string message = "";
            for (int i = 0; i < line; i++)
            {
                message = textFileReader.ReadLine();
            }
            textFileReader.Close(); 
            return message;
        }

        public string ReadAll()
        {
            StreamReader textFileReader = new StreamReader(dir);
            string v = textFileReader.ReadToEnd();
            textFileReader.Close();
            return v;
        }

        public string ResetFile(int line, string mes)
        {
            string all = ReadAll(); 
            string[] separator = { Environment.NewLine };
            string[] allStrings = all.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            StreamWriter textFileWriter = new StreamWriter(dir, false);
            textFileWriter.Write("");
            textFileWriter.Close();
            int i = 0;
            for (i = 0; i < line - 1; i++)
            {
                Write(allStrings[i]);
            }
            Write(mes);
            for (i = line; i < allStrings.Length; i++)
            {
                Write(allStrings[i]);
            }
            return all;
        }
    }
}
