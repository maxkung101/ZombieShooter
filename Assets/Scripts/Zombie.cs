using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Objects
{
    public int points = 1, damage = 1;
    public CharacterController controller;
    public float speed;
    public Transform player;
    public AudioSource attackingSound, deathSound;

    private Animator anim;
    private AudioSource source;
    private bool zombieIsAlive, zombieIsAttacking;
    private Vector3 velocity;
    private float totalTime, attackTimer, timeToDisappear, disappearTimer;

    // Use this for initialization
    public override void Init()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        zombieIsAlive = true;
        zombieIsAttacking = false;
        totalTime = 2;
        attackTimer = 0;
        timeToDisappear = 10;
        disappearTimer = 0;
    }

    public override void LookAtIt()
    {
        
    }

    public override void StopLooking()
    {
        
    }

    public override void ObjectMove()
    {
        transform.LookAt(player);
        velocity = speed * transform.forward * Time.deltaTime;
        if (zombieIsAttacking)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > totalTime)
            {
                ScoreManager.instance.TakeDamage(damage);
                attackTimer = 0;
            }
        }
        else
        {
            if (GetComponent<CharacterController>().enabled)
            {
                controller.Move(velocity);
            }
            else
            {

            }
        }

        if (!zombieIsAlive)
        {
            if (disappearTimer > timeToDisappear)
            {
                Destroy(gameObject);
            }
            else
            {
                disappearTimer += Time.deltaTime;
            }
        }
    }

    public override void ObjectEvent()
    {
        if (gvrStatus && zombieIsAlive)
        {
            speed = 0f;
            source.Stop();
            ScoreManager.instance.UpdateScore(points);
            zombieIsAlive = false;
            anim.SetBool("isAlive", false);
            if (anim.GetBool("isAttacking"))
            {
                anim.SetBool("isAttacking", false);
            }
            if (zombieIsAttacking)
            {
                zombieIsAttacking = false;
                attackingSound.Stop();
            }
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            deathSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            zombieIsAttacking = true;
            anim.SetBool("isAttacking", true);
            source.Stop();
            attackingSound.Play();
        }
    }
}
