using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
   public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {

        }
        public void Run()
        {
            
        }
    }
}
