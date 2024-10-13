using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Management;
using System.Text;

namespace ChildProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = args[0];
            string wordToSearch = args[1];
            string writeToFIle = args[2];

            int count = 0;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                int index = 0;
                while ((index = line.IndexOf(wordToSearch, index, StringComparison.Ordinal)) != -1)
                {
                    count++;
                    index += wordToSearch.Length;
                }
            }

            using (FileStream fstream = new FileStream(writeToFIle, FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(count.ToString());
                fstream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}