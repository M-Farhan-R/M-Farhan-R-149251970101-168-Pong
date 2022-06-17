using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUManager : MonoBehaviour
{
    public Vector2 PUAreaMin,PUAreaMax;

    //Template untuk komponen SpeedUp yang akan diduplukasi objeknya
    public List<GameObject> PUTemplate;

    //Menampung banyak clone dari komponen SpeedUp
    private List<GameObject> PUList;
    
    public int maxPUBallList;

    //Sebagai wadah spawn(?)
    public Transform spawnArea;
    
    private float timer;
    public int spawnPUBallInterval, despawnPUBallInterval;

    public Coroutine ballCoroutine;

    //untuk cek coroutine start
    public bool ballStartCoroutine;

    void Start()
    {
        PUList = new List<GameObject>();
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnPUBallInterval)
        {
            GenerateRandomPU();
            timer -= spawnPUBallInterval;
            
        }
    }
    
    IEnumerator DespawnBall()
    {
        //
        ballStartCoroutine = true;
        Debug.Log("Enter Despawn Countdown");
        yield return new WaitForSeconds(despawnPUBallInterval);
        Debug.Log("After seconds");
        RemovePU(PUList[0]);
        ballStartCoroutine = false;
    }

    public void GenerateRandomPU()
    {
        GenerateRandomPU(new Vector3(Random.Range(PUAreaMin.x, PUAreaMax.x),
                                    Random.Range(PUAreaMin.y, PUAreaMax.y),
                                    0));
    }

    public void GenerateRandomPU(Vector3 position)
    {
        if (PUList.Count >= maxPUBallList)
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
        
        int randomIndex = Random.Range(0, PUList.Count);
    
        GameObject PU = Instantiate(PUTemplate[randomIndex], position, Quaternion.identity, spawnArea);
        PU.SetActive(true);

        PUList.Add(PU);
        
        if (!ballStartCoroutine)
        {
            ballCoroutine = StartCoroutine(DespawnBall());
        }
    }

    public void RemovePU(GameObject PU)
    {
        PUList.Remove(PU);
        Destroy(PU);
    }

    public void RemoveAllPU()
    {
        while (PUList.Count > 0)
        {
            RemovePU(PUList[0]);
        }
    }
}
