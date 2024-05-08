using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Person", menuName = "Person")]
public class SOPerson : ScriptableObject
{
    // Replace this with variables needed for Live2D to work
    [SerializeField] private Sprite _portrait;


    public string Name { get { return this.name; } private set { } }
    public Sprite Portrait { get { return _portrait; } private set { } }
}
