
// Author: Dashie


using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace HTMLTemplateGenerator
{
    public enum HTMLGenType
    {
        H2Title, H4Summary, PDescription, PLastWords,
        PTableDescription, TableRows, TableColumns, 
    }

    public class HTMLParser
    {
        private static string[] GenTitle(string content) 
        {
            return new string[]
            {
                $"{content}"
            };
        }
        
        private static string[] GenSummary(string[] contents) 
        {
            return new string[]
            {
                $"<h4>",
                $"  {string.Join("\r\n", contents)}",
                $"</h4>",
            };
        }
        
        private static string[] GenDescription(string[] contents) 
        {
            if (contents.Length > 0)
            {
                contents[0] = "<p>\r\n    ";

                contents = contents.Select
                (
                    a => "    " + a
                    .Replace
                    (
                        " ", "</br></br>"
                    )
                    .Replace
                    (
                        "\r\n", "</br></br>"
                    )
                )
                .Append
                (
                    "</p>"
                ).ToArray();
            }

            return contents;
        }
        
        private static string[] GenLastWords(string[] contents) 
        {
            if (contents.Length > 0)
            {
                contents[0] = "<p>\r\n    ";

                contents = contents.Select
                (
                    a => "    " + a
                    .Replace
                    (
                        "\r\n", "</br></br>"
                    )
                )
                .Append
                (
                    "</p>"
                ).ToArray();
            }

            return contents;
        }
        
        private static string[] GenTableDescription(string[] contents) 
        {
            return new string[]
            {
                "<p>",
                string.Join("\r\n", contents)
                    .Replace
                    (
                        "\r\n", "</br></br>"
                    ),
                "</p>"
            };
        }
        
        private static string[] GenTableRows(string[] contents)
        {
            return new string[]
            {

            };
        }

        private static string[] GenTableColumns(string[] contents)
        {
            return new string[]
            {

            };
        }

        public static string[] Generate(HTMLGenType type, params string[] contents)
        {
            return type switch
            {
                HTMLGenType.H2Title => GenTitle(),
                HTMLGenType.H4Summary => GenSummary(),
                HTMLGenType.PDescription => GenDescription(),
                HTMLGenType.PLastWords => GenLastWords(),
                HTMLGenType.PTableDescription => GenTableDescription(),
                HTMLGenType.TableRows => GenTableRows(),
                HTMLGenType.TableColumns => GenTableColumns(),
            };
        }
    }

    public class HTML
    {
        public string Source { get; set; } = string.Empty;
        public void SetSource(StringBuilder builder) => Source = builder.ToString();
    }
    
    public partial class HTMLTemplates
    {
        public HTML GenerateREADME1(string h2Title, string[] h4Summary, string[] pDescription, string[] pLastWords)
        {
            // Information based README

            return new HTML();
        }

        public HTML GenerateREADME2(string h2Title, string[] h4Summary, string[] pTableDescription, string[] tableRows, string[] tableColumns, string[] pLastWords)
        {
            // Table based README

            return new HTML();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            HTMLTemplates t = new();

            string html1 = t.GenerateREADME1(
                // TITLE
                "",
                // SUMMARY
                new string[] { },
                // DESCRIPTION
                new string[] { },
                // LAST WORDS
                new string[] { }
            ).Source;

            string html2 = t.GenerateREADME2(
                // TITLE
                "",
                // SUMMARY
                new string[] { },
                // TABLE DESCRIPTION
                new string[] { },
                // TABLE ROWS
                new string[] { },
                // TABLE COLUMNS
                new string[] { },
                // LAST WORDS
                new string[] { }
            ).Source;

            if (!File.Exists("html1.html"))
            {
                File.WriteAllText("html1.html", html1);
                File.WriteAllText("html2.html", html2);
            }
        }
    }
}
