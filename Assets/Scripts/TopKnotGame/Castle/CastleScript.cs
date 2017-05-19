using UnityEngine;
using System.Collections;

public class CastleScript : MonoBehaviour 
{
    public float maxHealth;
    float health;
    bool isDead = false;
	// Use this for initialization
	void Start () 
    {
        health = maxHealth;
	}

    public float GetHealth()
    {
        return health/maxHealth;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("taking Damage : " + damage);
        this.health -= damage;
        if (health <= 0.0f)
            isDead = true;
    }
    public bool IsDead() { return isDead; }
	// Update is called once per frame
	void Update () {
	}
}
