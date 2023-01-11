using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigid;
    
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
        if (RoundSystem.Instance.roundCount < 15)
        {
            dir = Vector2.zero;
        }

        Flip();
        Move();
    }

    IEnumerator MoveCoroutine()
    {
        while (true)
        {
            float delay = Random.Range(1, 3);
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
        int random = Random.Range(0, 5);
        
        if (random == 0 || random == 3)
        {
            dir = Vector2.right;
        }
        else if (random == 1 || random == 4)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("OutLine"))
        {
            OutLine outLine = collision.GetComponent<OutLine>();

            if (outLine.dirType == DirType.Right)
            {
                dir = Vector2.left;
            }
            else if (outLine.dirType == DirType.Left)
            {
                dir = Vector2.right;
            }
        }
    }
}
