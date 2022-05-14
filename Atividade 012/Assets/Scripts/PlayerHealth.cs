using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
	public int health = 100;
	private Animator anim;


	public void TakeDamage(int damage)
	{
		health -= damage;
		StartCoroutine(DamageAnimation());

		if (health <= 0)
		{
			Die();
		}
	}
	

	void Die()
	{
		Gamecontroller.instance.ShowGameOver();
		Destroy(gameObject);
	}
	IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}
}

