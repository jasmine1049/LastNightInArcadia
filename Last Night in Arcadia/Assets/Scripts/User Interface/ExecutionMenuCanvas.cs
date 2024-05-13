using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExecutionMenuCanvas : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _menuTitleText;
    [SerializeField] private Image _executionTargetImage;

    private bool _isExecutionConfirmed;
    private CharacterButton _characterButton;


    private void OnEnable()
    {
        Actions.OnCharacterButtonClicked += SetExecutionTarget;
    }


    private void OnDisable()
    {
        Actions.OnCharacterButtonClicked -= SetExecutionTarget;
    }


    private void SetExecutionTarget(CharacterButton characterButton)
    {
        _executionTargetImage.sprite = characterButton.Icon.sprite;

        string characterName = GameManager.Instance.GetCharacter(characterButton.Index).Name;
        _menuTitleText.text = String.Format("Execute {0}", characterName);

        _characterButton = characterButton;
    }


    public void OnPointerClick(PointerEventData _)
    {
        if (_isExecutionConfirmed)
        {
            GameManager.Instance.GetComponent<SceneController>().LoadNextScene();
            GameManager.Instance.TakeActions();
        }
    }


    public void ConfirmExecution()
    {
        _isExecutionConfirmed = true;
        GameManager.Instance.Executioner.TakeAction();
    }
}
