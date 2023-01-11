using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Knife : MonoBehaviour //Knife의 초반 움직임을 담당
{
    [SerializeField] private GameObject _bullet; // 생성할 Knife Prefab
    [SerializeField] private AnimationCurve _animationCurve; // 어느 구간에 어느 속도로 움직일지
    [SerializeField] private Vector3 _knifeMoveMaxPos; // 움직이고, 돌아갈 오브젝트
    [SerializeField] private float _rotationTime; // 칼 돌아가는 시간 (90도)
    [SerializeField] private float _moveTime; // 칼 움직이는 시간 (편도)
    
    private SpriteRenderer _knifeSpriteRenderer;
    private Transform _knifeRotator;
    private Transform _knifeTrm;
    Sequence sequenceRotation;

    private int _knifeRotationIndex;

    private void Awake() 
    {
        _knifeRotator = transform.GetChild(0).GetComponent<Transform>();
        _knifeTrm = transform.GetChild(0).GetChild(0).GetComponent<Transform>();
        _knifeSpriteRenderer = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Start() 
    {
        GameManager.Instance.gameState = GameState.Ready;
    }

    private void Update() 
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            DebuggingUpdate();
    }

    private void DebuggingUpdate()
    {
        switch (GameManager.Instance.gameState)
        {
            case (GameState.Ready):
                GameManager.Instance.gameState = GameState.Flying;
                KnifeRotation();
                KnifeMove();
                break;
            case (GameState.Flying): 
                KnifeShoot();
                break;
        }
    }

    private void KnifeRotation() // 정지상태 회전 
    {
        _knifeRotationIndex += 90;

        sequenceRotation = DOTween.Sequence();
        sequenceRotation.Append(_knifeRotator.DOLocalRotate(new Vector3(0, 0, _knifeRotationIndex), _rotationTime).SetEase(_animationCurve));
        sequenceRotation.AppendCallback(() => KnifeRotation());
    }

    private void KnifeMove() // 정지 상태에서 움직임
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_knifeRotator.DOLocalMove(_knifeMoveMaxPos, _moveTime).SetLoops(2, LoopType.Yoyo));
        sequence.AppendCallback(() =>
        {
            if (GameManager.Instance.gameState != GameState.Flying)
            {
                sequenceRotation.Kill();
                GameManager.Instance.GameOver();
            }
        });
    }

    private void KnifeShoot() // 칼이 올라간 상태에서 칼을 발사
    {
        Instantiate(_bullet, _knifeTrm.position, _knifeTrm.rotation);
        GameManager.Instance.gameState = GameState.Shooting;
        sequenceRotation.Kill();
        _knifeRotator.localRotation = Quaternion.identity;
        _knifeSpriteRenderer.enabled = false;
    }

    public void ReGame()
    {
        _knifeSpriteRenderer.enabled = true;
        GameManager.Instance.gameState = GameState.Ready;
    }
}
