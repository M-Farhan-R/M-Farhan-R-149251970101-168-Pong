using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public int kiriScore, kananScore, maxScore;
    // Start is called before the first frame update
    public void AddScoreKiri()
    {
        kiriScore+=1;
        if (maxScore < kiriScore)
        {
            GameOver();
        }
    }

    public void AddScoreKanan()
    {
        kananScore+=1;
        if (kananScore > maxScore)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
