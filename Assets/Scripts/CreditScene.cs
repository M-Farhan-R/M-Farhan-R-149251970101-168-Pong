using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void btnGithub()
    {
        Application.OpenURL("https://github.com/M-Farhan-R");
    }

    public void btnBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
