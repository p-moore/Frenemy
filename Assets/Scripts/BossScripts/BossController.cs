using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]private float CurrentHp = 10;
    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float timeLeft;
    private float timeLeftToShoot;
    private float shootTime = 5f; 
    private Rigidbody2D rb;
    [SerializeField]private Bullet bossBullet;
    public GameController gamecontroller;
    [SerializeField] AudioClip[] SoundEffects;
    [SerializeField] AudioSource audioPlayer;

    void Shoot()
    {
        for (int i = 0; i < 360; i += 15)
        {
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(0,0,i);
            Bullet bulletClone = Instantiate(bossBullet, transform.position, rot);
            bulletClone.owner = transform.gameObject;
        }
    }

    public void setHp(float Damage)
    {
        audioPlayer.PlayOneShot(SoundEffects[0]);
        CurrentHp -= Damage;
        if (CurrentHp <= 0)
        {
            audioPlayer.PlayOneShot(SoundEffects[1]);
            gamecontroller.isBossDead = true;
            gamecontroller.checkGameover();
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftToShoot -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                
            timeLeft += accelerationTime;
        }
        if(timeLeftToShoot <= 0)
        {
            Shoot();
            timeLeftToShoot = shootTime;
        }

        if (Mathf.Sign(movement.x) == 1)
        {
            if (transform.rotation.y == 0)
            {
                transform.Rotate(new Vector3(0, 180, 0)); 
            }
        }
        else
        {
            if (transform.rotation.y == -1)
            {
                transform.Rotate(new Vector3(0, -180, 0));
            }
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }

}
