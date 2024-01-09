using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class AssetBundleManagement
    {
        public static string AssetBundleDirectory = Application.streamingAssetsPath;
        [MenuItem("Assets/Build AssetBundles")]
        static void BuildAllAssetBundles()
        {
            if (!Directory.Exists(AssetBundleDirectory))
            {
                Directory.CreateDirectory(AssetBundleDirectory);
            }

            var manifest = BuildPipeline.BuildAssetBundles(AssetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
            if (manifest != null)
            {
                var outputFiles = Directory.EnumerateFiles(AssetBundleDirectory, "*", SearchOption.TopDirectoryOnly);
                //Expected output (on Windows):
                //  Output of the build:
                //      build\build
                //      build\build.manifest
                //      build\mybundle
                //      build\mybundle.manifest
                Debug.Log("Output of the build:\n\t" + string.Join("\n\t", outputFiles));
            }
        }
    }
}
