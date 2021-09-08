using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    Rigidbody2D body2D;
    public float _force = 80f;
    private Vector2 spawnPoint;
    public Text _hitText;
    public Text _scoreText;
    int hits;
    int points;
    

    // Start is called before the first frame update
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        spawnPoint = body2D.position;
        hits = 0;
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        controlMovement();
        _hitText.text = "Hits: " + hits;
        _scoreText.text = "Score: " + points;
    }

    void controlMovement()
    {
        float xForce = 0f;
        float yForce = 0f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xForce = _force;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xForce = -_force;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            yForce = _force;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            yForce = -_force;
        }
        body2D.velocity = new Vector2(xForce, yForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            body2D.position = spawnPoint;
            hits += 1;
            StartHitAnimation();
        }
        if (collision.collider.CompareTag("Collectible"))
        {
            spawnPoint = body2D.position;
            points += 1;
            Destroy(collision.collider.gameObject);
            GameManager.Instance.moveDodgeballs();
            GameManager.Instance.moveCollectibles();
        }
    }

    void StartHitAnimation()
    {
        GetComponent<Animator>().Play("player-hit");
    }

    void StopHitAnimation()
    {
        GetComponent<Animator>().Play("player-idle");
    }
}
