using UnityEditor;
using UnityEngine;

public class AssetsFolderHelper : MonoBehaviour
{
    [MenuItem("Helper/CreateAssetsFolders")]
    static void CreateAssetsFolders() {
        if (!AssetDatabase.IsValidFolder("Assets/Scripts")) 
            AssetDatabase.CreateFolder("Assets", "Scripts");
        if (!AssetDatabase.IsValidFolder("Assets/Prefabs")) 
            AssetDatabase.CreateFolder("Assets", "Prefabs");
        if (!AssetDatabase.IsValidFolder("Assets/Textures")) 
            AssetDatabase.CreateFolder("Assets", "Textures");
    }
}
