using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text kiriScore, kananScore;
    public ScoreManager skorMenej;
    // Start is called before the first frame update
    private void Update(){

        if (skorMenej.kiriScore < 10)
        {
            kiriScore.text = "0" + skorMenej.kiriScore.ToString();
        } else
        {
            kiriScore.text = skorMenej.kiriScore.ToString();
        }

        if (skorMenej.kananScore < 10)
        {
            kananScore.text = "0" + skorMenej.kananScore.ToString();
        } else
        {
            kananScore.text = skorMenej.kananScore.ToString();
        }

    }
}
