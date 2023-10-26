using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void OnClickMainMenu()
    {
        ChangeScene(GameParameters.SceneNames.MAIN_MENU);
    }

    public void OnClickGame()
    {   
        ChangeScene(GameParameters.SceneNames.GAME);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
