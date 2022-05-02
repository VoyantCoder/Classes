
// Author: Dashie


using System.Text;


// Summary: This is one of the generator modules.

namespace HTMLTempler
{
    public partial class HTMLParser
    {

        private static string ParseTableColumns()
        {
            StringBuilder result = new();

            void Append(params string[] texts)
            {
                foreach (string text in texts)
                {
                    result.Append(text + "\r\n");
                }
            }

            Append("<tr>");

            foreach (string content in contents)
            {
                if (content == "\r\n" || content == "")
                {
                    Append("</tr>", "<tr>");
                }

                Append($"{Indent}<td> {content} </td>");
            }

            Append("</tr>");

            return result.ToString();
        }
    }
}