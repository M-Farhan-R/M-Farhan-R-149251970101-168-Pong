using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    private Rigidbody2D rig;
    public int speed;
    public KeyCode up,down;
    private Vector3 startPosition, startScale;
    private float spdMultiplier;
    public Coroutine paddleLengthCoroutine, paddleSpdCoroutine;
    private bool paddleLengthStartCoroutine, paddleSpdStartCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
        startPosition = transform.position;
        spdMultiplier = 1;
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        setObjMovement(getMovement());
    }

    //getMove
    Vector2 getMovement()
    {

        Vector2 move =  Vector2.zero;
         if (Input.GetKey(up))
        {
            move = Vector2.up * speed;
            // Debug.Log("Speed Paddle = " + move.y);
            
        } else if (Input.GetKey(down))
        {
            move = Vector2.down * speed;
            // Debug.Log("Speed Paddle = " + move.y);
        }

        return move;
    }

    //setMove
    void setObjMovement(Vector2 move){
        rig.velocity = move * spdMultiplier;
    }

    public void Reset(){
        rig.velocity = Vector2.zero;
        transform.position = startPosition;
    }

    public void startPaddleLengthUp(float multiplier)
    {
        if (paddleLengthStartCoroutine)
        {
            return;
        }
        paddleLengthCoroutine = StartCoroutine(PaddleLengthUp(multiplier));
    }

    public void startPaddleSpdUp(float multiplier)
    {
        if (paddleSpdStartCoroutine)
        {
            return;
        }
        paddleSpdCoroutine = StartCoroutine(PaddleSpeedUp(multiplier));
    }

    IEnumerator PaddleLengthUp(float multiplier)
    {
        paddleLengthStartCoroutine = true;
        transform.localScale *= multiplier;
        yield return new WaitForSeconds(5);
        transform.localScale = startScale;
        paddleLengthStartCoroutine = false;
    }

    IEnumerator PaddleSpeedUp(float multiplier)
    {
        paddleSpdStartCoroutine = true;
        spdMultiplier = multiplier;
        yield return new WaitForSeconds(5);
        spdMultiplier = 1;
        paddleSpdStartCoroutine = false;
    }

    public void ResetPaddlePU()
    {
        StopAllCoroutines();
        paddleLengthStartCoroutine = false;
        paddleSpdStartCoroutine = false;
        transform.localScale = startScale;
        spdMultiplier = 1;
    }
}
