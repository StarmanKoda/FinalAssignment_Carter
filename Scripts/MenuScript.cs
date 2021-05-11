using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string startSceneName1;
    public string startSceneName2;

    public void StartPressed1()
    {
        SceneManager.LoadScene(startSceneName1);
    }
    public void StartPressed2()
    {
        SceneManager.LoadScene(startSceneName2);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
