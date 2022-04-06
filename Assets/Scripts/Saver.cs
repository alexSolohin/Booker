using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Saver : MonoBehaviour {
    static string Path;
    static string SaveName = "save";

    private void Awake() {
        Path = Application.persistentDataPath + SaveName + ".save";
    }

    private bool CheckFile() {
        if (File.Exists(Path)) return true;
        return false; 
    }

    public void Save() {
        // if (!CheckFile()) {
        //     CreateFile();
        // }

        var element = new List<Element>();
        element.Add(new Element{ name = "first", author = "poshel", date = "11/22" });
        element.Add(new Element{name = "first", author = "poshel", date = "11/22" });

        // var element = new Element {name = "first", author = "poshel", date = "11/22"};
        
        var json = JsonUtility.ToJson(element, true);
        Debug.Log(json);
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
