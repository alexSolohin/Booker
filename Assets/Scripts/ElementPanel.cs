using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElementPanel : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI nameField;
    [SerializeField] private TextMeshProUGUI autorField;
    [SerializeField] private TextMeshProUGUI dateField;

    public void FillElement(Element element) {
        autorField.text = element.author;
        nameField.text = element.name;
        dateField.text = element.date;
    }
}

