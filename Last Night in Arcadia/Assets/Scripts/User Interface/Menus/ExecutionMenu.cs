using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExecutionMenu : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _menuTitle;
    [SerializeField] private TextMeshProUGUI _executionStatus;
    [SerializeField] private Image _executionTargetImage;
    [SerializeField] private GameObject _clickToContinueText;

    private Character _executionTarget;
    private bool _isExecutionConfirmed;


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
        _clickToContinueText.SetActive(true);
        UpdateUI();
    }


    private void OnEnable()
    {
        Actions.OnChooseTargetMenuButtonClicked += SetChooseTargetMenuButton;
    }


    private void OnDisable()
    {
        Actions.OnChooseTargetMenuButtonClicked -= SetChooseTargetMenuButton;
    }


    private void SetChooseTargetMenuButton(ChooseTargetMenuButton chooseTargetMenuButton)
    {
        _executionTarget = chooseTargetMenuButton.Character;

        UpdateUI();
    }


    private void UpdateUI()
    {
        _menuTitle.text = String.Format("Execute {0}", _executionTarget.Name);

        if (_isExecutionConfirmed)
        {
            _executionStatus.text = String.Format("You have executed {0}!\n{1} was {2}.", _executionTarget.Name, _executionTarget.Name, _executionTarget.RoleName);
        }
        else
        {
            _executionStatus.text = String.Format("You have chosen to execute {0}.\nAre you sure?", _executionTarget.Name);
            _executionTargetImage.sprite = _executionTarget.Portrait;
        }
    }
}
