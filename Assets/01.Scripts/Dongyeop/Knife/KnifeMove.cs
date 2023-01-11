using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMove : MonoBehaviour //Knife의 움직임을 담당하는 스크립트
{
    [SerializeField] private float _moveSpeed;
    private Rigidbody2D _rigidbody2D;

    private void Awake() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        _rigidbody2D.velocity = transform.up * _moveSpeed;
    }
}
