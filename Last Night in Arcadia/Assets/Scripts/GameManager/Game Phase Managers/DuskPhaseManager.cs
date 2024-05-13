using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuskPhaseManager : MonoBehaviour
{
    [SerializeField] private GameObject _executionerButtonGameObject;

    private Character _target;


    private void OnEnable()
    {
        Actions.OnChooseTargetMenuButtonClicked += SetTarget;
    }


    private void OnDisable()
    {
        Actions.OnChooseTargetMenuButtonClicked -= SetTarget;
    }


    public void ConfirmExecution()
    {
        ExecutionerButton executionerButton = _executionerButtonGameObject.GetComponent<ExecutionerButton>();

        GameManager.Instance.SetTarget(executionerButton.Character, _target);
    }


    private void SetTarget(ChooseTargetMenuButton chooseTargetMenuButton)
    {
        _target = chooseTargetMenuButton.Character;
    }
}
