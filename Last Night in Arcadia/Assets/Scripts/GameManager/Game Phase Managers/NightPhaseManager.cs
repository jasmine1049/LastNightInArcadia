using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightPhaseManager : MonoBehaviour
{
    [SerializeField] private int _maxNumberTargets;

    [Header("UI Element(s)")]
    [SerializeField] private GameObject _chooseRoleMenuButtonGrid;

    private int _numTargetsChosen;
    private ChooseRoleMenuButton _chooseRoleMenuButton;


    public void DeselectChooseRoleMenuButton()
    {
        _chooseRoleMenuButton.Deselect();
    }


    private void OnEnable()
    {
        Actions.OnChooseRoleMenuButtonClicked += SetChooseRoleMenuButton;
        Actions.OnChooseTargetMenuButtonClicked += SetTarget;
    }


    private void OnDisable()
    {
        Actions.OnChooseRoleMenuButtonClicked -= SetChooseRoleMenuButton;
        Actions.OnChooseTargetMenuButtonClicked -= SetTarget;
    }


    private void SetChooseRoleMenuButton(ChooseRoleMenuButton chooseRoleMenuButton)
    {
        _chooseRoleMenuButton = chooseRoleMenuButton;
    }


    private void SetTarget(ChooseTargetMenuButton chooseTargetMenuButton)
    {
        GameManager.Instance.SetTarget(_chooseRoleMenuButton.Character, chooseTargetMenuButton.Character);

        _chooseRoleMenuButton.SetTargetCharacterPortrait(chooseTargetMenuButton.Character.Portrait);
        _chooseRoleMenuButton.UpdateUI();

        chooseTargetMenuButton.UpdateUI();

        CheckMaxNumberTargets();
    }


    private void CheckMaxNumberTargets()
    {
        _numTargetsChosen++;
        if (_numTargetsChosen >= _maxNumberTargets)
        {
            DisableRoleButtons();
        }
    }


    private void DisableRoleButtons()
    {
        foreach (Transform child in _chooseRoleMenuButtonGrid.transform)
        {
            child.gameObject.GetComponentInChildren<Button>(true).enabled = false;
        }
    }
}
