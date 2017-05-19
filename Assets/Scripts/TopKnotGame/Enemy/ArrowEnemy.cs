using UnityEngine;
using System.Collections;

public class ArrowEnemy : EnemyBase 
{
    public GameObject ArrowPrefab;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    //Different Variation of atk
    protected override void Attack()
    {
        GameObject arrow = Instantiate(ArrowPrefab);
        arrow.transform.position = transform.position;
        arrow.GetComponent<ProjectileScript>().SetPoints(100);
        arrow.GetComponent<ProjectileScript>().SetDamage(50);
        base.Attack();
    }
}
