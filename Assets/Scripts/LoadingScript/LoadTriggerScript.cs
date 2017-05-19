using UnityEngine;
using System.Collections;

public class LoadTriggerScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {

        }
    }
}
