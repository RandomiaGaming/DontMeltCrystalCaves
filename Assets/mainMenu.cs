using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
    public void LoadNormal()
    {
        
        SceneManager.LoadSceneAsync("Normal");
    }
    public void LoadExpert()
    {

        SceneManager.LoadSceneAsync("Expert");
    }
    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
    public void LoadHard()
    {
        SceneManager.LoadSceneAsync("Hard");
    }
    public void Editor()
    {
        SceneManager.LoadScene("Editor");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
