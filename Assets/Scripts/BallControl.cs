using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rig;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rig = GetComponent<Rigidbody2D>();
        random();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void random(){
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0,2) == 0 ? -1 : 1;
        rig.velocity = new Vector2(speed * x, speed * y);
    }

    public void Reset(){
        rig.velocity = Vector2.zero;
        transform.position = startPosition;
        random();
    }

    public void BallSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }
}
