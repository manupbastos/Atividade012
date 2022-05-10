using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;

    private AudioSource sound;

    public int Score;

    public GameObject collected;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
        
        sound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sound.Play();
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            Gamecontroller.instance.totalScore += Score;
            Gamecontroller.instance.UpdateScoreText();


            Destroy(gameObject, 0.25f);
        }
    }
}
