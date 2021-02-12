using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lesson_7_2
{
    /*
     * 2. Используя Windows Forms, разработать игру «Угадай число». 
     * Компьютер загадывает число от 1 до 100, 
     * а человек пытается его угадать за минимальное число попыток. 
     * Для ввода данных от человека используется элемент TextBox.
     * Павлов Алексей
     */
    public delegate void NumsMatchHandler(object sender, EventArgs e);
    public partial class Form1 : Form
    {
        public event NumsMatchHandler NumsMatchEvent;
        private int _numToGues;
        public Form1()
        {
            InitializeComponent();
        }

        private void Num_TextChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < Num.TextLength ; i++)
            {
                if (Num.Text.Length != 0 && (!char.IsDigit(Num.Text[i])))
                {
                    Num.Text = Num.Text.Remove(i, 1);
                }
            }
            Num.SelectionStart = Num.Text.Length;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            _numToGues = random.Next(0, 100);
            NumsMatchEvent += Form1_NumsMatchEvent;
            Attempts.Text = "0";
            MoreOrLess.Text = "";
        }

        private void Form1_NumsMatchEvent(object sender, EventArgs e)
        {
            MessageBox.Show($"Вы угодали число! Вам потребовалось для этого {Attempts.Text} попыток");
            Attempts.Text = "0";
            MoreOrLess.Text = "";
            Random random = new Random();
            _numToGues = random.Next(0, 100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Num.TextLength != 0)
            {
                var numToGues = _numToGues;
                Attempts.Text = (int.Parse(Attempts.Text) + 1).ToString();
                var num = int.Parse(Num.Text);
                if ((num == numToGues) && NumsMatchEvent != null)
                {
                    NumsMatchEvent.Invoke(sender, e);
                }
                else if (num > numToGues)
                {
                    MoreOrLess.Text = "Меньше";
                }
                else
                {
                    MoreOrLess.Text = "Больше";
                }
            }
            else
            {
                MessageBox.Show("Не введено число");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Attempts.Text = "0";
            MoreOrLess.Text = "";
            Random random = new Random();
            _numToGues = random.Next(0, 100);
        }
    }
}
