
// Author: Dashie


using static System.IO.Directory;


namespace VideoHelper
{
    public partial class VideoHelperAPI
    {
        public VideoHelperResult RenameAlbum(string workspace, string album, string newName)
        {// LEFT OFF AT EXPLANATION WHAT YOU ADDED (RenameAlbum and Additionalities)
            try
            {
                if (!ValidateWorkspace(workspace))
                {
                    return VideoHelperResult.WorkspaceIsInvalid;
                }

                else if (AlbumExists(workspace, album))
                {
                    if (AlbumExists(workspace, newName))
                    {
                        return VideoHelperResult.AlbumAlreadyExists;
                    }

                    Move($@"{workspace}\{album}", $@"{workspace}\{newName}");

                    if (AlbumExists(workspace, newName))
                    {
                        return VideoHelperResult.Success;
                    }
                }
            }

            catch
            {
                return VideoHelperResult.UnhandledRenameError;
            }

            return VideoHelperResult.AlbumRenameFailed;
        }

        public VideoHelperResult RenameAlbum(string album, string newName) => RenameAlbum(workspace, album, newName);
    }
}