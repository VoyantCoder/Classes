
// Author: Dashie


// Summary: This section deals with the construction of predefined HTML Templates.

namespace HTMLTempler
{
    public partial class Templater
    {
        public HTML GenerateREADME1(string h2Title, string h4Summary, string pDescription, string pLastWords)
        {
            // Information based README

            return new HTML(new(""));
        }

        public HTML GenerateREADME2(string h2Title, string h4Summary, string pTableDescription, string tableRows, string tableColumns, string pLastWords)
        {
            // Table based README

            return new HTML(new(""));
        }
    }
}