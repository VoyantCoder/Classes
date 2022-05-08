
// Author: Dashie


using System.Linq;
using System.Collections.Generic;
using static System.IO.Directory;


namespace VideoHelper
{
    public partial class VideoHelperAPI
    {
        public bool AlbumExists(string workspace, string name)
        {
            if (ValidateWorkspace(workspace))
            {
                return Exists($@"{workspace}\{name}");
            }

            return false;
        }

        public bool AlbumExists(string name) => AlbumExists(workspace, name);

        public string[] ListAlbums(string workspace)
        {
            if (ValidateWorkspace(workspace))
            {
                IEnumerable<string> Albums()
                {
                    foreach (string directory in GetDirectories(workspace))
                    {
                        if (Exists($@"{directory}\rendered"))
                        {
                            yield return directory.StartsWith("./") ? directory.Replace("./", "") : directory.Split('\\').Last();
                        }
                    }
                }

                return Albums().ToArray();
            }

            return new[] 
            { 
                VideoHelperResult.WorkspaceDoesNotExist.ToString()
            };
        }

        public string[] ListAlbums() => ListAlbums(workspace);
    }
}