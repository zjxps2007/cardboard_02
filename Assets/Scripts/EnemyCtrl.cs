using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    private int HP = 50;
    private float moveSpeed = 2.0f;
    private float distance2Player;
    public GameObject player;
    private PlayerCtrl playerState;
    private Animator anim;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerState = player.GetComponent<PlayerCtrl>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance2Player = Vector3.Distance(this.transform.position, player.transform.position);

        if (distance2Player > 9.0f)
        {
            Move();
        }
        else
        {
            StartCoroutine(Attack());
        }
    }

    void Move()
    {
        this.transform.LookAt(player.transform);
        this.transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    IEnumerator Attack()
    {
        anim.SetBool("Shot", true);
        yield return new WaitForSeconds(1.0f);

        Destroy(this.gameObject);
        playerState.HP -= 10;
        playerState.UpdatetState();
    }

    IEnumerator DelayMove()
    {
        anim.SetBool("Hit", true);
        float tempSpeed = moveSpeed;

        moveSpeed = 0.0f;

        yield return new WaitForSeconds(0.3f);

        moveSpeed = tempSpeed;
        anim.SetBool("Hit", false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            HP -= 10;
            
            Destroy(other.gameObject);
            StartCoroutine(DelayMove());

            if (HP <= 0)
            {
                Destroy(this.gameObject);
                playerState.score += 100;
                playerState.UpdatetState();
            }
        }
    }
}