using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRoleMenuButton : RoleButton
{
    [SerializeField] private Image _targetIcon;

    private GameObject _chooseRoleMenuUIObject;
    private GameObject _chooseCharacterMenuUIObject;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        this.Button.onClick.AddListener(DisableChooseRoleMenu);
        this.Button.onClick.AddListener(ActivateChooseTargetMenu);

        _chooseRoleMenuUIObject = GameObject.Find("Choose Role Menu UI");
        _chooseCharacterMenuUIObject = GameObject.Find("Choose Character Menu UI");
    }


    /// <summary>
    /// 
    /// </summary>
    private void DisableChooseRoleMenu()
    {
        _chooseRoleMenuUIObject.SetActive(false);
    }


    /// <summary>
    /// 
    /// </summary>
    private void ActivateChooseTargetMenu()
    {
        _chooseCharacterMenuUIObject.SetActive(true);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sprite"></param>
    public void SetTargetIcon(Sprite sprite)
    {
        _targetIcon.sprite = sprite;
    }
}
