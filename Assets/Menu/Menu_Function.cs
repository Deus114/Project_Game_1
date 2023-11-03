using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Function : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject NewGunpanel;
    public void NewPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Control()
    {
        panel.SetActive(true);
    }

    public void ControlX()
    {
        panel.SetActive(false);
    }

    public void GameControl()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ResumeNewGun()
    {
        NewGunpanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }
}
