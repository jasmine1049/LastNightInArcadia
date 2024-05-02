using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoleScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;


    public void UpdateText(SORole role)
    {
        _title.text = role.Name;
        _description.text = role.Description;
    }
}
