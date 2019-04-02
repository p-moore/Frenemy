using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyController : PlayerController
{
    override public void Ability()
    {
        Debug.Log("Spy");
    }
}
