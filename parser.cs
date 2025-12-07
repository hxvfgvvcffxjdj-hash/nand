using System;
using System.Collections.Generic;
using System.Linq;

namespace Assembler
{
    public class Parser
    {
        public string[] RemoveWhitespacesAndComments(string[] asmLines)
        {
            var result = new List<string>();
            foreach (var line in asmLines)
            {
                if (line == null) continue;
                string withoutComments = line;
                int commentIndex = line.IndexOf("//");
                if (commentIndex >= 0)
                {
                    withoutComments = line.Substring(0, commentIndex);
                }
                string trimmed = new string(withoutComments.Where(c => !char.IsWhiteSpace(c)).ToArray());
                if (!string.IsNullOrEmpty(trimmed))
                {
                    result.Add(trimmed);
                }
            }
            return result.ToArray();
        }
    }
}
