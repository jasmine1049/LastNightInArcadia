using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPhaseButton : MonoBehaviour
{
    /// <summary>
    /// Sets which functions should be called when this button is clicked.
    /// </summary>
    void Start()
    {
        Button button = GetComponent<Button>();

        button.onClick.AddListener(ProgressTime);
        button.onClick.AddListener(LoadNextScene);
    }


    /// <summary>
    /// Calls TakeActions() from the Game Manager then ProgressTime() from the Day Tracker.
    /// </summary>
    private void ProgressTime()
    {
        GameManager.Instance.TakeActions();
        GameManager.Instance.GetComponent<DayTracker>().ProgressTime();
    }


    /// <summary>
    /// Calls LoadNextScene() from the Scene Controller.
    /// </summary>
    private void LoadNextScene()
    {
        GameManager.Instance.GetComponent<SceneController>().LoadNextScene();
    }
}
