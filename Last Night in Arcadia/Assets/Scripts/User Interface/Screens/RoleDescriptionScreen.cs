using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoleDescriptionScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _roleName;
    [SerializeField] private TextMeshProUGUI _roleDescription;


    private void OnEnable()
    {
        Actions.OnCharacterButtonClicked += SetRoleName;
        Actions.OnCharacterButtonClicked += SetRoleDescription;
    }


    private void OnDisable()
    {
        Actions.OnCharacterButtonClicked -= SetRoleName;
        Actions.OnCharacterButtonClicked -= SetRoleDescription;
    }


    private void SetRoleName(CharacterButton button)
    {
        _roleName.text = button.Character.RoleName;
    }


    private void SetRoleDescription(CharacterButton button)
    {
        _roleDescription.text = button.Character.RoleDescription;
    }
}
