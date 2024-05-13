using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Assumes the first gameplay scene has buildIndex == 1.
    private readonly int _firstGameplayScene = 1;


    /// <summary>
    /// Starts a coroutine to load the next scene in the gameplay loop.
    /// </summary>
    public void LoadNextScene()
    {
        int nextScene = GetNextScene();

        StartCoroutine(AsyncLoadScene(nextScene));
    }


    /// <summary>
    /// Quits the player application.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }


    /// <summary>
    /// Returns the next scene in the gameplay loop.
    /// </summary>
    /// <returns>Next scene in the gameplay loop.</returns>
    private int GetNextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene >= SceneManager.sceneCountInBuildSettings)
        {
            nextScene = _firstGameplayScene;
        }

        return nextScene;
    }


    /// <summary>
    /// Loads the given scene asynchronously in the background.
    /// </summary>
    /// <param name="scene"></param>
    private IEnumerator AsyncLoadScene(int scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
