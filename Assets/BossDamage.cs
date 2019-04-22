using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    [SerializeField]float Damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.DamageEvent(Damage);
        }
    }
}
