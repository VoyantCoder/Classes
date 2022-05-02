
// Author: Dashie


using System.Text;


// Summary: This section deals with generated parsed text.

namespace HTMLTempler
{
    public partial class HTMLParser
    { 
        private static string[] contents = null;

        public static string Generate(HTMLParseType type, params string[] text)
        {
            contents = text;

            if (contents.Length < 1)
            {
                return null;
            }

            return type switch
            {
                HTMLParseType.H2Title => ParseH2Title(),
                HTMLParseType.H4Summary => ParseH4Summary(),
                HTMLParseType.PDesc => ParsePDesc(),
                HTMLParseType.PLastWords => ParsePLastWords(),
                HTMLParseType.PTableDesc => ParsePTableDesc(),
                HTMLParseType.TableRows => ParseTableRows(),
                HTMLParseType.TableColumns => ParseTableColumns(),
                _ => null
            };
        }
    }
}