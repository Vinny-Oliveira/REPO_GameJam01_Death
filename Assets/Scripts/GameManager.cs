﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public static float SCALER = 5f; // Scaler for the size of the board tiles
    [SerializeField]
    public static float MOVE_DURATION = 1.5f;
    
    #region LAZY_SINGLETON
    private static GameManager instance;

    public static GameManager GetInstance() {
        if (instance != null) {
            return instance;
        } else {
            return null;
        }
    }

    private void Awake() {

        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public void MovementTween(GameObject inMovingObj, Vector3 inDirection, Ease inEase)
    {
        Vector3 target = inMovingObj.transform.position + inDirection * SCALER;
        inMovingObj.transform.DOMove(target, MOVE_DURATION).SetEase(inEase);
    }
}
