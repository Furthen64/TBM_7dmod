using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;

public class MultiPlatformExportAssetBundles
{
    [MenuItem("Assets/Build Multi-Platform AssetBundle From Selection")]
    static void ExportResource()
    {
        // Bring up save panel
        string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "unity3d");
        if (path.Length != 0)
        {
            
            // include the following Graphic APIs
            PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows, new GraphicsDeviceType[] { GraphicsDeviceType.Direct3D11, GraphicsDeviceType.OpenGLCore, GraphicsDeviceType.Vulkan});

            // Build the resource file from the active selection.
            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

            #pragma warning disable CS0618 // Type or member is obsolete
            BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.StandaloneWindows);
              Selection.objects = selection;
            #pragma warning restore CS0618 // Type or member is obsolete


        }
    }
}