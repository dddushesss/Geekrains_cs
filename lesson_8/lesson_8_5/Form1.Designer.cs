
namespace lesson_8_5
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
            this.FileFrom = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.FileTo = new System.Windows.Forms.Button();
            this.FileNameFrom = new System.Windows.Forms.Label();
            this.FileNameTo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FileFrom
            // 
            this.FileFrom.Location = new System.Drawing.Point(8, 7);
            this.FileFrom.Name = "FileFrom";
            this.FileFrom.Size = new System.Drawing.Size(75, 23);
            this.FileFrom.TabIndex = 0;
            this.FileFrom.Text = "Файл CSV";
            this.FileFrom.UseVisualStyleBackColor = true;
            this.FileFrom.Click += new System.EventHandler(this.FileFrom_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(49, 53);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 1;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // FileTo
            // 
            this.FileTo.Location = new System.Drawing.Point(111, 7);
            this.FileTo.Name = "FileTo";
            this.FileTo.Size = new System.Drawing.Size(95, 27);
            this.FileTo.TabIndex = 2;
            this.FileTo.Text = "Куда сохранить";
            this.FileTo.UseVisualStyleBackColor = true;
            this.FileTo.Click += new System.EventHandler(this.FileTo_Click);
            // 
            // FileNameFrom
            // 
            this.FileNameFrom.AutoSize = true;
            this.FileNameFrom.Location = new System.Drawing.Point(12, 37);
            this.FileNameFrom.Name = "FileNameFrom";
            this.FileNameFrom.Size = new System.Drawing.Size(35, 13);
            this.FileNameFrom.TabIndex = 3;
            this.FileNameFrom.Text = "label1";
            // 
            // FileNameTo
            // 
            this.FileNameTo.AutoSize = true;
            this.FileNameTo.Location = new System.Drawing.Point(111, 37);
            this.FileNameTo.Name = "FileNameTo";
            this.FileNameTo.Size = new System.Drawing.Size(35, 13);
            this.FileNameTo.TabIndex = 4;
            this.FileNameTo.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 109);
            this.Controls.Add(this.FileNameTo);
            this.Controls.Add(this.FileNameFrom);
            this.Controls.Add(this.FileTo);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.FileFrom);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FileFrom;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button FileTo;
        private System.Windows.Forms.Label FileNameFrom;
        private System.Windows.Forms.Label FileNameTo;
    }
}

