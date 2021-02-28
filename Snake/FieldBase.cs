using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    abstract class FieldBase
    {
        public char overField;
        public Point offset;

        public FieldBase()
        {
            overField = ' ';
            offset = new Point(0, 0);
        }

        public FieldBase(char overField, Point offset)
        {
            this.overField = overField;
            this.offset = offset;
        }

        public abstract char GetChar(Point point);
        public abstract char GetChar(Point point, Point offset);

    }
}
