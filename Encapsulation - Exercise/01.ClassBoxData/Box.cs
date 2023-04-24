using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Box
    {
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        private double length;
        public double Length
        {
            get { return length; }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                length = value;
            }
        }
        private double width;
        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        private double height;
        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                height = value;
            }
        }
        public double SurfaceArea()
        {
            return 2 * (Length * Width + Length * Height + Width * Height);
        }
        public double LateralSurfaceArea()
        {
            return 2 * (Length * Height + Width * Height);
        }
        public double Volume()
        {
            return Width * Length * Height;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {Volume():f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
