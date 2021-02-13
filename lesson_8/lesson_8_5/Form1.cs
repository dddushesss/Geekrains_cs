using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace lesson_8_5
{
    public partial class Form1 : Form
    {
        /*
         * 3. *Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок).
         */
        OpenFileDialog ofd;
        SaveFileDialog sfd;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileNameFrom.Text = "";
            FileNameTo.Text = "";

        }

        private void FileFrom_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "CSV files(*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileNameFrom.Text = ofd.FileName.Substring(ofd.FileName.LastIndexOf('\\') + 1);

            }
        }
        private void Transform()
        {
            if(sfd != null && ofd != null)
            {
                List<Student> students = new List<Student>();
                var fstream = new StreamReader(ofd.FileName);
                int a = 0;
                while (!fstream.EndOfStream)
                {
                    var s = fstream.ReadLine().Split(';');
                    students.Add(new Student(
                        s[0], s[1], s[2], s[3], s[4], int.TryParse(s[5], out a) ? a : -1, int.TryParse(s[6], out a) ? a : -1,
                        int.TryParse(s[7], out a) ? a : -1, s[8]
                        ));
                }
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
                Stream fStream = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                xmlFormat.Serialize(fStream, students);
                fStream.Close();
            }
            else
            {
                MessageBox.Show("Не выбраны файлы для конвертации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FileTo_Click(object sender, EventArgs e)
        {
            sfd = new SaveFileDialog();
            sfd.Filter = "All files(*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileNameTo.Text = sfd.FileName.Substring(sfd.FileName.LastIndexOf('\\') + 1);

            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Transform();
        }
    }
}
