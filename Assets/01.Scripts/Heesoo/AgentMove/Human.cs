using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
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
        Flip();
        Move();
    }

    IEnumerator MoveCoroutine()
    {
        while (true)
        {
            float delay = Random.Range(0, 4);
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
        int random = Random.Range(0, 2);

        if (random == 0)
        {
            dir = Vector2.right;
        }
        else if (random == 1)
        {
            dir = Vector2.left;
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
