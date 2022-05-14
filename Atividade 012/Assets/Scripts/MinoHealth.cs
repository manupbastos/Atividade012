using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoHealth : MonoBehaviour
{
	public int health = 500;

	public bool isInvulnerable = false;
	private Rigidbody2D rig;
	private Animator anim;
	public GameObject drop;
	void Start()
	{
		rig = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

	}

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;
		anim.SetTrigger("hurt");
		isInvulnerable = true;

		if (health <= 200)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			rig.velocity = new Vector2(0, rig.velocity.y);

			anim.SetBool("IsDead", true);
			StartCoroutine(Die());
		}
	}
    private void OnCollisionExit2D(Collision2D collision)
    {
		anim.ResetTrigger("hurt");
		isInvulnerable = false;
    }

	IEnumerator Die()
	{
		yield return new WaitForSeconds(5f);
		Destroy(gameObject);
		Instantiate(drop, transform.position, Quaternion.identity);

	}
}