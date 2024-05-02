using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillRolesMenuGrid : MonoBehaviour
{
    [SerializeField] private GameObject _rolesMenuButtonPrefab;


    /// <summary>
    /// Populate and initialize the Roles Menu Grid with Roles Menu Buttons.
    /// </summary>
    void Start()
    {
        foreach (SORole role in GameManager.Instance.GetSORoles(SORole.RoleType.NONE))
        {
            GameObject obj = GameObject.Instantiate(_rolesMenuButtonPrefab, this.transform);

            RoleButton button = obj.GetComponent<RoleButton>();

            button.Initialize(role);
        }
    }
}
