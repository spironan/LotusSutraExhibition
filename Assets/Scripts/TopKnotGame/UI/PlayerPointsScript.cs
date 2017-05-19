using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPointsScript : MonoBehaviour 
{
    Text text;
    public GameObject player;
    PlayerScript playerData;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        playerData = player.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "" + playerData.GetPoints();
	}
}
