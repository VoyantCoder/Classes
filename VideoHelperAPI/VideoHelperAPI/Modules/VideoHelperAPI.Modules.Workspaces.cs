
// Author: Dashie


using static System.IO.Directory;


namespace VideoHelper
{
    public partial class VideoHelperAPI
    {
        private string workspace = string.Empty; // V:\YouTube\Recording\Albums

        public string Workspace
        {
            get
            {
                return workspace;
            }

            set
            {
                if (Exists(value))
                {
                    workspace = value.Replace("/", @"\").EndsWith(@"\") ? value.Substring(value.Length - 1, 1) : value;
                }
            }
        }

        private bool ValidateWorkspace(string workspace)
        {
            return workspace != null && workspace != string.Empty && Exists(workspace);
        }

        private bool ValidateWorkspace() => ValidateWorkspace(workspace);
    }
}