using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RolesMenuButton : RoleButton
{
    private GameObject _rolesMenuObject;
    private GameObject _roleScreenObject;
    private RoleScreen _roleScreen;


    void Start()
    {
        this.Button.onClick.AddListener(DisableRolesMenu);
        this.Button.onClick.AddListener(ActivateRoleScreen);

        _rolesMenuObject = GameObject.Find("Roles Menu");

        _roleScreen = GameObject.FindObjectsOfType<RoleScreen>(true)[0];
        _roleScreenObject = _roleScreen.gameObject;
    }


    /// <summary>
    /// Disables the roles menu.
    /// </summary>
    private void DisableRolesMenu()
    {
        _rolesMenuObject.SetActive(false);
    }


    /// <summary>
    /// Activates the role screen and updates it's text for the button's role.
    /// </summary>
    private void ActivateRoleScreen()
    {
        _roleScreenObject.SetActive(true);
        _roleScreen.UpdateText(this.Role);
    }
}
