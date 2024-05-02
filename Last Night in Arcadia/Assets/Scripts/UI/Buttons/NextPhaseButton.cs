using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPhaseButton : MonoBehaviour
{
    private GameManager _gameManager;


    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        Button button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(ProgressTime);
        button.onClick.AddListener(LoadNextLevel);

        _gameManager = GameManager.Instance;
    }


    /// <summary>
    /// 
    /// </summary>
    private void ProgressTime()
    {
        _gameManager.DayTracker.ProgressTime();
    }


    /// <summary>
    /// 
    /// </summary>
    private void LoadNextLevel()
    {
        SceneController sceneController = _gameManager.GetComponent<SceneController>();
        sceneController.LoadNextScene();
    }
}
