namespace GraphicEditorApp
{
    partial class NewProjectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProjectForm));
            this.label1 = new System.Windows.Forms.Label();
            this.InputNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.PathButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя:";
            // 
            // InputNameTextBox
            // 
            this.InputNameTextBox.Location = new System.Drawing.Point(83, 31);
            this.InputNameTextBox.MaxLength = 30;
            this.InputNameTextBox.Name = "InputNameTextBox";
            this.InputNameTextBox.Size = new System.Drawing.Size(219, 20);
            this.InputNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ширина:";
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(83, 66);
            this.WidthTextBox.MaxLength = 4;
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(53, 20);
            this.WidthTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Высота:";
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(83, 103);
            this.HeightTextBox.MaxLength = 4;
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(53, 20);
            this.HeightTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Путь:";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(83, 142);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(218, 20);
            this.PathTextBox.TabIndex = 7;
            // 
            // PathButton
            // 
            this.PathButton.Image = ((System.Drawing.Image)(resources.GetObject("PathButton.Image")));
            this.PathButton.Location = new System.Drawing.Point(307, 140);
            this.PathButton.Name = "PathButton";
            this.PathButton.Size = new System.Drawing.Size(23, 23);
            this.PathButton.TabIndex = 8;
            this.PathButton.UseVisualStyleBackColor = true;
            this.PathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(31, 177);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(104, 23);
            this.OKButton.TabIndex = 9;
            this.OKButton.Text = "ОК";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(226, 177);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(104, 23);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NewProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(371, 212);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.PathButton);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InputNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "NewProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание проекта";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Button PathButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
    }
}