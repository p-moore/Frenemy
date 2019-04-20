using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyController : PlayerController
{
    bool isInvis;

    protected override void Start()
    {
        base.Start();
        isInvis = false;
    }

    private void SetInvis(bool option)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = !option;
        bar.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = !option;
        bar.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().enabled = !option;
        isInvis = option;
        audioPlayer.PlayOneShot(soundEffect[0]);
    }

    override public void Ability()
    {
        if (Input.GetButtonDown("Ability" + id))
        {
            if (!isInvis)
            {
                SetInvis(true);
            }
            else
            {
                SetInvis(false);
            }
        }
    }
}
