using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 5f;

    // TEMP TEST FUNCTION
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            LoadScene(1);
        }
    }


    /// <summary>
    /// Starts a coroutine to load the next scene in the background.
    /// </summary>
    public void LoadNextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
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
    /// Loads the given scene asynchronously in the background. Plays the White Flash transition.
    /// </summary>
    /// <param name="scene"></param>
    /// <returns></returns>
    private IEnumerator AsyncLoadScene(int scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        transition.Play("White Flash");
        yield return new WaitForSeconds(transitionTime);

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
