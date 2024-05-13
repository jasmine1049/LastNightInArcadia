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
    private RoleButton _roleButton;


    private void OnEnable()
    {
        Actions.OnRoleButtonClicked += SetRoleButton;
        Actions.OnCharacterButtonClicked += SetTarget;
    }


    private void OnDisable()
    {
        Actions.OnRoleButtonClicked -= SetRoleButton;
        Actions.OnCharacterButtonClicked -= SetTarget;
    }


    private void SetRoleButton(RoleButton roleButton)
    {
        _roleButton = roleButton;
    }


    private void SetTarget(CharacterButton characterButton)
    {
        // only enable this false if we've chosen a role and come back out of it.
        _roleButton.GetComponentInChildren<Button>(true).enabled = false;

        GameManager.Instance.SetTarget(_roleButton.Index, characterButton.Index);

        _roleButton.UpdateUI();
        _roleButton.SetTargetPortrait(characterButton.Index);

        characterButton.UpdateUI();

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
