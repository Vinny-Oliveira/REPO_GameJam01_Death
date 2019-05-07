using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenController : MonoBehaviour
{
    [SerializeField]
    Vector3 targetLocation = Vector3.zero;

    [Range(1f, 10f), SerializeField]
    private float moveDuration = 1f;

    [SerializeField]
    private Ease moveEase = Ease.Linear;

    enum DoTweenType {MoveOneWay}

    [SerializeField]
    DoTweenType dtType = DoTweenType.MoveOneWay;

    // Start is called before the first frame update
    void Start()
    {
        if (dtType == DoTweenType.MoveOneWay) {
            if (targetLocation == Vector3.zero) {
                targetLocation = transform.position;
            }

            transform.DOMove(targetLocation,moveDuration).SetEase(moveEase);
        }
    }
    
}
