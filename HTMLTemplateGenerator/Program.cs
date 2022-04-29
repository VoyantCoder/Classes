
// Author: Dashie


using System.IO;
using System.Text;


namespace HTMLTemplateGenerator
{
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
                "", 
                new string[] { },
                new string[] { },
                new string[] { }
            ).Source;

            string html2 = t.GenerateREADME2(
                "",
                new string[] { },
                new string[] { },
                new string[] { },
                new string[] { },
                new string[] { }
            ).Source;

            File.WriteAllText("html1.html", html1);
            File.WriteAllText("html2.html", html2);
        }
    }
}
