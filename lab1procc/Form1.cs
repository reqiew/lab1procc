using System.Diagnostics;

namespace lab1procc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string wordToSearch = textBox1.Text;
            string filePath = textBox2.Text;
            string writeToFIle = Guid.NewGuid().ToString();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "C:\\Users\\dobry\\Downloads\\lab1procc\\ChildProcess\\bin\\Debug\\net8.0\\ChildProcess.exe",
                Arguments = $"{filePath} {wordToSearch} {writeToFIle}",
            };

            Process process = new Process { StartInfo = startInfo };
            process.Start();
            process.WaitForExit();

            string fileText = File.ReadAllText(writeToFIle);
            FileInfo fileInf = new FileInfo(writeToFIle);
            if (fileInf.Exists) { fileInf.Delete(); }
            label1.Text = fileText;
        }


    }
}
