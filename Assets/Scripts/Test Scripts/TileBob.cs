using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TileBob : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
        StartCoroutine(ScaleUp());
    }

    IEnumerator ScaleUp()
    {
        float randomTime = Random.Range(0.5f, 1.5f);
        yield return new WaitForSeconds(randomTime);
        transform.DOScale(new Vector3(5, 1, 5), 1f).SetEase(Ease.OutQuart);
    }

    [ContextMenu("Tween!")]
    void TweenExpand()
    {
        //transform.DOScale(.7f, 0.2f).onComplete(TweenBack);
        transform.DOShakeScale(0.25f, new Vector3(0.7f, .3f, .7f), 0, 0, false);
        //transform.DOPunchScale(new Vector3(.5f, .2f, 0.5f), 0.25f, 1, 0);
    }
}
