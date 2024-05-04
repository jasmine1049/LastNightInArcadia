using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoleDescriptionScreen : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;


    private void OnEnable()
    {
        Actions.OnRoleButtonClicked += UpdateRoleDescriptionScreenText;
    }


    private void OnDisable()
    {
        Actions.OnRoleButtonClicked -= UpdateRoleDescriptionScreenText;
    }


    /// <summary>
    /// Updates the title and description of the Role Description Screen based off the index
    /// associated with the given Role Button.
    /// </summary>
    /// <param name="button">Role Button pressed.</param>
    public void UpdateRoleDescriptionScreenText(RoleButton button)
    {
        Character character = GameManager.Instance.GetCharacter(button.Index);

        _titleText.text = character.RoleName;
        _descriptionText.text = character.RoleDescription;
    }
}
