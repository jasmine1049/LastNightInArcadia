using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class MyButton : MonoBehaviour
{
    [Header("Button UI Element(s)")]
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _nameText;

    /*
    [Header("UI Switch On Button Click")]
    [SerializeField] private GameObject _deactivateUIObject;
    [SerializeField] private GameObject _activateUIObject;
    */

    protected int _index;
    private bool _isSelected;


    protected Image Icon { get { return _iconImage; } private set { } }
    protected TextMeshProUGUI Name { get { return _nameText; } private set { } }
    protected bool IsSelected { get { return _isSelected; } private set { } }
    protected Button Button { get { return GetComponentInChildren<Button>(); } private set { } }

    public int Index { get { return _index; } private set { } }


    void Start()
    {
        Button.onClick.AddListener(OnClick);
    }


    public abstract void Initialize(Character character);


    public virtual void OnClick()
    {
        _isSelected = true;
    }


    // Does this need to be here as an abstract? Cause I think it always gets implemented
    // directly by the child sub classes.
    public abstract void UpdateUI();
}
