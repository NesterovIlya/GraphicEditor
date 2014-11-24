using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphicEditorApp.Model;
using System.Runtime.Serialization;
using System.Xml;

namespace GraphicEditorApp
{
    public partial class Form1 : Form
    {
        private Painter painter;

        private List<ProjectView> Projects;

        private ProjectView ActiveProjectView;

        private Tools ActiveTool;

        private PictureBox mask;

        private bool BrushSizeSwitcherFlag = false;

        private Point mouseDownCoord;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // начальная инициализация
            this.DoubleBuffered = true;
            this.MinimumSize = new Size(300,200);
            Projects = new List<ProjectView>();
            ColorButton.BackColor = Color.Black;
            ActiveTool = Tools.BRUSH;
            painter = new Painter(ColorButton.BackColor, 1);
            ChangeBrushSizePanel.Hide();
        }

        // выбор цвета
        private void ColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.AllowFullOpen = true;
            dialog.FullOpen = true;
            dialog.Color = ColorButton.BackColor;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorButton.BackColor = dialog.Color;
                painter.color = ColorButton.BackColor;
            }
        }

        //создание проекта
        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newProjectForm = new NewProjectForm();
            newProjectForm.ShowDialog();
            if (newProjectForm.project != null) NewTab(newProjectForm.project);
            newProjectForm.Dispose();
        }
        //открытие проекта
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "D:\\Works\\Temp\\";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(dialog.FileName);
                switch (ext)
                {
                    case ".jpg":
                    case ".bmp":
                    case ".png":
                        {
                            try
                            {
                                Bitmap background = new Bitmap(dialog.FileName);
                                Project project = new Project(
                                    System.IO.Path.GetFileNameWithoutExtension(dialog.FileName),
                                    background.Width,
                                    background.Height,
                                    System.IO.Path.GetFullPath(dialog.FileName).Replace(ext,".gpt"),
                                    System.IO.Path.GetFullPath(dialog.FileName).Replace(ext,"_canvas.jpg")
                                    );
                                project.Canvas = background;
                                NewTab(project, project.Canvas);
                            }
                            catch (System.IO.FileNotFoundException ex)
                            {
                                MessageBox.Show("Файл не найден!");
                            }
                            break;
                        }
                    case ".gpt":
                        {

                            foreach (ProjectView projectView in Projects)
                            {
                                if (projectView.projectProperties.ProjectPath.Equals(dialog.FileName))
                                {
                                    MessageBox.Show("Проект уже отрыт!");
                                    return;
                                }
                            }

                            FileStream fs = null;
                            XmlDictionaryReader reader = null;
                            try
                            {
                                fs = new FileStream(dialog.FileName, FileMode.Open);
                                XmlDictionaryReaderQuotas quotas = new XmlDictionaryReaderQuotas();
                                quotas.MaxArrayLength = 100000;
                                reader = XmlDictionaryReader.CreateTextReader(fs, quotas);
                                DataContractSerializer ser = new DataContractSerializer(typeof(Project));

                                Project project =
                                    (Project)ser.ReadObject(reader, true);
                                project.Canvas = new Bitmap(project.CanvasPath);

                                NewTab(project, project.Canvas);
                            }
                            catch (System.Xml.XmlException ex)
                            {
                                MessageBox.Show("Выбранный файл не является проектом данной программы!");
                            }
                            catch (System.IO.FileNotFoundException ex)
                            {
                                MessageBox.Show("Файл не найден!");
                            }
                            /*catch (System.Runtime.Serialization.SerializationException ex)
                            {
                                MessageBox.Show("Файл поврежден и не может быть открыт!");
                                MessageBox.Show(ex.StackTrace);
                            }*/
                            finally
                            {
                                if (reader != null) reader.Dispose();
                                fs.Close();
                            }
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Неверный формат файла!");
                            break;
                        }
                }
            }
        }

        private void NewTab(Project project, Bitmap image = null)
        {

            RemoveMask();
            TabPage tabPage = new TabPage();
            PictureBox background = new PictureBox();


            this.TabControl.Controls.Add(tabPage);

            //Tab page init
            tabPage.BackColor = System.Drawing.SystemColors.ControlDark;
            tabPage.Controls.Add(background);
            tabPage.Location = new System.Drawing.Point(4, 22);
            tabPage.Name = project.ProjectName;
            tabPage.Padding = new System.Windows.Forms.Padding(3);
            tabPage.Size = new System.Drawing.Size(898, 458);
            tabPage.TabIndex = 0;
            tabPage.Text = project.ProjectName;

            //Background init
            background.BackColor = System.Drawing.Color.White;
            background.Location = new System.Drawing.Point(0, 0);
            background.Name = project.ProjectName+"_background";
            background.Size = new System.Drawing.Size(project.ProjectWidth, project.ProjectHeight);
            if (image != null) background.BackgroundImage = image;
            else
            {
                background.BackgroundImage = new Bitmap(project.ProjectWidth, project.ProjectHeight);
                Graphics g = Graphics.FromImage(background.BackgroundImage);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, project.ProjectWidth, project.ProjectHeight);
                g.Dispose();
            }
            background.TabIndex = 0;
            background.TabStop = false;

            this.ActiveProjectView = new ProjectView(project,tabPage, background);
            Projects.Add(this.ActiveProjectView);
            AddMask();

            this.TabControl.SelectedIndex = Projects.Count - 1;

        }

        private void AddMask()
        {
            this.mask = new PictureBox();
            this.ActiveProjectView.lastLayer.Controls.Add(this.mask);
            mask.BackColor = System.Drawing.Color.Transparent;
            mask.Location = new System.Drawing.Point(0, 0);
            mask.Name = "Mask";
            mask.Size = new System.Drawing.Size(this.ActiveProjectView.projectProperties.ProjectWidth, 
                this.ActiveProjectView.projectProperties.ProjectHeight);
            mask.TabIndex = 0;
            mask.TabStop = false;
            mask.BringToFront();
            mask.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mask_MouseMove);
            mask.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mask_MouseUp);
            mask.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mask_MouseDown);
            mask.Cursor = System.Windows.Forms.Cursors.Cross;
            mask.Image = new Bitmap(this.ActiveProjectView.projectProperties.ProjectWidth,
                this.ActiveProjectView.projectProperties.ProjectHeight);
        }

        private void RemoveMask()
        {
            if (mask == null) return;
            this.ActiveProjectView.lastLayer.Controls.Remove(this.mask);
            mask.Dispose();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveMask();
            foreach (ProjectView projectView in Projects)
            {
                if (projectView.tabPage == this.TabControl.SelectedTab)
                {
                    ActiveProjectView = projectView;
                    AddMask();
                    if (!ActiveProjectView.CanBack()) BackToolStripMenuItem.Enabled = false;
                    else BackToolStripMenuItem.Enabled = true;
                    if (!ActiveProjectView.CanForward()) ForwardToolStripMenuItem.Enabled = false;
                    else ForwardToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void mask_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDownCoord = new Point(e.X,e.Y);
        }

        private void mask_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (ActiveTool)
                {
                    case Tools.BRUSH:
                        {
                            Graphics g = Graphics.FromImage(mask.Image);
                            painter.UseBrush(g, e.X, e.Y);
                            mask.Refresh();
                            g.Dispose();
                            break;
                        }
                    case Tools.ERRAISER:
                        {
                            Graphics g = Graphics.FromImage(mask.Image);
                            painter.UseErraiser(g, e.X, e.Y);
                            mask.Refresh();
                            g.Dispose();
                            break;
                        }
                    case Tools.ELLIPSE:
                        {
                            Bitmap bm = new Bitmap(mask.Size.Width, mask.Size.Height);
                            Graphics g = Graphics.FromImage(bm);
                            painter.UseEllipse(g,mouseDownCoord.X,mouseDownCoord.Y,e.X, e.Y);
                            mask.Image = bm;
                            mask.Refresh();
                            g.Dispose();
                            break;
                        }
                    case Tools.RECTANGLE:
                        {
                            Bitmap bm = new Bitmap(mask.Size.Width, mask.Size.Height);
                            Graphics g = Graphics.FromImage(bm);
                            painter.UseRectangle(g, mouseDownCoord.X, mouseDownCoord.Y, e.X, e.Y);
                            mask.Image = bm;
                            mask.Refresh();
                            g.Dispose();
                            break;
                        }
                }
            }
        }

        private void mask_MouseUp(object sender, MouseEventArgs e)
        {
            Bitmap bm = new Bitmap(mask.Image);
            mask.Image = new Bitmap(ActiveProjectView.projectProperties.ProjectWidth, ActiveProjectView.projectProperties.ProjectHeight);
            PictureBox layer = new PictureBox();
            ActiveProjectView.lastLayer.Controls.Remove(this.mask);
            layer.Controls.Add(this.mask);

            layer.BackColor = System.Drawing.Color.Transparent;
            layer.Location = new System.Drawing.Point(0, 0);
            layer.Name = ActiveProjectView.projectProperties.ProjectName + "_layer" + ActiveProjectView.nextlayerNumber;
            layer.Size = new System.Drawing.Size(ActiveProjectView.projectProperties.ProjectWidth, ActiveProjectView.projectProperties.ProjectHeight);
            layer.TabIndex = 0;
            layer.TabStop = false;
            layer.Image = bm;
            ActiveProjectView.AddLayer(layer);
            if (ForwardToolStripMenuItem.Enabled) ForwardToolStripMenuItem.Enabled = false;
            if (ActiveProjectView.CanBack() && !BackToolStripMenuItem.Enabled) BackToolStripMenuItem.Enabled = true;
            mask.BringToFront();

        }


        private void ViewbrushSizeTrackBar_Scroll(object sender, EventArgs e)
        {
            switch (ActiveTool)
            {
                case Tools.BRUSH:
                    {
                        this.painter.brush.Radius = ViewbrushSizeTrackBar.Value;
                        break;
                    }
                case Tools.ERRAISER:
                    {
                        this.painter.erraiser.Radius = ViewbrushSizeTrackBar.Value;
                        break;
                    }
                case Tools.ELLIPSE:
                    {
                        this.painter.ellipse.Thickness = ViewbrushSizeTrackBar.Value;
                        break;
                    }
                case Tools.RECTANGLE:
                    {
                        this.painter.rectangle.Thickness = ViewbrushSizeTrackBar.Value;
                        break;
                    }
            }
        }

        private void BackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveProjectView.lastLayer.Controls.Remove(this.mask);
            ActiveProjectView.Back();
            ActiveProjectView.lastLayer.Controls.Add(this.mask);
            this.mask.BringToFront();
            if (ActiveProjectView.CanBack()) BackToolStripMenuItem.Enabled = true;
            else BackToolStripMenuItem.Enabled = false;
            if (ActiveProjectView.CanForward()) ForwardToolStripMenuItem.Enabled = true;
            else ForwardToolStripMenuItem.Enabled = false;

        }

        private void ForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveProjectView.lastLayer.Controls.Remove(this.mask);
            ActiveProjectView.Forward();
            ActiveProjectView.lastLayer.Controls.Add(this.mask);
            this.mask.BringToFront();
            if (ActiveProjectView.CanForward()) ForwardToolStripMenuItem.Enabled = true;
            else ForwardToolStripMenuItem.Enabled = false;
            if (ActiveProjectView.CanBack()) BackToolStripMenuItem.Enabled = true;
            else BackToolStripMenuItem.Enabled = false;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveProjectView.MergeLayers(); 
            FileStream writer = new FileStream(ActiveProjectView.projectProperties.ProjectPath, FileMode.Create);
            DataContractSerializer ser =
                new DataContractSerializer(typeof(Project));
            ser.WriteObject(writer, ActiveProjectView.projectProperties);
            ActiveProjectView.projectProperties.Canvas.Save(ActiveProjectView.projectProperties.CanvasPath);
            writer.Close();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(dialog.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                ActiveProjectView.MergeLayers();
                Image img = ActiveProjectView.projectProperties.Canvas;
                img.Save(dialog.FileName, format);
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Projects.Remove(ActiveProjectView);
            ActiveProjectView.Dispose();
        }

        private void CloseAllВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (Projects.Count != 0)
            {
                Projects.Remove(ActiveProjectView);
                ActiveProjectView.Dispose();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }



        private class ProjectView
        {
            public Project projectProperties
            { get; private set; }

            public TabPage tabPage
            { get; private set; }

            private PictureBox background;

            public int nextlayerNumber
            { get; private set; }

            private Stack<PictureBox> visibleLayers;
            private Stack<PictureBox> hiddenLayers;

            public PictureBox lastLayer
            { get; private set; }

            public ProjectView(Project projectProperties, TabPage tabPage, PictureBox background)
            {
                this.nextlayerNumber = 0;
                this.projectProperties = projectProperties;
                this.tabPage = tabPage;
                visibleLayers = new Stack<PictureBox>();
                hiddenLayers = new Stack<PictureBox>();
                this.background = background;
                this.lastLayer = background;
            }

            public void AddLayer(PictureBox layer)
            {
                RemoveHiddenLayers();
                lastLayer.Controls.Add(layer);
                visibleLayers.Push(layer);
                lastLayer = layer;
                this.nextlayerNumber++;
            }

            private void RemoveHiddenLayers()
            {
                if (hiddenLayers.Count == 0) return;
                lastLayer.Controls.Remove(hiddenLayers.Peek());
                while (hiddenLayers.Count != 1)
                {
                    PictureBox layer = hiddenLayers.Pop();
                    layer.Controls.Remove(hiddenLayers.Peek());
                    layer.Dispose();
                }
                hiddenLayers.Pop().Dispose();

            }

            public void Back()
            {
                hiddenLayers.Push(visibleLayers.Pop());
                hiddenLayers.Peek().Hide();
                if (CanBack()) lastLayer = visibleLayers.Peek();
                else lastLayer = background;
            }

            public bool CanBack()
            {
                if (visibleLayers.Count == 0) return false;
                return true;
            }

            public void Forward()
            {
                visibleLayers.Push(hiddenLayers.Pop());
                visibleLayers.Peek().Show();
                lastLayer = visibleLayers.Peek();
            }

            public bool CanForward()
            {
                if (hiddenLayers.Count == 0) return false;
                return true;
            }

            public void MergeLayers()
            {
                Bitmap newCanvas = new Bitmap(background.ClientSize.Width, background.ClientSize.Height);
                Graphics g = Graphics.FromImage(newCanvas);
                PictureBox[] visibleLayersArr = visibleLayers.ToArray();
                g.DrawImage(background.BackgroundImage, new Point(0, 0));
                for (int i = visibleLayers.Count - 1; i >= 0; i--)
                {
                    g.DrawImage(visibleLayersArr[i].Image, new Point(0, 0));
                }
                g.Dispose();
                projectProperties.Canvas = newCanvas;
            }

            public void Dispose()
            {
                lastLayer.Dispose();
                if (projectProperties.Canvas!=null) projectProperties.Canvas.Dispose();
                while (hiddenLayers.Count != 0)
                    hiddenLayers.Pop().Dispose();
                while (visibleLayers.Count != 0)
                    visibleLayers.Pop().Dispose();
                tabPage.Dispose();
            }
        }

        private enum Tools
        {
            BRUSH,
            ELLIPSE,
            RECTANGLE,
            ERRAISER
        }

        private void BrushButton_Click(object sender, EventArgs e)
        {
            ActiveTool = Tools.BRUSH;
            ViewbrushSizeTrackBar.Value = painter.brush.Radius;
        }

        private void EllipseButton_Click(object sender, EventArgs e)
        {
            ActiveTool = Tools.ELLIPSE;
            ViewbrushSizeTrackBar.Value = painter.ellipse.Thickness;
        }

        private void RecButton_Click(object sender, EventArgs e)
        {
            ActiveTool = Tools.RECTANGLE;
            ViewbrushSizeTrackBar.Value = painter.rectangle.Thickness;
        }

        private void ErraserButton_Click(object sender, EventArgs e)
        {
            ActiveTool = Tools.ERRAISER;
            ViewbrushSizeTrackBar.Value = painter.erraiser.Radius;
        }

        private void BrushSizeButton_Click(object sender, EventArgs e)
        {
            if (!BrushSizeSwitcherFlag)
            {
                ChangeBrushSizePanel.Show();
                BrushSizeSwitcherFlag = true;
            }
            else
            {
                ChangeBrushSizePanel.Hide();
                BrushSizeSwitcherFlag = false;
            }

        }
    }
}
