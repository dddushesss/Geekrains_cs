using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lesson_8_4
{
    public partial class Form1 : Form
    {
        TrueFalse dataBase;
        Question CurQuest;
        int numOfQuestions;
        int score;

        public Form1()
        {
            InitializeComponent();
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                dataBase = new TrueFalse(ofd.FileName);
                if (!dataBase.Load())
                {
                    MessageBox.Show("Неверный формат файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    numericUpDown1.Enabled = true;
                    numericUpDown1.Maximum = dataBase.Count;
                   
                }
            }
        }

        private void LoadNext()
        {
            var rnd = new Random();
            CurQuest = dataBase[rnd.Next(0, dataBase.Count)];
            Question.Text = CurQuest.text;
            this.Height = Question.Height + 150;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
        "Автор: Павлов Алексей\n" +
        "Версия: 0.00001а\n" +
        "Авторские права: нет",
        "О программе",
        MessageBoxButtons.OK,
        MessageBoxIcon.Question,
        MessageBoxDefaultButton.Button1
        );
        }

        private void EndOfGame()
        {
            MessageBox.Show($"Вы закончили! Ваш счёт {score}/{numericUpDown1.Value}");
            dataBase.Load();
            numericUpDown1.Enabled = true;
            score = 0;
            Question.Text = "";
            ScoreLabel.Text = "";
            Yes.Enabled = false;
            No.Enabled = false;
        }

        private void CheckAnswer(bool answer)
        {
            if (answer.Equals(CurQuest.trueFalse))
            {
                score++;
                ScoreLabel.Text = $"Верно! Текущий счёт - {score}";
            }
            else
            {
                ScoreLabel.Text = $"Неверно! Текущий счёт - {score}";
            }
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            if(numOfQuestions > 0)
            {
                CheckAnswer(true);
                LoadNext();
                numOfQuestions--;
            }
            if(numOfQuestions == 0)
            {
                EndOfGame();
            }
            
        }


        private void No_Click(object sender, EventArgs e)
        {
            if(numOfQuestions > 0)
            {
                CheckAnswer(false);
                LoadNext();
                numOfQuestions--;
            }
            if (numOfQuestions == 0)
            {
                EndOfGame();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 1;
            numericUpDown1.Enabled = false;
            Question.Text = "";
            Yes.Enabled = false;
            No.Enabled = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = dataBase.Count;
            numOfQuestions = (int)numericUpDown1.Value - 1;
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataBase != null)
            {
                LoadNext();
                Yes.Enabled = true;
                No.Enabled = true;
                score = 0;
                numericUpDown1.Enabled = false;
                ScoreLabel.Text = $"Текущий счёт {score}";
                numOfQuestions = (int)numericUpDown1.Value;
            }
            else
            {
                MessageBox.Show("Ошибка", "Не выбран файл вопросов!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
