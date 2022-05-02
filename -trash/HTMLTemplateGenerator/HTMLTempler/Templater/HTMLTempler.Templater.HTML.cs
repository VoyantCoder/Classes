
// Author: Dashie


using System.Text;


// Summary: This section deals with the HTML 'data' type. It basically deals with the source code returned by the methods that parse the by you provided text.

namespace HTMLTempler
{
    public class HTML
    {
        public string Source { get; set; } = string.Empty;
        public void SetSource(StringBuilder source) => Source = source.ToString();
        public HTML(StringBuilder source) => SetSource(source);
    }
}