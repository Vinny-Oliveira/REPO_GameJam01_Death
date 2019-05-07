using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public static float fltScaler = 5f; // Scaler for the size of the board tiles

    //[SerializeField]
    //Vector3 targetLocation = Vector3.zero;

    //[Range(1f, 10f), SerializeField]
    //private float moveDuration = 1f;

    //[SerializeField]
    //private Ease moveEase = Ease.Linear;

    //enum DoTweenType { MoveOneWay }

    //[SerializeField]
    //DoTweenType dtType = DoTweenType.MoveOneWay;

    
    public void CallTween(Vector3 inTarget, float inDuration, Ease inEase)
    {
        //if (dtType == DoTweenType.MoveOneWay)
        //{
            //if (inTarget == Vector3.zero)
            //{
            //    inTarget = transform.position;
            //}

            transform.DOMove(inTarget, inDuration).SetEase(inEase);
        //}
    }
}
