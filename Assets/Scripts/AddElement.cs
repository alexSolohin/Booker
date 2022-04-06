using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AddElement : MonoBehaviour {
    [SerializeField] private ElementPanel prefabElementPanel;
    [SerializeField] private Transform parent;

    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private TMP_InputField authorField;
    [SerializeField] private Button addButon;
    
    private void OnEnable() {
        addButon.onClick.AddListener(Add);
        nameField.text = "";
        authorField.text = "";
    }

    public void Add() {
        ElementPanel elementPanel = Instantiate(prefabElementPanel, parent).GetComponent<ElementPanel>();
        Element element = new Element {
            author = authorField.text,
            name = nameField.text,
            date = DateTime.Now.ToShortDateString()
        };
        elementPanel.FillElement(element);
        AppMain.Instance.elements.elements.Add(element);
        gameObject.SetActive(false);
    }

    private void OnDisable() {
        addButon.onClick.RemoveListener(Add);
    }
}

#if UNITY_EDITOR

[CustomEditor(typeof(AddElement))]
 class AddElementEditor : Editor {
     public override void OnInspectorGUI() {
         base.OnInspectorGUI();
         AddElement me = (AddElement) target;
         if (GUILayout.Button("Add")) {
             me.Add();
         }
     }
 }

#endif
