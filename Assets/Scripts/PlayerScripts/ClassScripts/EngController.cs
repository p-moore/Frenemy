using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngController : PlayerController
{
    [SerializeField] float CurrentArmor;
    [SerializeField] float MaxArmor;
    [SerializeField] float ArmorToBeRestored;
    [SerializeField] Bar ArmorBar;

    private void UpdateArmorBar()
    {
        ArmorBar.SetBar(CurrentArmor / MaxArmor);
    }

    public override void DamageEvent(float Damage)
    {
        
        if (CurrentArmor <= 0)
        {
            base.DamageEvent(Damage);
        }
        else
        {
            audioPlayer.PlayOneShot(soundEffect[2]);
            CurrentArmor -= Damage;
            if (CurrentArmor < 0) { CurrentArmor = 0; }
            UpdateArmorBar();
        }
    }

    protected override void Flip()
    {
        base.Flip();
        ArmorBar.transform.Rotate(new Vector3(0, 180, 0));
    }

    override protected void Start()
    {
        base.Start();
        UpdateArmorBar();
    }

    public override void Ability()
    {
        if (Input.GetButtonDown("Ability" + id))
        {
            CurrentArmor += ArmorToBeRestored;
            if (CurrentArmor > MaxArmor) { CurrentArmor = MaxArmor; }
            UpdateArmorBar();
        }
    }
}