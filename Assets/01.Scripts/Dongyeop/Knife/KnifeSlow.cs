using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KnifeSlow : MonoBehaviour
{
    public static KnifeSlow Instance;

    [SerializeField] private float _timeScele = .75f;
    private PolygonCollider2D _collider;

    private void Awake() 
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
            
        _collider = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
            Time.timeScale = _timeScele;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
            Time.timeScale = 1;
    }

    public void Shoot()
    {
        _collider.enabled = false;
        Time.timeScale = 1;
    }

    public void ReGame()
    {
        _collider.enabled = true;
        Time.timeScale = 1;
    }
}
