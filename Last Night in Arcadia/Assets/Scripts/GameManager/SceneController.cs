using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /// <summary>
    /// Starts a coroutine to load the next scene in the background.
    /// </summary>
    public void LoadNextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene >= SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 1;
        }
        StartCoroutine(AsyncLoadScene(nextScene));
    }


    /// <summary>
    /// Starts a coroutine to load the given scene in the background.
    /// </summary>
    /// <param name="scene"></param>
    public void LoadScene(int scene)
    {
        StartCoroutine(AsyncLoadScene(scene));
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


    /// <summary>
    /// Quits the player application.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
