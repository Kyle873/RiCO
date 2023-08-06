using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RiCO;

public static class Utils
{
    const string IndentString = "    ";
    
    public static string FormatJson(string str)
    {
        int indent = 0;
        bool quoted = false;
        StringBuilder sb = new StringBuilder();
        
        for (int i = 0; i < str.Length; i++)
        {
            char ch = str[i];
            switch (ch)
            {
                case '{':
                case '[':
                    sb.Append(ch);
                    if (!quoted)
                    {
                        
                        sb.AppendLine();
                        Enumerable.Range(0, ++indent).ToList().ForEach(item => sb.Append(IndentString));
                    }
                    break;
                case '}':
                case ']':
                    if (!quoted)
                    {
                        sb.AppendLine();
                        Enumerable.Range(0, --indent).ToList().ForEach(item => sb.Append(IndentString));
                    }
                    sb.Append(ch);
                    break;
                case '"':
                    sb.Append(ch);
                    bool escaped = false;
                    var index = i;
                    while (index > 0 && str[--index] == '\\')
                        escaped = !escaped;
                    if (!escaped)
                        quoted = !quoted;
                    break;
                case ',':
                    sb.Append(ch);
                    if (!quoted)
                    {
                        sb.AppendLine();
                        Enumerable.Range(0, indent).ToList().ForEach(item => sb.Append(IndentString));
                    }
                    break;
                case ':':
                    sb.Append(ch);
                    if (!quoted)
                        sb.Append(" ");
                    break;
                default:
                    sb.Append(ch);
                    break;
            }
        }

        return sb.ToString();
    }
    
    public static StringBuilder LogObject<T>(T obj, bool output = true)
    {
        Type type = obj.GetType();
        StringBuilder text = new StringBuilder();

        if (output)
        {
            text.AppendLine($"\n\tFields of {type.Name}:");
            text.AppendLine($"========================================");
        }

        if (obj is IEnumerable enumerable)
        {
            int index = 0;
            foreach (object item in enumerable)
                text.AppendLine($"\t[{index++}]: {item}");
        }
        else
        {
            foreach (FieldInfo field in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                object value = field.GetValue(obj);
                text.AppendLine($"\t{field.Name}: {value}");
            }
        }

        if (output)
            RiCO.Log.LogMessage(text);

        return text;
    }
}
