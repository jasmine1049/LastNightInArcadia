using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class CharacterButton : MonoBehaviour
{
    protected bool _isSelected;
    protected Button _button;
    protected int _index;

    private GameObject _objectToDeactivateOnClick;
    private GameObject _objectToActivateOnClick;


    public Button Button { get { return _button; } private set { } }
    public virtual Character Character { get { return GameManager.Instance.GetCharacter(_index); } private set { } }


    void Start()
    {
        _button = GetComponentInChildren<Button>();
        Debug.Assert(_button != null,
            String.Format("{0} does not have a Button component attatched.", this.gameObject.name));

        _button.onClick.AddListener(OnClick);
    }


    public void Initialize(Character character, GameObject objectToDeactivateOnClick, GameObject objectToActivateOnClick)
    {
        _index = character.Index;

        _objectToDeactivateOnClick = objectToDeactivateOnClick;
        _objectToActivateOnClick = objectToActivateOnClick;

        UpdateUI();
    }


    public virtual void OnClick()
    {
        _isSelected = true;

        _objectToDeactivateOnClick.SetActive(false);
        _objectToActivateOnClick.SetActive(true);

        Actions.OnCharacterButtonClicked?.Invoke(this);
    }


    public void Deselect()
    {
        _isSelected = false;
    }


    public abstract void UpdateUI();
}
