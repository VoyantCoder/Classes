
// Author: Dashie


using static System.Console;
using static System.IO.Directory;


namespace VideoHelper
{
    public partial class VideoHelperAPI
    {

    }

    public class Program
    {
        static void Main(string[] args)
        {
            VideoHelperAPI api = new();

            WriteLine(string.Join(", ", api.ListAlbums(".")));

            WriteLine(api.RenameAlbum("./", "dashieee", "DaShIeEBanschee"));

            WriteLine(string.Join(", ", api.ListAlbums(".")));
        }
    }
}
