using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Role", menuName = "Role")]
public class SORole : ScriptableObject
{
    private enum RoleAlignment
    {
        Neutral,
        Allied,
        Hostile
    }


    [Header("UI Elements")]
    [TextArea(6, 6)]
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;

    [Header("Role Info")]
    private const int i = 100;
    [Range(0, GameManager.TotalNumberOfCharacters - 1)]
    [SerializeField] private int _index;
    [SerializeField] private RoleAlignment _alignment;
    [SerializeField] private int _moralLossOnDeath;
    [SerializeField] private int _moralLossOnExecution;


    public string Name { get { return this.name; } private set { } }
    public string Description { get { return _description; } private set { } }
    public Sprite Icon { get { return _icon; } private set { } }

    public int Index { get { return _index; } private set { } }
    public bool IsAllied { get { return _alignment == RoleAlignment.Allied; } private set { } }
    public bool IsHostile { get { return _alignment == RoleAlignment.Hostile; } private set { } }
    public int MoraleLossOnDeath { get { return _moralLossOnDeath; } private set { } }
    public int MoraleLossOnExecution { get { return _moralLossOnExecution; } private set { } }
}
