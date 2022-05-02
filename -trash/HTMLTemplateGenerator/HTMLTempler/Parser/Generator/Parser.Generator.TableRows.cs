
// Author: Dashie


using System.Text;


// Summary: This is one of the generator modules.

namespace HTMLTempler
{
    public partial class HTMLParser
    {
        private static string ParseTableRows()
        {
            StringBuilder result = new();

            foreach (string content in contents)
            {
                result.Append($"<th> {content} </th>\r\n");
            }

            return result.ToString();
        }
    }
}