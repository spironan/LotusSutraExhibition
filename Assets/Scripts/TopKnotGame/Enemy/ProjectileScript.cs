using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour 
{
    int points;//How Much Points this Item Is Worth if Blocked
    float damage;//How Much Damage this deals

    public float GetDamage() { return damage; }
    public void SetDamage(float damage) { if (damage >= 0) this.damage = damage; }

    public int GetPoints() { return points; }
    public void SetPoints(int points) { if (points >= 0) this.points = points; }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.tag)
        {
            case "Player":
                other.GetComponent<PlayerScript>().AddPoints(points);
                Destroy(gameObject);
                break;
            case "Castle":
                other.GetComponent<CastleScript>().TakeDamage(damage);
                Destroy(gameObject);
                break;
        }

    }
}
