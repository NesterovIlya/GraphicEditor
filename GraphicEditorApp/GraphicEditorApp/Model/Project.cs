using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;
using System.Xml;

namespace GraphicEditorApp.Model
{
    [DataContract(Name = "Project")]
    public class Project
    {
        [DataMember(Name = "Name")]
        public string ProjectName
        { get; private set; }

        [DataMember(Name = "Width")]
        public int ProjectWidth
        { get; private set; }

        [DataMember(Name = "Height")]
        public int ProjectHeight
        { get; private set; }

        [DataMember(Name = "Path")]
        public string ProjectPath
        { get; private set; }

        [DataMember(Name = "Canvas")]
        public Bitmap Canvas
        { get; set; }

        public Project()
        {
        }

        public Project(string name, int width, int height, string path)
        {
            ProjectName = name;
            ProjectWidth = width;
            ProjectHeight = height;
            ProjectPath = path;
        }
    }
}
