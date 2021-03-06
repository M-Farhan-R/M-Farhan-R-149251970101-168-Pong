using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleLengthUp : MonoBehaviour
{
    public PUManager manager;
    public Collider2D ball;
    public GameObject paddleL, paddleR;
    public float lengthMultiplier;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision == ball)
        {
            paddleL.GetComponent<PaddleControl>().startPaddleLengthUp(lengthMultiplier);
            paddleR.GetComponent<PaddleControl>().startPaddleLengthUp(lengthMultiplier);
            manager.RemovePaddleLengthPU(gameObject);
            manager.paddleLengthStartCoroutine = false;
            manager.StopCoroutine(manager.paddleLengthCoroutine);
            
        }
    }
}
