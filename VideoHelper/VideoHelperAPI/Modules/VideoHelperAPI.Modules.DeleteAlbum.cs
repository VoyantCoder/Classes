
// Author: Dashie



namespace VideoHelper
{
    public partial class VideoHelperAPI
    {
        public VideoHelperResult DeleteAlbum(string workspace, string album)
        {
            if (!ValidateWorkspace(workspace))
            {
                return VideoHelperResult.WorkspaceIsInvalid;
            }

            else if (!AlbumExists(workspace, album))
            {
                return VideoHelperResult.AlbumDoesNotExist;
            }

            return DeleteDirectory($@"{workspace}\{album}") ? VideoHelperResult.Success : VideoHelperResult.AlbumDeletionFailed;
        }

        public VideoHelperResult DeleteAlbum(string album) => DeleteAlbum(workspace, album);
    }
}