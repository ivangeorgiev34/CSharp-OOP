using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public void Read(string args)
        {
            string[] tokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = tokens[0];
            string[] cmdArgs = tokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type cmdType = assembly.GetTypes().FirstOrDefault(t => t.Name == $"{commandName}Command");
            if (cmdType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }
            object cmdInstance = Activator.CreateInstance(cmdType);
            ICommand command;
            if (args == "HelloCommand")
            {
                command = new HelloCommand();
                
            }
            else if (args == "ExitCommand")
            {
                command = new ExitCommand();
            }
        }
    }
}
