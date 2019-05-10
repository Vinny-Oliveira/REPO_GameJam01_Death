using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (GameManager.GetInstance().isMovable) {
    //        return;
    //    }
    //    transform.position = target.transform.position + offset;
    //}

    public void MakeCameraFollow() { //Vector3 newTargetPosition) {
        Vector3 newPosition = target.transform.position + offset;
        transform.DOMove(newPosition, GameManager.MOVE_DURATION).SetEase(Ease.OutQuad);
    }
}
