using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace GraphicEditorApp.Model.Tools
{
    public class Erraiser
    {
        SolidBrush solidBrush = new SolidBrush(Color.White);

        public int Radius
        { get; set; }

        public Erraiser(int radius)
        {
            Radius = radius;
        }

        public void Draw(Graphics gr, int MousePositionX, int MousePositionY)
        {
            gr.FillRectangle(solidBrush, MousePositionX - Radius, MousePositionY - Radius, 2 * Radius, 2 * Radius);
        }

    }
}
