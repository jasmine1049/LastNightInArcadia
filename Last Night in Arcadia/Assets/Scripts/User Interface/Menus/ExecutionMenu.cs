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
    [SerializeField] private Image _executionTarget;

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
    }


    private void OnEnable()
    {
        Actions.OnChooseTargetMenuButtonClicked += SetTitleText;
        Actions.OnChooseTargetMenuButtonClicked += SetExecutionTargetImage;
    }


    private void OnDisable()
    {
        Actions.OnChooseTargetMenuButtonClicked -= SetTitleText;
        Actions.OnChooseTargetMenuButtonClicked -= SetExecutionTargetImage;
    }


    private void SetTitleText(ChooseTargetMenuButton chooseTargetMenuButton)
    {
        _menuTitle.text = String.Format("Execute {0}", chooseTargetMenuButton.Character.Name);
    }


    private void SetExecutionTargetImage(ChooseTargetMenuButton chooseTargetMenuButton)
    {
        _executionTarget.sprite = chooseTargetMenuButton.Character.Portrait;
    }
}
