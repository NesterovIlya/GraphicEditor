using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicEditorApp.Model
{
    public class Project
    {
        public string ProjectName
        { get; private set; }

        public int ProjectWidth
        { get; private set; }

        public int ProjectHeight
        { get; private set; }

        public string ProjectPath
        { get; private set; }

        public Bitmap Canvas
        { get; private set; }

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

    public class ProjectComparer : IEqualityComparer<Project>
    {
        public bool Equals(Project project1, Project project2)
        {
            if (project1.ProjectName.Equals(project2.ProjectName)) return true;
            else return false;
        }

        public int GetHashCode(Project project)
        {
            return project.ProjectName.GetHashCode();
        }
    }
}
