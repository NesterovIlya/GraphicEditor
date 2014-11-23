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

        public Tools.Rectangle rectangle
        { get; private set; }

        public Color color
        { get; set; }

        public Painter(Color color, int size)
        {
            this.color = color;
            brush = new Tools.Brush(size);
            erraiser = new Tools.Erraiser(size);
            ellipse = new Tools.Ellipse(size);
            rectangle = new Tools.Rectangle(size);
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
            if (mouseDownPositionX > mouseUpPositionX)
            {
                if (mouseDownPositionY > mouseUpPositionY)
                {
                    ellipse.Draw(g, mouseUpPositionX, mouseUpPositionY, color, mouseDownPositionX - mouseUpPositionX, mouseDownPositionY - mouseUpPositionY);
                }
                else
                {
                    ellipse.Draw(g, mouseUpPositionX, mouseDownPositionY, color, mouseDownPositionX - mouseUpPositionX, mouseUpPositionY - mouseDownPositionY);
                }
            }
            else
            {
                if (mouseDownPositionY > mouseUpPositionY)
                {
                    ellipse.Draw(g, mouseDownPositionX, mouseUpPositionY, color, mouseUpPositionX - mouseDownPositionX, mouseDownPositionY - mouseUpPositionY);
                }
                else
                {
                    ellipse.Draw(g, mouseDownPositionX, mouseDownPositionY, color, mouseUpPositionX - mouseDownPositionX, mouseUpPositionY - mouseDownPositionY);
                }
            }
        }

        public void UseRectangle(Graphics g, int mouseDownPositionX, int mouseDownPositionY, int mouseUpPositionX, int mouseUpPositionY)
        {
            if (mouseDownPositionX > mouseUpPositionX)
            {
                if (mouseDownPositionY > mouseUpPositionY)
                {
                    rectangle.Draw(g, mouseUpPositionX, mouseUpPositionY, color, mouseDownPositionX - mouseUpPositionX, mouseDownPositionY - mouseUpPositionY);
                }
                else
                {
                    rectangle.Draw(g, mouseUpPositionX, mouseDownPositionY, color, mouseDownPositionX - mouseUpPositionX, mouseUpPositionY - mouseDownPositionY);
                }
            }
            else
            {
                if (mouseDownPositionY > mouseUpPositionY)
                {
                    rectangle.Draw(g, mouseDownPositionX, mouseUpPositionY, color, mouseUpPositionX - mouseDownPositionX, mouseDownPositionY - mouseUpPositionY);
                }
                else
                {
                    rectangle.Draw(g, mouseDownPositionX, mouseDownPositionY, color, mouseUpPositionX - mouseDownPositionX, mouseUpPositionY - mouseDownPositionY);
                }
            }
        }
    }
}
