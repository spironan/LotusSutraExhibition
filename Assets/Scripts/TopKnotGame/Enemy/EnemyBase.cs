using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour 
{
    protected float atkSpd;//How Many Attacks Per Second
    protected float currSpd;//How Long Left To Next Attack
    protected float dmg;//How Much Damage Per Attack
    protected bool atk;//Whether to attack or not

    public virtual void MinorPowerUp() { Debug.Log("Minor Difficulty Increase Called"); }// Different Variation of Minor Power Up
    public virtual void MajorPowerUp() { Debug.Log("Major Difficulty Increase Called"); }// Different Variation of Major Power Up

    //Different variation of Loading Attack
    protected virtual void LoadingAttack()
    {
        if (currSpd < atkSpd)
            currSpd += Time.deltaTime;
        else
        {
            currSpd = 0.0f;
            atk = true;
        }
    }

    //Different Variation of atk
    protected virtual void Attack() 
    {
        atk = false; 
    }

    protected void Init(float atkSpd,float dmg)
    {
        this.atkSpd = atkSpd;
        this.dmg = dmg;
        atk = false;
        currSpd = 0.0f;
    }

	// Use this for initialization
    protected virtual void Start()
    {
        atk = false;
        currSpd = 0.0f;
        dmg = 0;
        atkSpd = 1.0f;
	}
	
	// Update is called once per frame
    protected virtual void Update() 
    {
        if (!atk)
            LoadingAttack();
        else
            Attack();
	}
}
