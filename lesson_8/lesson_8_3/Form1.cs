﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lesson_8_3
{
    /*
     * 3. а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок 
     * (не создана база данных, обращение к несуществующему вопросу, 
     * открытие слишком большого файла и т.д.).
     * б) Изменить интерфейс программы, 
     * увеличив шрифт, поменяв цвет элементов и добавив другие «косметические»
     * улучшения на свое усмотрение.
     * в) Добавить в приложение меню «О программе» с информацией о программе 
     * (автор, версия, авторские права и др.).
     * г)* Добавить пункт меню Save As,
     * в котором можно выбрать имя для сохранения базы данных (элемент SaveFileDialog).
     * Павлов Алексей
     */
    public partial class Form1 : Form
    {
        // База данных с вопросами
        TrueFalse database;
        public Form1()
        {
            InitializeComponent();
        }
        // Обработчик пункта меню Exit
        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Обработчик пункта меню New
        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                database.Add("123", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            };
        }
        // Обработчик события изменения значения numericUpDown
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if ((int)nudNumber.Value - 1 <= database.Count && (int)nudNumber.Value - 1 >= 0)
            {
                tboxQuestion.Text = database[(int)nudNumber.Value - 1].text;
                cboxTrue.Checked = database[(int)nudNumber.Value - 1].trueFalse;
            }
            else
            {
                MessageBox.Show("Нет такого вовпроса", "Сообщение");
            }
        }
        // Обработчик кнопки Добавить
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            database.Add((database.Count + 1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }
        // Обработчик кнопки Удалить
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var messageRes = MessageBox.Show("Вы точно хотите удалить вопрос?", "Удаление вопроса", MessageBoxButtons.YesNo);
            if (messageRes == DialogResult.Yes)
            {
                if (nudNumber.Maximum == 1 || database == null) return;
                database.Remove((int)nudNumber.Value);
                nudNumber.Maximum--;
                if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;
            }
        }
        // Обработчик пункта меню Save
        private void miSave_Click(object sender, EventArgs e)
        {
            if (database != null) database.Save();
            else MessageBox.Show("База данных не создана");
        }
        // Обработчик пункта меню Open
        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(ofd.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
            }
        }
        // Обработчик кнопки Сохранить (вопрос)
        private void btnSaveQuest_Click(object sender, EventArgs e)
        {
            if(database == null)
            {
                MessageBox.Show("Не создана база данных!");
            }
            else if (tboxQuestion.TextLength > 0)
            {
                database[(int)nudNumber.Value - 1].text = tboxQuestion.Text;
                database[(int)nudNumber.Value - 1].trueFalse = cboxTrue.Checked;
            }
            else
            {
                MessageBox.Show("Не введено ничего в поле вопроса!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SaveAsToolMenuIteam_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                var ofd = new SaveFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    database.FileName = ofd.FileName;
                    database.Save();
                    
                }
            }
            else MessageBox.Show("База данных не создана");
            
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

        private void tboxQuestion_TextChanged(object sender, EventArgs e)
        {

        }
    }


}
