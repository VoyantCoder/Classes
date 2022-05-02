
// Author: Dashie


using System.Text;


// Summary: This is one of the generator modules.

namespace HTMLTempler
{
    public partial class HTMLParser
    {
        private static string ParsePDesc()
        {
            StringBuilder result = new();

            void Append(params string[] texts)
            {
                foreach (string text in texts)
                {
                    result.Append(text + "\r\n");
                }
            }

            Append("</br>");
            Append("<p>");

            foreach (string content in contents)
            {
                if (content == "\r\n" || content == "")
                {
                    Append("</p>", "<p>");
                }

                Append($"{Indent}{content}");
            }

            Append("</p>");

            return result.ToString();
        }
    }
}