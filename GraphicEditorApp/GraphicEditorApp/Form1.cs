using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicEditorApp
{
    public partial class Form1 : Form
    {
        private List<TabPage> _projects = new List<TabPage>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ColorButton.BackColor = Color.Black;
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = ColorButton.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                ColorButton.BackColor = MyDialog.Color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabPage project = new TabPage();
            project.Location = new System.Drawing.Point(4, 22);
            project.Name = "tabPage3";
            project.Padding = new System.Windows.Forms.Padding(3);
            project.Size = new System.Drawing.Size(898, 458);
            project.TabIndex = 2;
            project.Text = "tabPage3";
            project.UseVisualStyleBackColor = true;
            _projects.Add(project);
            TabControl.Controls.Add(project);
        }

    }
}
