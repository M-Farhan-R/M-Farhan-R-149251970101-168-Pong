using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball, paddle1, paddle2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            paddle1.GetComponent<PaddleControl>().Reset();
            paddle2.GetComponent<PaddleControl>().Reset();
            ball.GetComponent<BallControl>().Reset();
            
        }
    }
    
}
