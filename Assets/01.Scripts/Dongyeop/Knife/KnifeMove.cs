using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMove : MonoBehaviour
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

    public void KnifeMovement(Vector3 targetPos)
    {
        Vector3 movePosition = (targetPos - transform.localPosition).normalized;
    }
}
