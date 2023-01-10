using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Knife : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _knife;
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private Vector3 _knifeMoveMaxPos;
    [SerializeField] private float _rotationTime;
    [SerializeField] private float _moveTime;

    private GameState _gameState = GameState.Ready;
    private Transform _knifeRotator;
    private Transform _knifeTrm;

    private int _knifeRotationIndex;

    private void Awake() 
    {
        _knifeRotator = GameObject.Find("Knife_Rotator").GetComponent<Transform>();
        _knifeTrm = _knife.GetComponent<Transform>();
    }

    private void Start() 
    {
        _gameState = GameState.Ready;
    }

    private void Update() 
    {
        if (GameManager.Instance.DebuggingState == DebuggingState.Debugging)
        {
            if (Input.GetMouseButtonDown(0) && _gameState == GameState.Flying)
                KnifeShoot();
            else if (Input.GetMouseButtonDown(0) && _gameState == GameState.Ready)
            {
                _gameState = GameState.Flying;
                KnifeRotation();
                KnifeMove();
            }
        }
        else
        {
            if (Input.touchCount > 0 && _gameState == GameState.Flying)
                KnifeShoot();
            else if (Input.touchCount > 0 && _gameState == GameState.Ready)
            {
                _gameState = GameState.Flying;
                KnifeRotation();
                KnifeMove();
            }
        }
    }

    private void KnifeRotation()
    {
        _knifeRotationIndex += 90;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(_knifeRotator.DOLocalRotate(new Vector3(0, 0, _knifeRotationIndex), _rotationTime).SetEase(_animationCurve));
        sequence.AppendCallback(() => KnifeRotation());
    }

    private void KnifeMove()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_knifeRotator.DOLocalMove(_knifeMoveMaxPos, _moveTime).SetLoops(2, LoopType.Yoyo));
    }

    private void KnifeShoot()
    {
        Instantiate(_bullet, _knifeTrm.position, _knifeTrm.rotation);
        Destroy(_knife);
    }
}
