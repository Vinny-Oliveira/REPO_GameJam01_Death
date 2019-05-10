using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TileBob : MonoBehaviour
{
    GameObject player;
    Ease tileEaseMove = Ease.OutBack;
    Ease tileEaseStart = Ease.OutQuart;

    [SerializeField]
    bool isMasterTile; // Only ONE tile should be the master

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.localScale = new Vector3(0, 0, 0);
        StartCoroutine(ScaleUp());
    }


    /// <summary>
    /// Change the scale of the tiles using tween in the start of the level
    /// </summary>
    /// <returns></returns>
    IEnumerator ScaleUp()
    {
        float randomTime = Random.Range(GameManager.RAND_WAIT_TIME_MIN, GameManager.RAND_WAIT_TIME_MAX);
        if (isMasterTile) { randomTime = GameManager.RAND_WAIT_TIME_MAX; } // The master tile will be the last one to scale up
        yield return new WaitForSeconds(randomTime);
        transform.DOScale(new Vector3(GameManager.TILE_SCALE, 1, GameManager.TILE_SCALE), GameManager.TWEEN_BOB_DURATION).SetEase(tileEaseStart);
        if (isMasterTile) { GameManager.GetInstance().isMovable = true; } // Allow the player to start moving after all tiles have scaled back to normal
        
    }

    /// <summary>
    /// Rescale the tiles around the player after a movement
    /// </summary>
    [ContextMenu("Tween!")]
    void TweenExpand(float inRadius)
    {
        if ((transform.position - player.transform.position).magnitude < inRadius)
        {
            Sequence mySequence = DOTween.Sequence();
            mySequence.Prepend(transform.DOScale(new Vector3(Random.Range(GameManager.RAND_TWEEN_SCALE_MIN, GameManager.RAND_TWEEN_SCALE_MAX), 
                                                             GameManager.TWEEN_TILE_Y_SCALE,
                                                             Random.Range(GameManager.RAND_TWEEN_SCALE_MIN, GameManager.RAND_TWEEN_SCALE_MAX)), 
                                                 Random.Range(GameManager.RAND_TWEEN_TIME_MIN, GameManager.RAND_TWEEN_TIME_MAX)).SetEase(tileEaseMove));
            //mySequence.Prepend(transform.DOShakeScale(0.25f, new Vector3(Random.Range(0.2f, 0.7f), .3f, Random.Range(0.2f, 0.7f)), 0, 0, false));
            mySequence.Append(transform.DOScale(new Vector3(GameManager.TILE_SCALE, 1, GameManager.TILE_SCALE),
                                                Random.Range(GameManager.RAND_TWEEN_TIME_MIN, GameManager.RAND_TWEEN_TIME_MAX)).SetEase(tileEaseMove));
            mySequence.Play();

            //transform.DOScale(.7f, 0.2f).onComplete(TweenBack);
            //transform.DOShakeScale(0.25f, new Vector3(0.7f, .3f, .7f), 0, 0, false);
            //transform.DOPunchScale(new Vector3(.5f, .2f, 0.5f), 0.25f, 1, 0);
        }

    }
}
