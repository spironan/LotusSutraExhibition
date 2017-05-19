using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {

    Image parent;
    Text timeText;
    WinConScript winCon;

	// Use this for initialization
	void Start () {
        parent = transform.parent.GetComponent<Image>();
        timeText = gameObject.GetComponent<Text>();
        winCon = GameObject.FindGameObjectWithTag("WinCon").GetComponent<WinConScript>();
	}
	
	// Update is called once per frame
	void Update () {
        //timeText.text = (int)(parent.fillAmount * 100) + "%";
        timeText.text = winCon.GetTimeLeft();
	}
}
