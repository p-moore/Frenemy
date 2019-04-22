using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int damage;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.DamageEvent(damage);
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            BossController Boss = other.GetComponent<BossController>();
            Boss.setHp(damage);
        }
    }
    
    public void ExplosionEnd()
    {
        Destroy(this.gameObject);
    }



}
