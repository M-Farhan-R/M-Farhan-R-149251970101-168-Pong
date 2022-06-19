using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMenu : MonoBehaviour
{
    public void btnPlay()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Created by M Farhan R - 149251970101-168");
    }

    public void btnCredit()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void btnExit()
    {
        Application.Quit();
    }
}
