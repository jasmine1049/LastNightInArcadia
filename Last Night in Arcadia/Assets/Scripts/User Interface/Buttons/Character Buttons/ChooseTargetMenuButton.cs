using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseTargetMenuButton : CharacterButton
{
    [Header("Button UI Element(s)")]
    [SerializeField] private Image _characterPortrait;
    [SerializeField] private TextMeshProUGUI _characterName;
    [SerializeField] private TextMeshProUGUI _roleIdentity;
    [SerializeField] private TextMeshProUGUI _status;

    [Header("Button Color(s)")]
    [SerializeField] private Color _colorWhenDead;
    [SerializeField] private Color _colorWhenTargeted;


    public override void OnClick()
    {
        base.OnClick();

        Actions.OnChooseTargetMenuButtonClicked?.Invoke(this);
    }


    public override void UpdateUI()
    {
        _characterPortrait.sprite = base.Character.Portrait;
        _characterName.text = base.Character.Name;
        _roleIdentity.text = FormatRoleIdentityText();
        _status.text = FormatStatusText();

        SetButtonColor();
    }


    private string FormatRoleIdentityText()
    {
        if (base.Character.IsRoleRevealed)
        {
            return base.Character.RoleName;
        }

        return "ID Unknown";
    }


    private string FormatStatusText()
    {
        if (base.Character.Targeter != null)
        {
            GetTargetedStatus();
        }

        return GetLifeStatus();
    }


    private string GetLifeStatus()
    {
        if (base.Character.IsAlive)
        {
            return "Alive";
        }

        return String.Format("Killed by {0}", base.Character.Killer.RoleName);
    }


    private string GetTargetedStatus()
    {
        return String.Format("{0}\nTARGET", base.Character.Targeter.RoleName.ToUpper());
    }


    private void SetButtonColor()
    {
        if (base.Character.IsAlive)
        {
            if (base._isSelected)
            {
                //base._button.GetComponent<Image>().color = _colorWhenTargeted;
                //base._button.enabled = false;
            }
        }
        else
        {
            base._button.GetComponent<Image>().color = _colorWhenDead;
            base._button.enabled = false;
        }
    }
}
