using UnityEngine;
using System.Collections;
using System.Collections.Generic;

////UNUSED SCRIPT
//public class GroundScript : MonoBehaviour {

//    public GameObject telePrefab;
//    public Vector3 margin;
//    List<GameObject> teleporters = new List<GameObject>();
//    // Use this for initialization
//    void Start () {
//        for (int i = -1; i <= 1; i+=2)
//        {
//            GameObject go = Instantiate(telePrefab);
//            go.transform.localPosition = transform.position + i * new Vector3((transform.localScale.x / 20.0f),0,0) + margin ;
//            teleporters.Add(go);
//            if (i == 1)
//            {
//                go.GetComponent<Teleporter>().other = teleporters[0];
//                teleporters[0].GetComponent<Teleporter>().other = go;
//            }
//        }
//    }

//}
