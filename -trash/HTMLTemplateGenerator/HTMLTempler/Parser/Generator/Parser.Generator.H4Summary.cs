
// Author: Dashie


using System.Text;


// Summary: This is one of the generator modules.

namespace HTMLTempler
{
    public partial class HTMLParser
    {
        private static string ParseH4Summary()
        {
            StringBuilder result = new();

            void Append(params string[] texts)
            {
                foreach (string text in texts)
                {
                    result.Append(text + "\r\n");
                }
            }

            Append("<h4>");

            foreach (string content in contents)
            {
                if (content == "\r\n" || content == "")
                {
                    Append("</h4>", "<h4>");
                }

                Append($"{Indent}{content}");
            }

            Append("</h4>");

            return result.ToString();
        }
    }
}