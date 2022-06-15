using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void btnPlay()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Created by M Farhan R - 149251970101-168");
    }

    public void btnAuthor()
    {
        Debug.Log("Created by M Farhan R - 149251970101-168");
        /*
            Tapi nyontek gumgel + vid tutor
        */
    }

    public void btnExit()
    {
        Application.Quit();
    }
}
