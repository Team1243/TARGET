using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RingRotator : MonoBehaviour
{
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private float _rotationTime;
    private int _knifeRotationIndex = 0;

    private void Start() 
    {
        KnifeRotation();
    }

    private void KnifeRotation() // 정지상태 회전 
    {
        _knifeRotationIndex += 90;

        Sequence sequenceRotation = DOTween.Sequence();
        sequenceRotation.Append(transform.DOLocalRotate(new Vector3(0, 0, _knifeRotationIndex), _rotationTime).SetEase(_animationCurve));
        sequenceRotation.AppendCallback(() => KnifeRotation());
    }
}
