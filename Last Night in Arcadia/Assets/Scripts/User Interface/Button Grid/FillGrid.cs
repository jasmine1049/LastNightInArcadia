using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillGrid : MonoBehaviour
{
    private enum CharactersToGet
    {
        All,
        Allied
    }


    [Header("Button")]
    [Tooltip("Game object must derive from MyButton abstract class.")]
    [SerializeField] private GameObject _myButtonPrefab;

    [Header("Display Option")]
    [SerializeField] private CharactersToGet _charactersToGet;
    [Tooltip("Alphabetized (A-Z) by Role name or Character name, depending on Button Type.")]
    [SerializeField] private bool _alphabetize;


    /// <summary>
    /// Instantiates a Grid with the given button.
    /// </summary>
    void Start()
    {
        Character[] characters = GetCharacters();
        if (_alphabetize)
        {
            characters = Alphabetize(characters);
        }

        foreach (Character character in characters)
        {
            GameObject obj = Instantiate(_myButtonPrefab, this.transform);
            obj.SetActive(true);

            if (obj.TryGetComponent<MyButton>(out MyButton button))
            {
                button.Initialize(character);
            }
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private Character[] GetCharacters()
    {
        Func<Character, bool> condition;

        if (_charactersToGet == CharactersToGet.All)
        {
            condition = (_ => true);
        }
        else
        {
            condition = (character => character.IsAllied);
        }

        return GameManager.Instance.GetCharacters(condition);
    }


    /// <summary>
    /// Alphabetizes the array of characters by either the role's name or character's name, depending on the button type.
    /// </summary>
    /// <param name="characters">Array of characters to be alphabetized.</param>
    /// <returns>The array of characters in alphabetical order (A-Z).</returns>
    private Character[] Alphabetize(Character[] characters)
    {
        if (_myButtonPrefab.TryGetComponent<RoleButton>(out RoleButton _))
        {
            System.Array.Sort(characters, (a, b) => { return a.RoleName.CompareTo(b.RoleName); });
        }
        else
        {
            System.Array.Sort(characters, (a, b) => { return a.Name.CompareTo(b.Name); });
        }

        return characters;
    }
}
