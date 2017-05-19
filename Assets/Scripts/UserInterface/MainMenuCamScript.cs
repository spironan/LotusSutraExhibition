using UnityEngine;
using System.Collections;

public class MainMenuCamScript : MonoBehaviour 
{
    //public Vector3 targetDest;
    //public float camSpeed;
    //Vector3 movement;
    //int numFrames;
    Animator animator;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    public void GoToGameSelect()
    {
        animator.SetInteger("camState", 2);
    }

    public void GoToMainMenu()
    {
        animator.SetInteger("camState", 1);
    }

    //public void GoToLoadingScreen()
    //{
    //    movement = (targetDest - this.gameObject.transform.position).normalized * camSpeed;
    //    numFrames = (int)((targetDest - this.gameObject.transform.position).sqrMagnitude / movement.sqrMagnitude);
    //}

    //void Update()
    //{
    //    if (numFrames > 0)
    //    {
    //        this.gameObject.transform.Translate(movement, this.gameObject.transform);
    //        numFrames--;
    //    }
    //}
}
