using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreenController : MonoBehaviour
{
    public static MenuScreenController menuScreenController;

    public GameObject ui;
    bool cond = false;

    public GameObject howto;

    private void Awake()
    {
        if (menuScreenController == null)
        {
            menuScreenController = this;
        }

        else if (menuScreenController != this)
        {
            Destroy(gameObject);
        }
    }

    public void SinglePlayer()
    {
        SceneManager.LoadScene("OnePlayerScene");
    }

    public void TwoPlayer()
    {
        SceneManager.LoadScene("TwoPlayerScene");
    }

    public void Play()
    {
        cond = !cond;
        ui.SetActive(cond);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void CloseHowTo()
    {
        howto.SetActive(false);
    }

    public void OpenHowTo()
    {
        howto.SetActive(true);
    }
}
