
namespace lesson_7_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Num = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.MoreOrLess = new System.Windows.Forms.Label();
            this.Attempts = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Num
            // 
            this.Num.Location = new System.Drawing.Point(12, 12);
            this.Num.Name = "Num";
            this.Num.Size = new System.Drawing.Size(276, 26);
            this.Num.TabIndex = 0;
            this.Num.TextChanged += new System.EventHandler(this.Num_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Угадать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(200, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "Заново";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MoreOrLess
            // 
            this.MoreOrLess.AutoSize = true;
            this.MoreOrLess.Location = new System.Drawing.Point(12, 46);
            this.MoreOrLess.Name = "MoreOrLess";
            this.MoreOrLess.Size = new System.Drawing.Size(51, 20);
            this.MoreOrLess.TabIndex = 5;
            this.MoreOrLess.Text = "label3";
            // 
            // Attempts
            // 
            this.Attempts.AutoSize = true;
            this.Attempts.Location = new System.Drawing.Point(143, 71);
            this.Attempts.Name = "Attempts";
            this.Attempts.Size = new System.Drawing.Size(51, 20);
            this.Attempts.TabIndex = 6;
            this.Attempts.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Попыток";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 123);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Attempts);
            this.Controls.Add(this.MoreOrLess);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Num);
            this.Name = "Form1";
            this.Text = "Угадайка";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Num;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label MoreOrLess;
        private System.Windows.Forms.Label Attempts;
        private System.Windows.Forms.Label label5;
    }
}

