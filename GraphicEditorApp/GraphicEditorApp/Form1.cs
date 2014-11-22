using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private Bitmap maskCanvas;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Projects = new List<ProjectView>();
            ColorButton.BackColor = Color.Black;
            ActiveTool = Tools.BRUSH;
            painter = new Painter(ColorButton.BackColor);
        }

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


        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newProjectForm = new NewProjectForm();
            newProjectForm.ShowDialog();
            if (newProjectForm.project != null) NewTab(newProjectForm.project);
            newProjectForm.Dispose();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "D:\\Works\\Temp\\";
            if (dialog.ShowDialog() == DialogResult.OK)
            {

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
            if (image != null) background.Image = image;
            background.Location = new System.Drawing.Point(0, 0);
            background.Name = project.ProjectName+"_background";
            background.Size = new System.Drawing.Size(project.ProjectWidth, project.ProjectHeight);
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
            mask.Size = new System.Drawing.Size(this.ActiveProjectView.projectProperties.ProjectWidth - 20, 
                this.ActiveProjectView.projectProperties.ProjectHeight - 20);
            mask.TabIndex = 0;
            mask.TabStop = false;
            mask.BringToFront();
            mask.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mask_MouseMove);
            mask.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mask_MouseUp);
            mask.Cursor = System.Windows.Forms.Cursors.Cross;
            this.maskCanvas = new Bitmap(this.ActiveProjectView.projectProperties.ProjectWidth - 20,
                this.ActiveProjectView.projectProperties.ProjectHeight - 20);
            mask.Image = maskCanvas;
            MessageBox.Show("Mask added to " + this.ActiveProjectView.tabPage.Name);
        }

        private void RemoveMask()
        {
            if (mask == null) return;
            this.ActiveProjectView.lastLayer.Controls.Remove(this.mask);
            MessageBox.Show("Mask removed from " + this.ActiveProjectView.tabPage.Name);
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
                }
            }
        }

        private void mask_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Bitmap bm = new Bitmap(mask.Image);
                Graphics g = Graphics.FromImage(bm);
                painter.UseBrush(g, e.X, e.Y);
                mask.Image = bm;;
                g.Dispose();
            }
        }

        private void mask_MouseUp(object sender, MouseEventArgs e)
        {
            Bitmap bm = new Bitmap(mask.Image);
            mask.Image = new Bitmap(ActiveProjectView.projectProperties.ProjectWidth, ActiveProjectView.projectProperties.ProjectHeight);
            PictureBox layer = new PictureBox();
            ActiveProjectView.lastLayer.Controls.Remove(this.mask);
            layer.Controls.Add(this.mask);
            ActiveProjectView.lastLayer.Controls.Add(layer);

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

        private class ProjectView
        {
            public Project projectProperties
            {get; private set;}

            public TabPage tabPage
            {get; private set;}

            private PictureBox background;

            public int nextlayerNumber
            {get; private set;}

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
                for (int i = visibleLayers.Count-1; i >= 0; i--)
                {
                    g.DrawImage(visibleLayersArr[i].Image,new Point(0,0));
                }
                g.Dispose();
                projectProperties.Canvas = newCanvas;
            }
        }


        private enum Tools
        {
            BRUSH,
            ELLIPSE,
            RECTANGULAR,
            ERRAISER
        }

        private void ViewbrushSizeTrackBar_Scroll(object sender, EventArgs e)
        {
            this.painter.brush.Radius = ViewbrushSizeTrackBar.Value;
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
            writer.Close();
        }


        /*public static void ReadObject(string fileName)
        {
            Console.WriteLine("Deserializing an instance of the object.");
            FileStream fs = new FileStream(fileName,
            FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(Person));

            // Deserialize the data and read it from the instance.
            Person deserializedPerson =
                (Person)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();
            Console.WriteLine(String.Format("{0} {1}, ID: {2}",
            deserializedPerson.FirstName, deserializedPerson.LastName,
            deserializedPerson.ID));
        }*/
    }
}
