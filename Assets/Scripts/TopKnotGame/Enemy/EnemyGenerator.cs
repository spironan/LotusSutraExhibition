using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyGenerator : MonoBehaviour 
{
    //List Of Different Items
    public List<GameObject> itemPrefab = new List<GameObject>();
    //List Of Spawn Points and Boolean to Determine if Spot is Used
    public List<Vector3> spawnPosition = new List<Vector3>();
    List<bool> usedPoints = new List<bool>();
    //List of Enemies that the Generator Spawned
    List<EnemyBase> enemies = new List<EnemyBase>();
    //Time Interval For Every Increase
    public float diffIncreaseTime;
    float currTime;
    bool toIncrement = false;
    //Amount of Increase Before Major Increase
    public int timeToMajorIncrement;
    int timeBeforeMajorIncrement;
    bool majorIncrement = false;
    int index;

    //Generator Logic
    // difficulty(according to Time,3 Minutes 15 seconds Gameplay, 15 seconds each minor increment,major difficulty increase every minute)
    // difficulty = four things : Spawning Destructive Enemies AND Attack Faster (Lower CoolDown) AND Stronger Attacks AND Spawning Enemies to dodge 
    // difficulty increases 3 minor times and 1 major time a minute. 9 minor time and 3 major time.
    // Minor Increment : minute attack speed buff, increase chance in using stronger attacks
    // Major Increment : Spawn More Enemies, Enemy permenant upgrade to use better attacks
    // Boolean to Determine When to Start Spawn (Countdown before Start etc)

	// Use this for initialization
	void Start () 
    {
        currTime = 0.0f;
        timeBeforeMajorIncrement = timeToMajorIncrement;
	    foreach(Vector3 position in spawnPosition)
            usedPoints.Add(false);

        index = Random.Range(0, spawnPosition.Count);
        SpawnEnemy();
	}

    void IncreaseDifficulty()
    {
        if (!majorIncrement)
        {
            foreach (EnemyBase enemy in enemies)
            {
                enemy.MinorPowerUp();
            }
            timeBeforeMajorIncrement--;
            if (timeBeforeMajorIncrement == 0)
            {
                timeBeforeMajorIncrement = timeToMajorIncrement;
                majorIncrement = true;
            }
        }
        else
        {
            foreach (EnemyBase enemy in enemies)
            {
                enemy.MajorPowerUp();
            }
        }
        toIncrement = false;
    }

    public void SpawnEnemy()
    {
        while (usedPoints[index])
        {
            index = Random.Range(0, spawnPosition.Count);
        }
        GameObject enemy = Instantiate(itemPrefab[Random.Range(0, itemPrefab.Count)]);
        enemy.transform.position = spawnPosition[index];
        usedPoints[index] = true;
    }

	// Update is called once per frame
	void Update () 
    {
        if (toIncrement)
            IncreaseDifficulty();
        else if (currTime < diffIncreaseTime)
            currTime += Time.deltaTime;
        else
        {
            currTime = 0.0f;
            toIncrement = true;
        }
	}

}
