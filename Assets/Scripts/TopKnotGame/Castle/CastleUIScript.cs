using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CastleUIScript : MonoBehaviour 
{
    CastleScript castleScript;
    Image image;
	// Use this for initialization
	void Start () {
        castleScript = GameObject.FindGameObjectWithTag("Castle").GetComponent<CastleScript>();
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        image.fillAmount = castleScript.GetHealth();
	}
}
