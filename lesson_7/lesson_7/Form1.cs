using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lesson_7
{
    public delegate void NumsMatchHandler(object sender, EventArgs e);
    public partial class Form1 : Form
    {
        public event NumsMatchHandler NumsMatchEvent;
        enum Comands
        {
            Plus1,
            X2
        }
        private int _numToGues;
        private Stack<Comands> _lastComand;
        public Form1()
        {
            InitializeComponent();
            NumsMatchEvent += Form1_NumsMatchEvent;
        }

        private void Form1_NumsMatchEvent(object sender, EventArgs e)
        {
            MessageBox.Show($"Вы получили нужное число! У вас это заняло {ComandsCounter.Text} действий");
            ComandsCounter.Text = "0";
            Num.Text = "0";
            _lastComand = new Stack<Comands>();
            NumToGues.Visible = false;
            label3.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Num.Text = 0.ToString();
            ComandsCounter.Text = 0.ToString();
            NumToGues.Visible = false;
            label3.Visible = false;
            _lastComand = new Stack<Comands>();
        }

        private void Plus1_Click(object sender, EventArgs e)
        {
            _lastComand.Push(Comands.Plus1);
            ComandsCounter.Text = _lastComand.Count.ToString();
            Num.Text = (int.Parse(Num.Text) + 1).ToString();
            if((NumToGues.Visible) && Num.Text.Equals(NumToGues.Text) && (NumsMatchEvent != null))
            {
                NumsMatchEvent.Invoke(sender, e);
            }
            
        }

        private void X2_Click(object sender, EventArgs e)
        {
            _lastComand.Push(Comands.X2);
            ComandsCounter.Text = _lastComand.Count.ToString();
            Num.Text = (int.Parse(Num.Text) * 2).ToString();
            if (Num.Text.Equals(NumToGues.Text) && (NumsMatchEvent != null))
            {
                NumsMatchEvent.Invoke(sender, e);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ComandsCounter.Text = (int.Parse(ComandsCounter.Text) + 1).ToString();
            Num.Text = 0.ToString();
        }
        private void Play_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            _lastComand = new Stack<Comands>();
            _numToGues = random.Next(0, 100);
            ComandsCounter.Text = 0.ToString();
            NumToGues.Visible = true;
            label3.Visible = true;
            NumToGues.Text = _numToGues.ToString();
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            if (!ComandsCounter.Text.Equals("0"))
            {
                switch (_lastComand.Pop())
                {
                    case Comands.Plus1:
                        Num.Text = (int.Parse(Num.Text) - 1).ToString();
                        break;
                    case Comands.X2:
                        Num.Text = (int.Parse(Num.Text) / 2).ToString();
                        break;
                }
                ComandsCounter.Text = (int.Parse(ComandsCounter.Text) - 1).ToString();
            }
        }

       
    }
}
