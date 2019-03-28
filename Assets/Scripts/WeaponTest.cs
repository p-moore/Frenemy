using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTest : MonoBehaviour
{
    PlayerController parent;

    void Start()
    {
        parent = transform.parent.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon") { parent.touchingWeapons.Add(other.gameObject); }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon")) { parent.touchingWeapons.Remove(other.gameObject); }
    }
}
