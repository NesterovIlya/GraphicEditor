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

        public Tools.Erraiser erraiser
        { get; private set; }

        public Tools.Ellipse ellipse
        { get; private set; }

        public Color color
        { get; set; }

        public Painter(Color color, int size)
        {
            this.color = color;
            brush = new Tools.Brush(size);
            erraiser = new Tools.Erraiser(size);
            ellipse = new Tools.Ellipse(size);
        }

        public void UseBrush(Graphics g, int mousePositionX, int mousePositionY)
        {
            brush.Draw(g,mousePositionX,mousePositionY,color);
        }

        public void UseErraiser(Graphics g, int mousePositionX, int mousePositionY)
        {
            erraiser.Draw(g, mousePositionX, mousePositionY);
        }

        public void UseEllipse(Graphics g, int mouseDownPositionX, int mouseDownPositionY, int mouseUpPositionX, int mouseUpPositionY)
        {
            //ellipse.Draw(g, mousePositionX, mousePositionY);
        }
    }
}
