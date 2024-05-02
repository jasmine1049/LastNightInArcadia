using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class SOCharacter : ScriptableObject
{
    [SerializeField] private string _name;
    // Replace this with variables needed for Live2D
    [SerializeField] private Sprite portrait;


    public string Name { get { return _name; } private set { } }
    public Sprite Portrait { get { return portrait; } private set { } }
}
