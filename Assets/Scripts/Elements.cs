using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Elements", menuName = "App/Elements", order = 0)]
public class Elements : ScriptableObject {
    public List<Element> elements;
}
