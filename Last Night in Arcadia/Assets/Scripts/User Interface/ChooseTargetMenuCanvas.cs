using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChooseTargetMenuCanvas : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _menuTitleText;


    private void OnEnable()
    {
        Actions.OnRoleButtonClicked += UpdateMenuTitle;
    }


    private void OnDisable()
    {
        Actions.OnRoleButtonClicked -= UpdateMenuTitle;
    }


    private void UpdateMenuTitle(RoleButton roleButton)
    {
        string roleName = GameManager.Instance.GetCharacter(roleButton.Index).RoleName;
        _menuTitleText.text = String.Format("Select {0}'s Target", roleName);
    }
}
