using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public interface ICommandInterpreter
    {
        public void Read(string args);
    }
}
