using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FillScript : MonoBehaviour {

    Image circle;
    WinConScript winCon;
	// Use this for initialization
    void Start()
    {
        circle = GetComponent<Image>();
        winCon = GameObject.FindGameObjectWithTag("WinCon").GetComponent<WinConScript>();
	}
	
	// Update is called once per frame
	void Update () {
        circle.fillAmount = winCon.GetPercentage();
	}
}
