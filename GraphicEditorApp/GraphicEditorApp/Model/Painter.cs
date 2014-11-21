using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicEditorApp.Model
{
    public class Painter
    {
        public Tools.Brush brush
        { get; private set; }

        public Color color
        { get; set; }

        public Painter(Color color)
        {
            this.color = color;
            brush = new Tools.Brush(6);
        }

        public void UseBrush(Graphics g, int mousePositionX, int mousePositionY)
        {
            brush.Draw(g,mousePositionX,mousePositionY,color);
        }

    }
}
