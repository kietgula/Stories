using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public GameObject Target;
    public float speed;

    private bool isFollowing;
    private bool isBouncing;

    public Rigidbody2D rb;

    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        nextBounceTime = Time.time + BounceDelay;
        isFollowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        LetTheBossThink();

        if (isFollowing)
            FollowTarget();
        else if (isBouncing)
            Bounce();
    }

    void LetTheBossThink()
    {
        if (nextBounceTime < Time.time)
        {
            isBouncing = true;
            isFollowing = false;
            nextBounceTime = Time.time + BounceDelay;
        }
        else
        {
            isFollowing = true;
            isBouncing = false;
        }
    }

    void FollowTarget()
    {
        var newPos = Target.transform.position - this.transform.position;
        newPos.Normalize();
        newPos = newPos * speed * Time.deltaTime;
        this.transform.Translate(newPos);

    }

    private float nextBounceTime;
    public float BounceDelay;
    public float BouncePower;
    void Bounce()
    {
        rb.velocity = new Vector2(UnityEngine.Random.Range(-1f,1f), UnityEngine.Random.Range(-1f, 1f)) * BouncePower;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.GetComponent<GameManager>().GameOver();
        }
    }

}
