
// Author: Dashie


namespace VideoHelper
{
    public enum VideoHelperResult
    {
        DirectoryAlreadyExists, 
        
        WorkspaceIsInvalid, WorkspaceDoesNotExist,
        
        UnhandledCreationError, UnhandledRenameError,
        
        Success,
        
        AlbumDoesNotExist, AlbumAlreadyExists, AlbumRenameFailed
    }
}