using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    private Rigidbody2D rig;
    public int speed;
    public KeyCode up,down;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
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
            Debug.Log("Speed Paddle = " + move.y);
            
        } else if (Input.GetKey(down))
        {
            move = Vector2.down * speed;
            Debug.Log("Speed Paddle = " + move.y);
        }

        return move;
    }

    //setMove
    void setObjMovement(Vector2 move){
        rig.velocity = (move);
    }

    public void Reset(){
        rig.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
