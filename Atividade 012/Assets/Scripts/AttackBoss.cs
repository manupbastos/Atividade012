using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoss : MonoBehaviour
{
    public Transform attackCheck;
    public float radiusAttack;
    public LayerMask layerEnemy;
    float timeNextAttack;
    public int damage;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Attack();

    }

    void Attack()
    {
        if (timeNextAttack <= 0f)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("attack");
                timeNextAttack = 0.2f;
                AttackMino();

            }
        }
        else
        {
            timeNextAttack -= Time.deltaTime;
        }
    }
    void Flip()
    {
        attackCheck.localPosition = new Vector2(-attackCheck.localPosition.x, attackCheck.localPosition.y);
    }

    void AttackMino()
    {
        Collider2D[] bossToDamage = Physics2D.OverlapCircleAll(attackCheck.position, radiusAttack, layerEnemy
            );
        for (int b = 0; b < bossToDamage.Length; b++)
        {
            bossToDamage[b].GetComponent<MinoHealth>().TakeDamage(damage);

        }
    }

}
