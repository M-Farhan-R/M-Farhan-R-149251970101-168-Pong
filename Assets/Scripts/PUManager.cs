using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUManager : MonoBehaviour
{
    public Vector2 PUAreaMin,PUAreaMax;

    //Template untuk komponen SpeedUp yang akan diduplukasi objeknya
    public List<GameObject> PUTemplate;

    //Menampung banyak clone dari komponen SpeedUp
    private List<GameObject> ballPUList, paddleSpdPUList, paddleLengthPUList;
    
    public int maxBallPUList, maxPaddleSpdPUList, maxPaddleLengthPUList;

    //Sebagai wadah spawn(?)
    public Transform spawnArea;
    
    private float ballPUTimer, paddleSpdPUTimer, paddleLengthPUTimer;
    public int spawnBallPUInterval, spawnPaddleSpdPUInterval, spawnPaddleLengthPUInterval,
            despawnBallPUInterval, despawnPaddleSpdPUInterval, despawnPaddleLengthPUInterval;
    public Coroutine ballCoroutine, paddleSpdCoroutine, paddleLengthCoroutine;

    //untuk cek coroutine start
    public bool ballStartCoroutine, paddleSpdStartCoroutine, paddleLengthStartCoroutine;

    void Start()
    {
        ballPUList = new List<GameObject>();
        paddleSpdPUList = new List<GameObject>();
        paddleLengthPUList = new List<GameObject>();
        ballPUTimer = 0;
        paddleSpdPUTimer = 0;
        paddleLengthPUTimer = 0;
    }

    void Update()
    {
        ballPUTimer += Time.deltaTime;
        paddleSpdPUTimer += Time.deltaTime;
        paddleLengthPUTimer += Time.deltaTime;

        if (ballPUTimer > spawnBallPUInterval)
        {
            GenerateRandomBallPU(PUTemplate[0]);
            ballPUTimer -= spawnBallPUInterval;
            
        }

        if (paddleSpdPUTimer > spawnPaddleSpdPUInterval)
        {
            GenerateRandomBallPU(PUTemplate[1]);
            paddleSpdPUTimer -= spawnPaddleSpdPUInterval;
            
        }

        if (paddleLengthPUTimer > spawnPaddleLengthPUInterval)
        {
            GenerateRandomBallPU(PUTemplate[2]);
            paddleLengthPUTimer -= spawnBallPUInterval;
            
        }
    }
    
    IEnumerator DespawnPU(GameObject powerUP)
    {
        if (powerUP == PUTemplate[0])
        {
            ballStartCoroutine = true;
            
            yield return new WaitForSeconds(despawnBallPUInterval);
            
            RemoveBallPU(ballPUList[0]);
            ballStartCoroutine = false;
        } 
        else if (powerUP == PUTemplate[1])
        {
            paddleSpdStartCoroutine = true;
            
            yield return new WaitForSeconds(despawnBallPUInterval);
            
            RemovePaddleSpdPU(paddleSpdPUList[0]);
            paddleSpdStartCoroutine = false;
        } 
        else if (powerUP == PUTemplate[2])
        {
            paddleLengthStartCoroutine = true;
            
            yield return new WaitForSeconds(despawnBallPUInterval);
            
            RemovePaddleLengthPU(paddleLengthPUList[0]);
            paddleLengthStartCoroutine = false;
        }
        
    }

    public void GenerateRandomBallPU(GameObject powerUP)
    {
        GenerateRandomBallPU(new Vector3(Random.Range(PUAreaMin.x, PUAreaMax.x),
                                    Random.Range(PUAreaMin.y, PUAreaMax.y),
                                    0), powerUP);
    }

    public void GenerateRandomBallPU(Vector3 position, GameObject powerUP)
    {
        if (!spawnLimitValidation(position, powerUP))
        {
            return;
        }
        
        GameObject PU = null;
    
        if (powerUP == PUTemplate[0])
        {
            PU = Instantiate(PUTemplate[0], position, Quaternion.identity, spawnArea);
            PU.SetActive(true);
            ballPUList.Add(PU);
            if (!ballStartCoroutine)
            {
                ballCoroutine = StartCoroutine(DespawnPU(powerUP));
            }
        } 
        else if (powerUP == PUTemplate[1])
        {
            PU = Instantiate(PUTemplate[1], position, Quaternion.identity, spawnArea);
            PU.SetActive(true);
            paddleSpdPUList.Add(PU);
            if (!paddleSpdStartCoroutine)
            {
                paddleSpdCoroutine = StartCoroutine(DespawnPU(powerUP));
            }
        } 
        else if (powerUP == PUTemplate[2])
        {
            PU = Instantiate(PUTemplate[2], position, Quaternion.identity, spawnArea);
            PU.SetActive(true);
            paddleLengthPUList.Add(PU);
            if (!paddleLengthStartCoroutine)
            {
                paddleLengthCoroutine = StartCoroutine(DespawnPU(powerUP));
            }
        } 
        else
        {
            Debug.Log("Error GameObject. Null object found");
            return;
        }
        
        
    }

    private bool spawnLimitValidation(Vector3 position, GameObject powerUP)
    {
        if (powerUP == PUTemplate[0])
        {
            if (ballPUList.Count >= maxBallPUList)
            {
                return false;
            } 
        } 
        else if (powerUP == PUTemplate[1])
        {
            if (paddleSpdPUList.Count >= maxPaddleSpdPUList)
            {
                return false;
            } 
        } 
        else if (powerUP == PUTemplate[2])
        {
            if (paddleLengthPUList.Count >= maxPaddleLengthPUList)
            {
                return false;
            } 
        }
        
        if (position.x < PUAreaMin.x ||
            position.y < PUAreaMin.y ||
            position.x > PUAreaMax.x ||
            position.y > PUAreaMax.y)
        {
            return false;
        } 
        else 
        {
            return true;
        }
        
    }

    public void RemoveBallPU(GameObject PU)
    {
        ballPUList.Remove(PU);
        Destroy(PU);
        ballStartCoroutine = false;
        StopCoroutine(ballCoroutine);
    }

    public void RemovePaddleSpdPU(GameObject PU)
    {
        paddleSpdPUList.Remove(PU);
        Destroy(PU);
        paddleSpdStartCoroutine = false;
        StopCoroutine(paddleSpdCoroutine);
    }

    public void RemovePaddleLengthPU(GameObject PU)
    {
        paddleLengthPUList.Remove(PU);
        Destroy(PU);
        paddleLengthStartCoroutine = false;
        StopCoroutine(paddleLengthCoroutine);
    }

    public void RemoveAllPU()
    {
        while (ballPUList.Count > 0)
        {
            RemoveBallPU(ballPUList[0]);
        }

        while (paddleSpdPUList.Count > 0)
        {
            RemovePaddleSpdPU(paddleSpdPUList[0]);
        }

        while (paddleLengthPUList.Count > 0)
        {
            RemovePaddleLengthPU(paddleLengthPUList[0]);
        }
        
    }

    public void ResetPUTimer()
    {
        ballPUTimer = 0;
        paddleSpdPUTimer = 0;
        paddleLengthPUTimer = 0;
    }
}
