using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, string[] fieldsToInvestigate)
        {
            StringBuilder sb = new StringBuilder();
            Type type = Type.GetType(className);
            sb.AppendLine($"Class under investigation: {type.FullName}");
            Object instance = Activator.CreateInstance(type, new string[] { });
            FieldInfo[] requestedFields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (FieldInfo field in requestedFields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }
            return sb.ToString().TrimEnd();
        }
        

        
    }
}
