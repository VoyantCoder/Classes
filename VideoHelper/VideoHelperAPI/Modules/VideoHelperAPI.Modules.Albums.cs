
// Author: Dashie


using System.Linq;
using System.Diagnostics;
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
                return Exists($@"{workspace}\{name}") && Exists($@"{workspace}\{name}\rendered");
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

        public string GetAlbumPath(string workspace, string album)
        {
            return AlbumExists(workspace, album) ? $@"{workspace}\{album}" : VideoHelperResult.AlbumDoesNotExist.ToString();
        }

        public string GetAlbumPath(string album) => GetAlbumPath(workspace, album);

        public VideoHelperResult OpenAlbumInExplorer(string workspace, string album)
        {
            if (AlbumExists(workspace, album))
            {
                using (Process process = new())
                {
                    process.StartInfo = new()
                    {
                        UseShellExecute = true,
                        FileName = GetAlbumPath(workspace, album),
                    };

                    process.Start();

                }

                return VideoHelperResult.Success;
            }

            return VideoHelperResult.AlbumDoesNotExist;
        }

        public VideoHelperResult OpenAlbumInExplorer(string album) => OpenAlbumInExplorer(workspace, album);
    }
}