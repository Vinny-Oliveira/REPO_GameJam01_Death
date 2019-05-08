using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public static float SCALER = 5f; // Scaler for the size of the board tiles
    [SerializeField]
    public static float MOVE_DURATION = 1f;
    [SerializeField]
    public static float ROTATION_DURATION = 0.5f;

    // Booleans for game control
    public bool isMovable;
    public bool isGameOver;
    
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

    private void Start()
    {
        isMovable = true;
        isGameOver = false;
}

    /// <summary>
    /// Tween to make game objects move in a certain direction
    /// </summary>
    /// <param name="inMovingObj"></param>
    /// <param name="inDirection"></param>
    /// <param name="inEase"></param>
    public void MovementTween(GameObject inMovingObj, Vector3 inDirection, Ease inEase)
    {
        isMovable = false; // Keep objects from moving while the tween is in progress
        Vector3 target = inMovingObj.transform.position + inDirection * SCALER;
        inMovingObj.transform.DOMove(target, MOVE_DURATION).SetEase(inEase).OnComplete(MakeObjectsMovable);
    }

    void MakeObjectsMovable() {
        isMovable = true;
    }
}
