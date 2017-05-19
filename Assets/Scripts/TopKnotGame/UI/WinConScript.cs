using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinConScript : MonoBehaviour 
{
    public GameObject startTextObj,winTextObj,loseTextObj,generator,castle;
    EnemyGenerator generatorScript;
    CastleScript castleScript;
    public float timerToWin;
    public float startAnimDur;
    float winTime;
    bool win = false;
    bool lose = false;

    void Start()
    {
        generatorScript = generator.GetComponent<EnemyGenerator>();
        castleScript = castle.GetComponent<CastleScript>();
        winTextObj.SetActive(false);
        winTime = timerToWin;
        StartCoroutine(PlayStartAnim());
    }

    IEnumerator PlayStartAnim()
    {
        startTextObj.SetActive(true);
        Time.timeScale = 0.00001f;
        yield return new WaitForSeconds(startAnimDur * Time.timeScale);
        Time.timeScale = 1.0f;
        startTextObj.SetActive(false);
    }

    public float GetPercentage()
    {
        return (winTime - timerToWin)/winTime;
    }

    public string GetTimeLeft()
    {
        int timeMinute = (int)timerToWin / 60;
        string timeLeft = "";
        if (timeMinute > 0)
        {
            int timeSeconds = (int)(timerToWin - timeMinute * 60);
            if(timeSeconds < 10)
                timeLeft = timeMinute + ":0" + timeSeconds;
            else
                timeLeft = timeMinute + ":" + timeSeconds;
        }
        else
        {
            float timeSeconds = timerToWin - timeMinute * 60;
            timeLeft = timeSeconds + "";
        }
        return timeLeft;
    }

	// Update is called once per frame
	void Update () 
    {
        DebugCode();

        if (timerToWin >= 0)
            timerToWin -= Time.deltaTime;
        else if (!win)
        {
            timerToWin = 0.0f;
            win = true;
        }   

        if (castleScript.IsDead())
            lose = true;

        if (lose)
        {
            Time.timeScale = 0.0f;
            loseTextObj.SetActive(true); 
        }
        if (win)
        {
            Time.timeScale = 0.0f;
            winTextObj.SetActive(true);
        }
	}

    public void DebugCode()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            timerToWin = 5.0f;

        if (Input.GetKeyDown(KeyCode.X))
            generatorScript.SpawnEnemy();
    }

}
