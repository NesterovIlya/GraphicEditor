﻿namespace GraphicEditorApp
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsPanel = new System.Windows.Forms.Panel();
            this.BrushButton = new System.Windows.Forms.Button();
            this.EllipseButton = new System.Windows.Forms.Button();
            this.RecButton = new System.Windows.Forms.Button();
            this.ErraserButton = new System.Windows.Forms.Button();
            this.ColorButton = new System.Windows.Forms.Button();
            this.BrushSizeButton = new System.Windows.Forms.Button();
            this.ChangeBrushSizePanel = new System.Windows.Forms.Panel();
            this.ViewbrushSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.ViewBrushSizeTextBox = new System.Windows.Forms.TextBox();
            this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseAllВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.ToolsPanel.SuspendLayout();
            this.ChangeBrushSizePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewbrushSizeTrackBar)).BeginInit();
            this.TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(950, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.toolStripSeparator1,
            this.CloseToolStripMenuItem,
            this.CloseAllВсеToolStripMenuItem,
            this.toolStripSeparator2,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackToolStripMenuItem,
            this.ForwardToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.EditToolStripMenuItem.Text = "Правка";
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ToolsPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ToolsPanel.Controls.Add(this.button1);
            this.ToolsPanel.Controls.Add(this.ChangeBrushSizePanel);
            this.ToolsPanel.Controls.Add(this.BrushSizeButton);
            this.ToolsPanel.Controls.Add(this.ColorButton);
            this.ToolsPanel.Controls.Add(this.ErraserButton);
            this.ToolsPanel.Controls.Add(this.EllipseButton);
            this.ToolsPanel.Controls.Add(this.RecButton);
            this.ToolsPanel.Controls.Add(this.BrushButton);
            this.ToolsPanel.Location = new System.Drawing.Point(0, 27);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Size = new System.Drawing.Size(37, 485);
            this.ToolsPanel.TabIndex = 1;
            // 
            // BrushButton
            // 
            this.BrushButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BrushButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BrushButton.Image = ((System.Drawing.Image)(resources.GetObject("BrushButton.Image")));
            this.BrushButton.Location = new System.Drawing.Point(3, 3);
            this.BrushButton.Name = "BrushButton";
            this.BrushButton.Size = new System.Drawing.Size(31, 27);
            this.BrushButton.TabIndex = 0;
            this.BrushButton.UseVisualStyleBackColor = false;
            // 
            // EllipseButton
            // 
            this.EllipseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("EllipseButton.Image")));
            this.EllipseButton.Location = new System.Drawing.Point(3, 36);
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new System.Drawing.Size(31, 27);
            this.EllipseButton.TabIndex = 2;
            this.EllipseButton.UseVisualStyleBackColor = true;
            // 
            // RecButton
            // 
            this.RecButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RecButton.Image = ((System.Drawing.Image)(resources.GetObject("RecButton.Image")));
            this.RecButton.Location = new System.Drawing.Point(3, 69);
            this.RecButton.Name = "RecButton";
            this.RecButton.Size = new System.Drawing.Size(31, 27);
            this.RecButton.TabIndex = 2;
            this.RecButton.UseVisualStyleBackColor = true;
            // 
            // ErraserButton
            // 
            this.ErraserButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ErraserButton.Image = ((System.Drawing.Image)(resources.GetObject("ErraserButton.Image")));
            this.ErraserButton.Location = new System.Drawing.Point(3, 102);
            this.ErraserButton.Name = "ErraserButton";
            this.ErraserButton.Size = new System.Drawing.Size(31, 27);
            this.ErraserButton.TabIndex = 2;
            this.ErraserButton.UseVisualStyleBackColor = true;
            // 
            // ColorButton
            // 
            this.ColorButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ColorButton.Location = new System.Drawing.Point(3, 135);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(31, 27);
            this.ColorButton.TabIndex = 2;
            this.ColorButton.UseVisualStyleBackColor = false;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // BrushSizeButton
            // 
            this.BrushSizeButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BrushSizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BrushSizeButton.Image = ((System.Drawing.Image)(resources.GetObject("BrushSizeButton.Image")));
            this.BrushSizeButton.Location = new System.Drawing.Point(3, 168);
            this.BrushSizeButton.Name = "BrushSizeButton";
            this.BrushSizeButton.Size = new System.Drawing.Size(31, 27);
            this.BrushSizeButton.TabIndex = 3;
            this.BrushSizeButton.UseVisualStyleBackColor = false;
            // 
            // ChangeBrushSizePanel
            // 
            this.ChangeBrushSizePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ChangeBrushSizePanel.Controls.Add(this.ViewBrushSizeTextBox);
            this.ChangeBrushSizePanel.Controls.Add(this.ViewbrushSizeTrackBar);
            this.ChangeBrushSizePanel.Location = new System.Drawing.Point(3, 201);
            this.ChangeBrushSizePanel.Name = "ChangeBrushSizePanel";
            this.ChangeBrushSizePanel.Size = new System.Drawing.Size(31, 229);
            this.ChangeBrushSizePanel.TabIndex = 2;
            // 
            // ViewbrushSizeTrackBar
            // 
            this.ViewbrushSizeTrackBar.AutoSize = false;
            this.ViewbrushSizeTrackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ViewbrushSizeTrackBar.Location = new System.Drawing.Point(3, 29);
            this.ViewbrushSizeTrackBar.Maximum = 20;
            this.ViewbrushSizeTrackBar.Minimum = 1;
            this.ViewbrushSizeTrackBar.Name = "ViewbrushSizeTrackBar";
            this.ViewbrushSizeTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ViewbrushSizeTrackBar.Size = new System.Drawing.Size(24, 196);
            this.ViewbrushSizeTrackBar.TabIndex = 3;
            this.ViewbrushSizeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ViewbrushSizeTrackBar.Value = 1;
            // 
            // ViewBrushSizeTextBox
            // 
            this.ViewBrushSizeTextBox.Location = new System.Drawing.Point(3, 3);
            this.ViewBrushSizeTextBox.Name = "ViewBrushSizeTextBox";
            this.ViewBrushSizeTextBox.Size = new System.Drawing.Size(24, 20);
            this.ViewBrushSizeTextBox.TabIndex = 4;
            // 
            // CreateToolStripMenuItem
            // 
            this.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
            this.CreateToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.CreateToolStripMenuItem.Text = "Создать";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.OpenToolStripMenuItem.Text = "Открыть";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.CloseToolStripMenuItem.Text = "Закрыть";
            // 
            // CloseAllВсеToolStripMenuItem
            // 
            this.CloseAllВсеToolStripMenuItem.Name = "CloseAllВсеToolStripMenuItem";
            this.CloseAllВсеToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.CloseAllВсеToolStripMenuItem.Text = "Закрыть все";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(150, 6);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.SaveAsToolStripMenuItem.Text = "Сохранить как";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(150, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            // 
            // BackToolStripMenuItem
            // 
            this.BackToolStripMenuItem.Name = "BackToolStripMenuItem";
            this.BackToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.BackToolStripMenuItem.Text = "Отменить";
            // 
            // ForwardToolStripMenuItem
            // 
            this.ForwardToolStripMenuItem.Name = "ForwardToolStripMenuItem";
            this.ForwardToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ForwardToolStripMenuItem.Text = "Вернуть";
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Location = new System.Drawing.Point(44, 28);
            this.TabControl.Multiline = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(906, 484);
            this.TabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(898, 458);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(898, 458);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Location = new System.Drawing.Point(3, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 27);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 513);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.ToolsPanel);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Графический редактор";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ToolsPanel.ResumeLayout(false);
            this.ChangeBrushSizePanel.ResumeLayout(false);
            this.ChangeBrushSizePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewbrushSizeTrackBar)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.Panel ToolsPanel;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.Button ErraserButton;
        private System.Windows.Forms.Button RecButton;
        private System.Windows.Forms.Button EllipseButton;
        private System.Windows.Forms.Button BrushButton;
        private System.Windows.Forms.Panel ChangeBrushSizePanel;
        private System.Windows.Forms.Button BrushSizeButton;
        private System.Windows.Forms.TextBox ViewBrushSizeTextBox;
        private System.Windows.Forms.TrackBar ViewbrushSizeTrackBar;
        private System.Windows.Forms.ToolStripMenuItem CreateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseAllВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ForwardToolStripMenuItem;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;






    }
}
