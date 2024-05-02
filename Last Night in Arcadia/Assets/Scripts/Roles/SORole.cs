using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Role", menuName = "Role")]
public class SORole : ScriptableObject
{
    public enum RoleType
    {
        Neutral,
        Allied,
        Hostile,
        NONE
    }


    [Header("UI Elements")]
    [SerializeField] private string _name;
    [TextArea(6, 6)]
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;

    [Header("Role Info")]
    [SerializeField] private RoleType _type;
    [Tooltip("This will decide the order of execution.")]
    [Range(0, 15)]
    [SerializeField] private int _index;

    [Header("Morale Loss")]
    [SerializeField] private int _moralLossOnDeath;
    [SerializeField] private int _moralLossOnExecution;


    public string Name { get { return _name; } private set { } }
    public string Description { get { return _description; } private set { } }
    public Sprite Icon { get { return _icon; } private set { } }

    public RoleType Type { get { return _type; } private set { } }
    public int Index { get { return _index; } private set { } }
    public int MoraleLossOnDeath { get { return _moralLossOnDeath; } private set { } }
    public int MoraleLossOnExecution { get { return _moralLossOnExecution; } private set { } }
}
