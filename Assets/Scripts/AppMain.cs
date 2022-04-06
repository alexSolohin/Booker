using System;
using System.Linq;
using UnityEngine;

public class AppMain : Singleton<AppMain> {
    public Elements elements;
    [SerializeField] private Transform listParent;
    [SerializeField] private ElementPanel prefabElementPanel;

    protected override void Awake() {
        base.Awake();
    }

    private void Start() {
        if (Saver.Instance.Load() != null) {
            elements.elements = Saver.Instance.Load().ToList();
        }

        foreach (var element in elements.elements) {
            ElementPanel elementPanel = Instantiate(prefabElementPanel, listParent).GetComponent<ElementPanel>();
            Element elem = new Element {
                author = element.author,
                name = element.name,
                date = element.date
            };
            elementPanel.FillElement(elem);
        }
    }

    private void OnApplicationQuit()
    {
        Saver.Instance.Save();
    }
}
