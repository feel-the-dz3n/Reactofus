using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Reactofus
{
    public class INIParser
    {
        string[] rows;

        public List<INISection> Sections = new List<INISection>();

        public INISection GetSection(string name)
            => Sections.First(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public INIParser(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
                rows = r.ReadToEnd().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            INISection CurrentSection = null;

            for (int i = 0; i < rows.Length; i++)
            {
                var row = rows[i];

                if(row.StartsWith("[") && row.EndsWith("]"))
                {
                    CurrentSection = new INISection(row.Trim(new char[] { '[', ']' }));
                    Sections.Add(CurrentSection);
                }

                if (row.StartsWith(";")) continue;

                if (row.Contains("="))
                {
                    // FIX ME: will work when only one =
                    CurrentSection.Values.Add(new INIValues(row.Split('=')[0].Trim(), row.Split('=')[1].Trim().Trim(new char[] { '"' })));
                }
            }
        }
    }

    public class INISection
    {
        public string Name { get; private set; }
        public List<INIValues> Values = new List<INIValues>();

        public INISection(string name) => Name = name;
    }

    public class INIValues
    {
        public string Name;
        public string Value;

        public INIValues(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
