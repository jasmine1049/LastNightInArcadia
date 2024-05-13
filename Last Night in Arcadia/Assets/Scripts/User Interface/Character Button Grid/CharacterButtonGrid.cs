using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FlexibleGridLayout))]
public class CharacterButtonGrid : MonoBehaviour
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


    [Header("Character Button")]
    [Tooltip("Game object must derive from CharacterButton abstract class.")]
    [SerializeField] private GameObject _characterButtonPrefab;
    [Tooltip("UI object to be deactivated on button click.")]
    [SerializeField] private GameObject _objectToDeactivateOnClick;
    [Tooltip("UI object to activate on button click.")]
    [SerializeField] private GameObject _objectToActivateOnClick;

    [Header("Display Option(s)")]
    [SerializeField] private CharacterType _characterType;
    [SerializeField] private SortType _sortType;
    [SerializeField] private bool _sortByRoleInfo;

    private Character[] _characters;


    /// <summary>
    /// Set and sorts characters array, then fills button grid based off the character's array.
    /// </summary>
    void Start()
    {
        CharacterButton characterButton = _characterButtonPrefab.GetComponent<CharacterButton>();
        Debug.Assert(characterButton != null,
            String.Format("{0} does not have a CharacterButton component attatched.", _characterButtonPrefab.name));

        SetCharactersArray();
        SortCharactersArray();
        FillCharacterButtonGrid();
    }


    /// <summary>
    /// Sets the character's array based off the character type.
    /// </summary>
    private void SetCharactersArray()
    {
        if (_characterType == CharacterType.All)
        {
            _characters = GameManager.Instance.GetCharacters();
        }
        else
        {
            _characters = GameManager.Instance.GetCharacters(character => character.IsAllied);
        }
    }


    /// <summary>
    /// Sorts a character's array based off the SortType.
    /// </summary>
    private void SortCharactersArray()
    {
        if (_sortType == SortType.Index)
        {
            if (_sortByRoleInfo)
            {
                System.Array.Sort(_characters, (c1, c2) => { return c1.RoleIndex.CompareTo(c2.RoleIndex); });
            }
        }
        else
        {
            if (_sortByRoleInfo)
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
    private void FillCharacterButtonGrid()
    {
        foreach (Character character in _characters)
        {
            GameObject gameObject = Instantiate(_characterButtonPrefab, this.transform);

            CharacterButton characterButton = gameObject.GetComponent<CharacterButton>();

            characterButton.Initialize(character, _objectToDeactivateOnClick, _objectToActivateOnClick);
        }
    }
}
