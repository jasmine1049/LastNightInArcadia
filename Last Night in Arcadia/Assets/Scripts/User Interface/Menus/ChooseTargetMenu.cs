using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChooseTargetMenu : MonoBehaviour
{
    [Header("UI Element(s)")]
    [SerializeField] private TextMeshProUGUI _title;


    private void OnEnable()
    {
        Actions.OnChooseRoleMenuButtonClicked += SetTitle;
    }


    private void OnDisable()
    {
        Actions.OnChooseRoleMenuButtonClicked -= SetTitle;
    }


    private void SetTitle(ChooseRoleMenuButton chooseRoleMenuButton)
    {
        _title.text = String.Format("Select {0}'s Target", chooseRoleMenuButton.Character.RoleName);
    }
}
