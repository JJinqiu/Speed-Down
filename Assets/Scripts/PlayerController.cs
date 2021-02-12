using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private Animator _animator;

    public float speed;
    private float _xVelocity;

    public float checkRadius;
    public LayerMask platform;
    public GameObject groundCheck;
    private bool _isOnGround;

    private bool _isPlayerDead;

    // Start is called before the first frame update
    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        _isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, platform);
        _animator.SetBool("isOnGround", _isOnGround);
        Movement();
    }

    private void Movement()
    {
        _xVelocity = Input.GetAxisRaw("Horizontal");
        _rb2d.velocity = new Vector2(_xVelocity * speed, _rb2d.velocity.y);

        _animator.SetFloat("speed", Mathf.Abs(_rb2d.velocity.x));
        if (_xVelocity != 0)
            transform.localScale = new Vector3(_xVelocity, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("spike"))
        {
            _animator.SetTrigger("dead");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Fan"))
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, 8f);
        }
    }

    public void PlayerDead()
    {
        _isPlayerDead = true;
        GameManager.GameOver(_isPlayerDead);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);
    }
}