using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FlexibleGridLayout))]
public class ButtonGrid : MonoBehaviour
{
    private enum CharacterType
    {
        All,
        Allied
    }


    private enum SortType
    {
        Index,
        Alphabet
    }


    [Header("Button")]
    [Tooltip("Game object must derive from MyButton abstract class.")]
    [SerializeField] private GameObject _buttonGameObject;

    [Header("Display Option(s)")]
    [SerializeField] private CharacterType _characterType;
    [SerializeField] private SortType _sortType;

    private Character[] _characters;


    /// <summary>
    /// Set and sorts characters array, then fills button grid based off the character's array.
    /// </summary>
    void Start()
    {
        SetCharactersArray();
        SortCharactersArray();
        FillGrid();
    }


    /// <summary>
    /// Returns a character's array of the desired character type.
    /// </summary>
    private void SetCharactersArray()
    {
        if (_characterType == CharacterType.All)
        {
            _characters = GameManager.Instance.Characters;
        }
        else
        {
            _characters = GameManager.Instance.GetCharacters(character => character.IsAllied);
        }
    }


    /// <summary>
    /// Sorts a character's array based off the SortType and button type.
    /// </summary>
    private void SortCharactersArray()
    {
        bool isRoleButton = (_buttonGameObject.GetComponent<RoleButton>() != null);

        if (_sortType == SortType.Index)
        {
            if (isRoleButton)
            {
                System.Array.Sort(_characters, (c1, c2) => { return c1.RoleIndex.CompareTo(c2.RoleIndex); });
            }
        }
        else
        {
            if (isRoleButton)
            {
                System.Array.Sort(_characters, (c1, c2) => { return c1.RoleName.CompareTo(c2.RoleName); });
            }
            else
            {
                System.Array.Sort(_characters, (c1, c2) => { return c1.Name.CompareTo(c2.Name); });
            }
        }
    }


    /// <summary>
    /// Instantiates and initializes buttons on the Button Grid.
    /// </summary>
    private void FillGrid()
    {
        foreach (Character character in _characters)
        {
            GameObject obj = Instantiate(_buttonGameObject, this.transform);
            obj.SetActive(true);

            if (obj.TryGetComponent<MyButton>(out MyButton button))
            {
                button.Initialize(character);
            }
        }
    }
}
