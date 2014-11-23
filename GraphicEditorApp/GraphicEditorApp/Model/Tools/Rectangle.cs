using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace GraphicEditorApp.Model.Tools
{
    public class Rectangle
    {
        Pen pen = new Pen(Color.Black,1);
        public int Thickness
        { get
          {
              return (int)pen.Width;
          }
          set
          {
              pen.Width = value;
          }
        }

        public Rectangle(int thickness)
        {
            pen.Width = thickness;
        }

        public void Draw(Graphics gr, int MousePositionX, int MousePositionY, Color color, int width, int height)
        {
            pen.Color = color;
            if (width < 3 || height < 3) return;
            gr.DrawRectangle(pen, new System.Drawing.Rectangle(Math.Abs(MousePositionX), Math.Abs(MousePositionY), Math.Abs(width), Math.Abs(height)));
        }
    }
}
