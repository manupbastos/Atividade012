using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogao : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            anim.SetBool("fire", false);
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("fire", true);
    }
}
