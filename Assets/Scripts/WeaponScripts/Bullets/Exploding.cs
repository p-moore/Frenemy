using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploding : Bullet
{
    public Explosion explosion;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Ground") || (other.gameObject.CompareTag("Player") && other.gameObject != owner))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }


}
