using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUManager : MonoBehaviour
{
    public Vector2 PUAreaMin,PUAreaMax;

    //Template untuk komponen SpeedUp yang akan diduplukasi objeknya
    public List<GameObject> PUTemplate;

    //Menampung banyak clone dari komponen SpeedUp
    private List<GameObject> BallPUList, PaddleSpdPUList, PaddleLengthPUList;
    
    public int maxBallPUList, maxPaddleSpdPUList, maxPaddleLengthPUList;

    //Sebagai wadah spawn(?)
    public Transform spawnArea;
    
    private float ballPUTimer;
    public int spawnBallPUInterval, despawnBallPUInterval;
    public Coroutine ballCoroutine;

    //untuk cek coroutine start
    public bool ballStartCoroutine;

    void Start()
    {
        BallPUList = new List<GameObject>();
        ballPUTimer = 0;
    }

    void Update()
    {
        ballPUTimer += Time.deltaTime;

        if (ballPUTimer > spawnBallPUInterval)
        {
            GenerateRandomBallPU();
            ballPUTimer -= spawnBallPUInterval;
            
        }
    }
    
    IEnumerator DespawnBall()
    {
        //
        ballStartCoroutine = true;
        Debug.Log("Enter Despawn Countdown");
        yield return new WaitForSeconds(despawnBallPUInterval);
        Debug.Log("After seconds");
        RemoveBallPU(BallPUList[0]);
        ballStartCoroutine = false;
    }

    public void GenerateRandomBallPU()
    {
        GenerateRandomBallPU(new Vector3(Random.Range(PUAreaMin.x, PUAreaMax.x),
                                    Random.Range(PUAreaMin.y, PUAreaMax.y),
                                    0));
    }

    public void GenerateRandomBallPU(Vector3 position)
    {
        if (BallPUList.Count >= maxBallPUList)
        {
            return;
        }

        if (position.x < PUAreaMin.x ||
        position.y < PUAreaMin.y ||
        position.x > PUAreaMax.x ||
        position.y > PUAreaMax.y)
        {
            return;
        }
        
        int randomIndex = Random.Range(0, BallPUList.Count);
    
        GameObject ballPU = Instantiate(PUTemplate[randomIndex], position, Quaternion.identity, spawnArea);
        ballPU.SetActive(true);

        BallPUList.Add(ballPU);
        
        if (!ballStartCoroutine)
        {
            ballCoroutine = StartCoroutine(DespawnBall());
        }
    }

    public void RemoveBallPU(GameObject PU)
    {
        BallPUList.Remove(PU);
        Destroy(PU);
        ballStartCoroutine = false;
        StopCoroutine(ballCoroutine);
    }

    public void RemoveAllPU()
    {
        while (BallPUList.Count > 0)
        {
            RemoveBallPU(BallPUList[0]);
        }
    }
}
