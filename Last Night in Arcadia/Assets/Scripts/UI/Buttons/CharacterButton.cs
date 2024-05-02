using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterButton : MyButton
{
    private Character _character;

    protected Character Character { get { return _character; } private set { } } 


    /// <summary>
    /// Initializes the values of the character button.
    /// </summary>
    /// <param name="character"></param>
    public virtual void Initialize(Character character)
    {
        _character = character;

        this.Icon.sprite = character.Portrait;
        this.TextBox.text = character.Name;
    }
}
