using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    public bool walk;
    public float speed;
    public Transform rightCol;
    public Transform leftCol;
    private bool colliding;

    public LayerMask layer;
    public int health;
    public GameObject drop;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walk == true)
        {

            anim.SetBool("walk", true);
            rig.velocity = new Vector2(speed, rig.velocity.y);

            colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);
            if (colliding)
            {
                transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
                speed *= -1f;
            }
        }
        if (health <= 0)
        {
            rig.velocity = new Vector2(0, rig.velocity.y);
            anim.SetBool("IsDead", true);
            StartCoroutine(Die());

        }

    }
    public void TakeDamage(int damage)
    {
        
        anim.SetTrigger("hurt");
        health -= damage;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.ResetTrigger("hurt");
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
        Instantiate(drop, transform.position, Quaternion.identity);

    }

}