using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RolesMenuButton : CharacterButton
{
    [SerializeField] private TextMeshProUGUI _roleName;


    public override void UpdateUI()
    {
        _roleName.text = base.Character.RoleName;
    }
}
