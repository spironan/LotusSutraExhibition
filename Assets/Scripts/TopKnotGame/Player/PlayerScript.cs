using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    bool moveleft = false, moveright = false;
    public float speed;
    float points;
    Vector3 dir;
    Vector3 accel;
    public float move_threshold;// A Value from 0 - 1 

	// Use this for initialization
	void Start () 
    {
        points = 0;
        dir = new Vector3(0, 0, 0);
	}

    public float GetPoints()
    {
        return points;
    }

    public void AddPoints(int points)
    {
        this.points += points;
    }

	// Update is called once per frame
	void Update () 
    {
#if UNITY_ANDROID
        //AccelerometerCheck();
        if (MoveLeftCon())
        {
            MoveLeft();
        }
        else if (MoveRightCon())
        {
            MoveRight();
        }
#endif
	}

    void AccelerometerCheck()
    {
        //accel = Vector3.Lerp(accel, Input.acceleration, move_threshold * Time.deltaTime);
        Vector3 direction = new Vector3(-Input.acceleration.x + 0.5f, 0, 0);
        if (direction.sqrMagnitude > 1)
            direction.Normalize();
        if (direction.x > move_threshold)
            moveleft = true;
        else if (direction.x < move_threshold)
            moveright = true;
        else if (moveleft || moveright)
            moveleft = moveright = false;

        //if(Input.acceleration.x > move_threshold)
        //    if(Mathf.Sign(Input.acceleration.x) == -1)
        //    {
        //        moveleft = true;
        //    }
        //    else if(Mathf.Sign(Input.acceleration.x) == 1)
        //    {
        //        moveright = true;
        //    }
    }

    bool MoveLeftCon()
    {
        return (Input.GetKey("a") || Input.GetKey("left") || moveleft);
    }

    public void MoveLeft()
    {
        dir = new Vector3(-1, 0, 0);
        transform.position += dir * speed * Time.deltaTime;
    }

    bool MoveRightCon()
    {
        return (Input.GetKey("d") || Input.GetKey("right") || moveright);
    }

    public void MoveRight()
    {
        dir = new Vector3(1, 0, 0);
        transform.position += dir * speed * Time.deltaTime;
    }

    public void SetLeft(bool moveLeft)
    {
        moveleft = moveLeft;
    }

    public void SetRight(bool moveRight)
    {
        moveright = moveRight;
    }


}