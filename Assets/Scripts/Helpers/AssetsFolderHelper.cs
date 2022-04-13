using UnityEditor;
using UnityEngine;

public class AssetsFolderHelper : MonoBehaviour
{
    public static string[] foldersName = { "Scripts", "Prefabs", "Textures", "StreamingAssets", "Others" };

    [MenuItem("Helper/CreateAssetsFolders")]
  
    static void CreateAssetsFolders() {
        foreach (var name in foldersName) {
            if (!AssetDatabase.IsValidFolder("Assets/" + name)) 
                AssetDatabase.CreateFolder("Assets", name);
        }
    }
}
