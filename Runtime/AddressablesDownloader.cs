using System.Linq;
using System.IO;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Arbelos
{
    public abstract class AddressablesDownloader : MonoBehaviour
    {
        #region protected variables

        [SerializeField] protected bool loadNextScene = true;

        #endregion

        #region public variables

        [HideInInspector] public bool isInitialized;
        public int numDownloaded;
        public int numAssetBundlesToDownload;
        public UnityEvent onInitialized;

        #endregion

        protected static float BytesToKiloBytes(long bytes)
        {
            return bytes / 1024f;
        }

        protected static void ClearPreviousCatalog()
        {
            string path = Application.persistentDataPath + "/com.unity.addressables/";
            if (Directory.Exists(path))
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                //first the hash files
                FileInfo[] files = dir.GetFiles("catalog*.hash").OrderByDescending(p => p.LastWriteTime).ToArray();

                if (files.Length > 1)
                {
                    //skip the first file we want to keep it
                    for (int i = 1; i < files.Length; i++)
                    {
                        FileInfo file = files[i];
                        Debug.Log($"deleted: {file.Name}");
                        file.Delete();
                    }
                }

                //now the json files
                FileInfo[] jsonfiles = dir.GetFiles("catalog*.json").OrderByDescending(p => p.LastWriteTime).ToArray();

                if (jsonfiles.Length > 1)
                {
                    //skip the first file we want to keep it
                    for (int i = 1; i < jsonfiles.Length; i++)
                    {
                        FileInfo file = jsonfiles[i];
                        Debug.Log($"deleted: {file.Name}");
                        file.Delete();
                    }
                }
            }
        }

        public abstract Task UpdateAndDownload();

        public abstract void Initialize();

    }
}