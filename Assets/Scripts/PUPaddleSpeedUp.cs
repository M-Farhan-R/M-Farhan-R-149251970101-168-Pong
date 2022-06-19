using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSpeedUp : MonoBehaviour
{
    public PUManager manager;
    public Collider2D ball;
    public GameObject paddleL, paddleR;
    public float spdMultiplier;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            paddleL.GetComponent<PaddleControl>().startPaddleSpdUp(spdMultiplier);
            paddleR.GetComponent<PaddleControl>().startPaddleSpdUp(spdMultiplier);
            manager.RemovePaddleSpdPU(gameObject);
            manager.paddleSpdStartCoroutine = false;
            manager.StopCoroutine(manager.paddleSpdCoroutine);
            
        }
    }
}
