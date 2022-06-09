using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball, paddle1, paddle2;
    public bool isPlayerRight;

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
            ball.GetComponent<BallControl>().Reset();
            
        }
    }
    
}
