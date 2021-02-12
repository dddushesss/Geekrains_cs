
namespace lesson_7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Plus1 = new System.Windows.Forms.Button();
            this.X2 = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Num = new System.Windows.Forms.Label();
            this.ComandsCounter = new System.Windows.Forms.Label();
            this.Play = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NumToGues = new System.Windows.Forms.Label();
            this.Undo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Plus1
            // 
            this.Plus1.Location = new System.Drawing.Point(275, 18);
            this.Plus1.Name = "Plus1";
            this.Plus1.Size = new System.Drawing.Size(112, 34);
            this.Plus1.TabIndex = 0;
            this.Plus1.Text = "+1";
            this.Plus1.UseVisualStyleBackColor = true;
            this.Plus1.Click += new System.EventHandler(this.Plus1_Click);
            // 
            // X2
            // 
            this.X2.Location = new System.Drawing.Point(275, 58);
            this.X2.Name = "X2";
            this.X2.Size = new System.Drawing.Size(112, 34);
            this.X2.TabIndex = 1;
            this.X2.Text = "X2";
            this.X2.UseVisualStyleBackColor = true;
            this.X2.Click += new System.EventHandler(this.X2_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(275, 98);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(112, 34);
            this.Clear.TabIndex = 1;
            this.Clear.Text = "Сброс";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Num
            // 
            this.Num.AutoSize = true;
            this.Num.Location = new System.Drawing.Point(13, 48);
            this.Num.Name = "Num";
            this.Num.Size = new System.Drawing.Size(59, 25);
            this.Num.TabIndex = 2;
            this.Num.Text = "label1";
            // 
            // ComandsCounter
            // 
            this.ComandsCounter.AutoSize = true;
            this.ComandsCounter.Location = new System.Drawing.Point(13, 98);
            this.ComandsCounter.Name = "ComandsCounter";
            this.ComandsCounter.Size = new System.Drawing.Size(59, 25);
            this.ComandsCounter.TabIndex = 2;
            this.ComandsCounter.Text = "label1";
            // 
            // Play
            // 
            this.Play.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Play.Location = new System.Drawing.Point(275, 138);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(112, 34);
            this.Play.TabIndex = 1;
            this.Play.Text = "Играть";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Команд";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Текущее число";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Числ, которое надо получить";
            // 
            // NumToGues
            // 
            this.NumToGues.AutoSize = true;
            this.NumToGues.Location = new System.Drawing.Point(12, 187);
            this.NumToGues.Name = "NumToGues";
            this.NumToGues.Size = new System.Drawing.Size(59, 25);
            this.NumToGues.TabIndex = 6;
            this.NumToGues.Text = "label4";
            // 
            // Undo
            // 
            this.Undo.Location = new System.Drawing.Point(275, 178);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(112, 34);
            this.Undo.TabIndex = 7;
            this.Undo.Text = "Отменить";
            this.Undo.UseVisualStyleBackColor = true;
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 230);
            this.Controls.Add(this.Undo);
            this.Controls.Add(this.NumToGues);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComandsCounter);
            this.Controls.Add(this.Num);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.X2);
            this.Controls.Add(this.Plus1);
            this.Name = "Form1";
            this.Text = "Удвоитель";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Plus1;
        private System.Windows.Forms.Button X2;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Label Num;
        private System.Windows.Forms.Label ComandsCounter;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NumToGues;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Undo;
    }
}

