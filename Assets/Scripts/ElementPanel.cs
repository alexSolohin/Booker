using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElementPanel : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI nameField;
    [SerializeField] private TextMeshProUGUI autorField;
    [SerializeField] private TextMeshProUGUI dateField;

    public void FillElement(string autor, string name) {
        autorField.text = autor;
        nameField.text = name;
        dateField.text = DateTime.Now.ToShortDateString();
    }
}

