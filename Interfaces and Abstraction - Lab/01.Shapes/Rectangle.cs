using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;

        private int height;
        public Rectangle(int width,int height)
        {
            Width = width;
            Height = height;
        }
        public int Height
        {
            get { return height; }
            private set { height = value; }
        }

        public int Width
        {
            get { return width; }
            private set { width = value; }
        }

        public void Draw()
        {
            DrawLine(width, '*', '*');
            for (int i = 1; i < height-1; ++i)
            {
                DrawLine(width, '*', ' ');
            }
            DrawLine(width, '*', '*');
        }
        private void DrawLine(int iwdth,char end ,char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width-1; ++i)
            {
                Console.Write(mid);

            }
            Console.WriteLine(end);
        }
    }
}
