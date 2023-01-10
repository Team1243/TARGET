using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Real,
    Fake
}

public class Enemy : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigid;
    
    public EnemyType Type;
    public float moveSpeed;

    private Vector2 dir;
    private bool isDead = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigid = GetComponent<Rigidbody2D>();   
    }

    private void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    private void Update()
    {
        Flip();
        Move();
    }

    IEnumerator MoveCoroutine()
    {
        while (true)
        {
            float delay = Random.Range(0, 3);
            yield return new WaitForSeconds(delay);

            ChangeDir();
        }
    }

    private void Move()
    {
        _rigid.position += dir * moveSpeed * Time.deltaTime;
    }

    private void ChangeDir()
    {
        int random = Random.Range(0, 3);
    
        if (random == 0)
        {
            dir = Vector2.right;
        }
        else if (random == 1)
        {
            dir = Vector2.left;
        }
        else if (random == 2)
        {
            dir = Vector2.zero;
        }
    }

    private void Flip()
    {
        if (dir == Vector2.right)
        {
            _spriteRenderer.flipX = true;
        }
        else if (dir == Vector2.left)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
