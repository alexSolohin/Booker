using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Saver : Singleton<Saver> {
    static string Path;
    static string SaveName = "save";

    protected override void Awake() {
        base.Awake();
        Path = Application.streamingAssetsPath + "/" + SaveName + ".save";
    }

    private bool CheckFile() {
        if (File.Exists(Path)) return true;
        return false; 
    }
    
    public Element[] Load() {
        Element[] elements = null;
        if (CheckFile()) {
            var json = File.ReadAllText(Path);
            elements = JsonHelper.FromJson<Element>(json);
        }

        return elements;
    }

    public void Save() {
        if (!CheckFile()) {
            CreateFile();
        }

        if (AppMain.Instance.elements.elements != null) {
            var json = JsonHelper.ToJson(AppMain.Instance.elements.elements.ToArray(), true);
            File.WriteAllText(Path, json);
            Debug.Log(json);
        }
    }

    private void CreateFile() {
        File.Create(Path);
    }
}

[Serializable]
public class Element {
    public string name;
    public string author;
    public string date;
}


#if UNITY_EDITOR

[CustomEditor(typeof(Saver))]
class SaverEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        Saver me = (Saver) target;
        if (GUILayout.Button("Save")) {
            me.Save();
        }
    }
}

#endif
