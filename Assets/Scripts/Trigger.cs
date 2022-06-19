using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball, paddle1, paddle2;
    public bool isPlayerRight;
    public PUManager PUmanager;
    public ScoreManager skorMenej;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject == ball)
        {
            if (isPlayerRight)
            {
                skorMenej.AddScoreKiri();
                
            } else
            {
                skorMenej.AddScoreKanan();
            }
            paddle1.GetComponent<PaddleControl>().Reset();
            paddle2.GetComponent<PaddleControl>().Reset();
            paddle1.GetComponent<PaddleControl>().ResetPaddlePU();
            paddle2.GetComponent<PaddleControl>().ResetPaddlePU();
            ball.GetComponent<BallControl>().Reset();
            PUmanager.GetComponent<PUManager>().RemoveAllPU();
            PUmanager.ResetPUTimer();
        }
    }
    
}
