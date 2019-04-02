using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//wip for loading the desired scenes
public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        //do we need to reset something at the start of the scene? hp etc.
        //FindObjectOfType<GameStatus>().ResetScore();


        //loading the starting scene of the game at the first play press
        SceneManager.LoadScene(0);

        ///TODO add to high scores?

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
