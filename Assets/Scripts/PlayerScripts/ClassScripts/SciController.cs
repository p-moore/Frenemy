using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SciController : PlayerController
{
    [SerializeField] float healAmount;

    public override void Ability()
    {
        if(Input.GetButtonDown("Ability" + id))
        {
            setHP(currentHp + healAmount);
        }
    }
}
