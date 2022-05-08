
// Author: Dashie


using System.IO;
using System.Linq;


namespace VideoHelper
{
    public partial class VideoHelperAPI
    {
        private bool DeleteDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                return false;
            }

            bool RecurseOver(string path)
            {
                try
                {
                    Directory.GetFiles(path).ToList().ForEach
                    (
                        item =>
                        {
                            File.Delete(item);
                        }
                    );

                    Directory.GetDirectories(path).ToList().ForEach
                    (
                        item =>
                        {
                            RecurseOver(item);
                            Directory.Delete(item);
                        }
                    );
                }

                catch
                {
                    return false;
                }

                return true;
            }

            bool result = RecurseOver(directory);

            Directory.Delete(directory);

            return result;
        }
    }
}