using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRoleMenuButton : CharacterButton
{
    [Header("Button UI Element(s)")]
    [SerializeField] private Image _roleIcon;
    [SerializeField] private TextMeshProUGUI _roleName;
    [SerializeField] private Image _targetCharacterPortrait;

    [Header("Button Color(s)")]
    [SerializeField] private Color _colorWhenDead;
    [SerializeField] private Color _colorWhenHasTarget;
    [SerializeField] private Color _colorWhenUnusable;


    public void SetTargetCharacterPortrait(Sprite portrait)
    {
        _targetCharacterPortrait.sprite = portrait;
        _targetCharacterPortrait.color = Color.white;
    }


    public override void OnClick()
    {
        base.OnClick();

        Actions.OnChooseRoleMenuButtonClicked?.Invoke(this);
    }


    public override void UpdateUI()
    {
        _roleName.text = base.Character.RoleName;
        if (_roleIcon != null && base.Character.RoleIcon != null)
        {
            _roleIcon.sprite = base.Character.RoleIcon;
        }

        SetButtonColor();
    }


    private void SetButtonColor()
    {
        if (base.Character.IsAlive)
        {
            if (!base.Character.IsUsable())
            {
                base._button.GetComponent<Image>().color = _colorWhenUnusable;
                base._button.enabled = false;
            }
            else if (base._isSelected)
            {
                base._button.GetComponent<Image>().color = _colorWhenHasTarget;
                base._button.enabled = false;
            }
        }
        else
        {
            base._button.GetComponent<Image>().color = _colorWhenDead;
            base._button.enabled = false;
        }
    }
}
