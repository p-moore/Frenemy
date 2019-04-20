using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject owner;
    public int speed;
    public float damage;

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject != owner)
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.DamageEvent(damage);
        }

        if (other.gameObject.CompareTag("Ground") || (other.gameObject.CompareTag("Player") && other.gameObject != owner))
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
