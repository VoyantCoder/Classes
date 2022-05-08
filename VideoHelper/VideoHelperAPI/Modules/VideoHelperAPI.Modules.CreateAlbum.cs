
// Author: Dashie


using static System.IO.Directory;


namespace VideoHelper
{
    public partial class VideoHelperAPI
    {
        public VideoHelperResult CreateAlbum(string name, string workspace)
        {
            try
            {
                if (!ValidateWorkspace(workspace) || AlbumExists(name))
                {
                    return VideoHelperResult.WorkspaceIsInvalid;
                }

                var paths = new[]
                {
                    $@"{workspace}\{name}",
                    $@"{workspace}\{name}\rendered"
                };

                foreach (string path in paths)
                {
                    if (Exists(path))
                    {
                        return VideoHelperResult.DirectoryAlreadyExists;
                    }

                    CreateDirectory(path);
                }
            }

            catch
            {
                return VideoHelperResult.UnhandledCreationError;
            }

            return VideoHelperResult.Success;
        }

        public void CreateAlbum(string name) => CreateAlbum(name, workspace);
    }
}