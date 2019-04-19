using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    //Holds all weapons to be spawned (Picks on at random)
    public Weapon[] weapons;
    //Current Weapon held by Weapon spawner. Used to determine weather a new weapon needs to spawn here
    public Weapon heldWeapon;
    //Current cooldown time
    private float cooldown;
    //How long the cooldown lasts (In seconds)
    public float cooldownTime;
    bool hasWeapon = false;

    public Animator animator;

    public void SpawnWeapon()
    {
        
        Weapon newWeapon = Instantiate(weapons[Random.Range(0,weapons.Length)], transform.position, transform.rotation);
        heldWeapon = newWeapon;
        heldWeapon.isHeld = true;
        hasWeapon = true;
        animator.ResetTrigger("SpawnWeaponTrigger");
    }
    
    void SetCoolDown()
    {
        cooldown = Time.time + cooldownTime;
    }

    void Awake()
    {
    }

    void Update()
    {


        if(heldWeapon != null && heldWeapon.transform.parent != null)
        {
            if (heldWeapon.transform.parent.gameObject.CompareTag("Player"))
            {
                heldWeapon = null;
                hasWeapon = false;
                SetCoolDown();
            }
        }

        if (!hasWeapon && cooldown <= Time.time)
        {
            animator.SetTrigger("SpawnWeaponTrigger");
        }

    }

}
