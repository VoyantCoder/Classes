
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
        private static string GenTitle() 
        {
            return $@"{(contents.Length > 0 ? contents[0] : "none")}";
        }
        
        private static string GenSummary() 
        {
            // <h4>
            //      Text
            // </h4>
            // <h4>
            //      More text
            // </h4>
            return string.Empty;
        }
        
        private static string GenDescription() 
        {
            // </br>
            // <p>
            //  <b> 
            //      Description
            //  </b>
            // </p>
            // <p>
            //      Text
            // </p>
            // <p>
            //      More text
            // </p>
            return string.Empty;
        }
        
        private static string GenLastWords() 
        {
            // <p>
            //      Last Words
            // </p>
            // <p>
            //      More words;l
            // </p>
            return string.Empty;
        }
        
        private static string GenTableDescription() 
        {
            // <p> 
            //      Text
            // </p>
            return string.Empty;
        }
        
        private static string GenTableRows()
        {
            // <table>
            //  <tr>
            //      <th> Row1 </th>
            //      <th> Row2 </th>
            //      <th> Row3 </th>
            //  </tr>
            // </table>
            return string.Empty;
        }

        private static string GenTableColumns()
        {
            // <tr>
            //      <td> Row1 </td> 
            //      <td> Row2 </td>
            //      <td> Row3 </td>
            // </tr>
            return string.Empty;
        }

        private static string[] contents = null;

        public static string Generate(HTMLGenType type, params string[] text)
        {
            contents = text;

            if (contents.Length < 1)
            {
                return null;
            }

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
                HTMLParser.Generate(HTMLGenType.H2Title, ""),
                // SUMMARY
                new string[] 
                { 
                    HTMLParser.Generate(HTMLGenType.H4Summary, "")
                },
                // DESCRIPTION
                new string[] 
                { 
                    HTMLParser.Generate(HTMLGenType.PDescription, "")
                },
                // LAST WORDS
                new string[] 
                {
                    HTMLParser.Generate(HTMLGenType.PLastWords, "")
                }
            ).Source;

            string html2 = t.GenerateREADME2(
                // TITLE
                HTMLParser.Generate(HTMLGenType.H2Title, ""),
                // SUMMARY
                new string[] 
                { 
                    HTMLParser.Generate(HTMLGenType.H4Summary, "")
                },
                // TABLE DESCRIPTION
                new string[] 
                { 
                    HTMLParser.Generate(HTMLGenType.PTableDescription, "")
                },
                // TABLE ROWS
                new string[] 
                {
                    HTMLParser.Generate(HTMLGenType.TableRows, "")
                },
                // TABLE COLUMNS
                new string[] 
                {
                    HTMLParser.Generate(HTMLGenType.TableColumns, "")
                },
                // LAST WORDS
                new string[] 
                {
                    HTMLParser.Generate(HTMLGenType.PLastWords, "")
                }
            ).Source;

            if (!File.Exists("html1.html"))
            {
                File.WriteAllText("html1.html", html1);
                File.WriteAllText("html2.html", html2);
            }
        }
    }
}
