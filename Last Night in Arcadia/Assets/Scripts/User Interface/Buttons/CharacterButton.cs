using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MyButton
{
    [Header("Character Button UI Element(s)")]
    [SerializeField] private TextMeshProUGUI _roleText;
    [SerializeField] private TextMeshProUGUI _statusText;
    [SerializeField] private Color _colorWhenSelected;
    [SerializeField] private Color _colorWhenDead;


    /// <summary>
    /// Initializes button with information from given character's role.
    /// </summary>
    /// <param name="character">Character whose role will be used to initialize this button.</param>
    public override void Initialize(Character character)
    {
        _index = character.Index;

        base.Icon.sprite = character.Portrait;
        base.Name.text = character.Name;

        UpdateUI();
    }


    public override void OnClick()
    {
        base.OnClick();

        Actions.OnCharacterButtonClicked?.Invoke(this);
    }


    /// <summary>
    /// Updates the CharacterButtons UI.
    /// </summary>
    public override void UpdateUI()
    {
        Character character = GameManager.Instance.GetCharacter(base.Index);

        _roleText.text = GetRoleText(character);

        if (!character.IsAlive)
        {
            _statusText.text = GetLifeStatus(character);
        }

        else if (character.Targeter == null)
        {
            _statusText.text = GetLifeStatus(character);
        }
        else
        {
            _statusText.text = GetTargetedStatus(character.Targeter);
        }

        UpdateButtonColor();
    }


    private string GetRoleText(Character character)
    {
        return character.IsRoleRevealed ? character.RoleName : "ID Unknown";
    }


    private string GetLifeStatus(Character character)
    {
        if (character.IsAlive)
        {
            return "Alive";
        }

        return String.Format("Killed by {0}", character.Killer.RoleName);
    }


    private string GetTargetedStatus(Character targeter)
    {
        return String.Format("{0}\nTARGET", targeter.RoleName.ToUpper());
    }


    private void UpdateButtonColor()
    {
        // This is it's own function can potentially this might be where I change the color
        // depending if the person is dead and was hostile vs non-hostile.
        if (!GameManager.Instance.GetCharacter(base.Index).IsAlive)
        {
            base.Button.GetComponent<Image>().color = _colorWhenDead;
            base.Button.enabled = false;

        }
        else if (base.IsSelected)
        {
            base.Button.GetComponent<Image>().color = _colorWhenSelected;
        }
    }
}
