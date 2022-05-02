
// Author: Dashie


// Summary: This is one of the generator modules.

namespace HTMLTempler
{
    public partial class HTMLParser
    {
        private static string ParseH2Title()
        {
            return $@"{(contents.Length > 0 ? contents[0] : "none")}";
        }
    }
}