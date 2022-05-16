using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogao : MonoBehaviour
{
    private Animator anim;
    public GameObject drop;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            anim.SetBool("fire", true);
            StartCoroutine(Drop());
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("fire", false);
    }
    IEnumerator Drop()
    {
        yield return new WaitForSeconds(8f);
        Instantiate(drop, transform.position, Quaternion.identity);

    }
}
