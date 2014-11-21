using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphicEditorApp.Model;

namespace GraphicEditorApp
{
    public partial class NewProjectForm : Form
    {

        public Project project
        { get; private set; }

        public NewProjectForm()
        {
            InitializeComponent();
            project = null;
        }

        private void PathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PathTextBox.Text = dialog.SelectedPath;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (ParseInput()) this.Close(); 
        }

        private bool ParseInput()
        {
            if (InputNameTextBox.Text == String.Empty || InputNameTextBox.Text.Length < 3)
            {
                MessageBox.Show("Имя проекта должно содержать не менее 3х символов!");
                return false;
            }
            int width;
            if (!Int32.TryParse(WidthTextBox.Text, out width))
            {
                MessageBox.Show("Неверное значение ширины!");
                return false;
            }
            int height;
            if (!Int32.TryParse(WidthTextBox.Text, out height))
            {
                MessageBox.Show("Неверное значение высоты!");
                return false;
            }

            if (PathTextBox.Text == String.Empty)
            {
                MessageBox.Show("Путь не должен быть пустым!");
                return false;
            }

            DirectoryInfo dir = new DirectoryInfo(PathTextBox.Text);
            if (!dir.Exists)
            {
                MessageBox.Show("Указанная папка не существует!");
                return false;
            }

            DirectoryInfo projectDir = new DirectoryInfo(PathTextBox.Text + "\\" + InputNameTextBox.Text);

            if (projectDir.Exists)
            {
                var result = MessageBox.Show("Проект с таким названием уже существует. Перезаписать его?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    projectDir.Delete(true);
                }
                else
                {
                    return false;
                }
            }

            projectDir.Create();

            project = new Project(InputNameTextBox.Text, width, height, projectDir.FullName);

            return true;
        }
    }
}
