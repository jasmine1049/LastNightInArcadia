using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleButton : MyButton
{
    [Header("Role Button UI Element(s)")]
    [SerializeField] private Color _colorWhenSelected;

    [Header("Choose Role Menu Button UI Element(s)")]
    [SerializeField] private Image _targetPortraitImage;


    /// <summary>
    /// Initializes button with information from given character's role.
    /// </summary>
    /// <param name="character">Character whose role will be used to initialize this button.</param>
    public override void Initialize(Character character)
    {
        base.Initialize(character);

        base.Icon.sprite = character.RoleIcon;
        base.Name.text = character.RoleName;
    }


    public override void UpdateUI()
    {
        UpdateButtonColor();
    }


    public override void OnClick()
    {
        base.OnClick();

        Actions.OnRoleButtonClicked?.Invoke(this);
    }


    public void SetTargetPortrait(int characterIndex)
    {
        if (_targetPortraitImage != null)
        {
            _targetPortraitImage.color = Color.white;
            _targetPortraitImage.sprite = GameManager.Instance.GetCharacter(characterIndex).Portrait;
        }
    }


    private void UpdateButtonColor()
    {
        // This is it's own function can potentially this might be where I change the color
        // depending if the person is dead and was hostile vs non-hostile.
        if (base.IsSelected)
        {
            base.Button.GetComponent<Image>().color = _colorWhenSelected;
        }
    }
}
