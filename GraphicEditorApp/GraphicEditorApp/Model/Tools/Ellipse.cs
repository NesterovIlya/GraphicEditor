using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace GraphicEditorApp.Model.Tools
{
    public class Ellipse
    {
        Pen pen = new Pen(Color.White,1);
        public int Thickness
        { get; 
          set
          {
              pen.Width = value;
          }
        }

        public Ellipse(int thickness)
        {
            pen.Width = thickness;
        }

        public void Draw(Graphics gr, int MousePositionX, int MousePositionY, Color color, int width, int height)
        {
            pen.Color = color;
            gr.DrawEllipse(pen, MousePositionX, MousePositionY, width, height);
        }
    }
}
