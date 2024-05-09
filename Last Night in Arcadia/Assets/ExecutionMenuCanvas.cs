using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExecutionMenuCanvas : MonoBehaviour, IPointerClickHandler
{
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
}
