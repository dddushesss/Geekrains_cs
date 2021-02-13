using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lesson_8
{
    /*
     * 1. С помощью рефлексии выведите все свойства структуры DateTime
     * Павлов Алексей
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime();
            var props = dateTime.GetType().GetProperties();
            label1.Text = "";
            foreach (var prop in props)
            {
                label1.Text += prop.Name.ToString() + '\n';
            }
            this.Size = new Size(this.Width, label1.Height + 50);
        }
    }
}
