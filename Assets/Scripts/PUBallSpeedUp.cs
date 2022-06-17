using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUBallSpeedUp : MonoBehaviour
{
    public PUManager manager;
    public Collider2D ball;
    public float magnitude;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            ball.GetComponent<BallControl>().BallSpeedUp(magnitude);
            manager.RemovePU(gameObject);
            manager.ballStartCoroutine = false;
            manager.StopCoroutine(manager.ballCoroutine);
            
        }
    }
}
