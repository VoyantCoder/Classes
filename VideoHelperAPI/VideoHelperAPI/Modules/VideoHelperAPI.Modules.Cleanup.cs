
// Author: Dashie


using System.IO;
using System.Linq;


namespace VideoHelper
{
    public partial class VideoHelperAPI
    {
        public VideoHelperResult CleanupAlbum(string workspace, string album, bool moveRendered)
        {
            if (!ValidateWorkspace(workspace))
            {
                return VideoHelperResult.WorkspaceIsInvalid;
            }

            else if (!AlbumExists(workspace, album))
            {
                return VideoHelperResult.AlbumDoesNotExist;
            }

            string a_path = $@"{workspace}\{album}";
            string r_path = $@"{a_path}\rendered";

            VideoHelperResult MoveRendered()
            {
                try
                {
                    if (moveRendered)
                    {
                        Directory.GetFiles(r_path).ToList().ForEach
                        (
                            source =>
                            {
                                string destination = $@"{a_path}\{source.Split('\\').Last()}";

                                if (File.Exists(destination))
                                {
                                    File.Delete(destination);
                                }

                                File.Move(source, destination);
                            }
                        );
                    }

                    return DeleteDirectory(r_path) ? VideoHelperResult.Success : VideoHelperResult.RenderedCleanupFailed;
                }

                catch
                {
                    return VideoHelperResult.UnableToMoveRendered;
                }
            }

            bool ValidateFileExtension(string path)
            {
                string[] extensions = new[]
                {
                    "mp3", "mov"
                };

                path = path.ToLower();

                foreach (string extension in extensions)
                {
                    if (path.EndsWith($".{extension}"))
                    {
                        return true;
                    }
                }

                return false;
            }

            VideoHelperResult RemoveTrashFiles()
            {
                try
                {
                    Directory.GetFiles(a_path).ToList().ForEach
                    (
                        item =>
                        {
                            if (ValidateFileExtension(item))
                            {
                                File.Delete(item);
                            }
                        }
                    );
                }

                catch
                {
                    return VideoHelperResult.UnableToRemoveTrash;
                }

                return VideoHelperResult.Success;
            }

            (var moveResult, var removeResult) = (MoveRendered(), RemoveTrashFiles());

            if (moveResult != VideoHelperResult.Success || removeResult != VideoHelperResult.Success)
            {
                return moveResult != VideoHelperResult.Success ? moveResult : removeResult;
            }

            return moveResult;
        }

        public VideoHelperResult CleanupAlbum(string workspace, string album) => CleanupAlbum(workspace, album, true);
        public VideoHelperResult CleanupAlbum(string album) => CleanupAlbum(workspace, album);
    }
}