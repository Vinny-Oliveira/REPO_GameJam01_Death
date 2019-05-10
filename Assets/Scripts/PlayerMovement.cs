using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    // Limiters for the player's movement so it does not leave the board
    public GameObject originCorner;
    public GameObject furthestCorner;

    // NPCs of the scene
    public GameObject npcs;
    public GameObject tiles;

    // Tween variables
    public Ease moveEase;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetInstance().isMovable && !GameManager.GetInstance().isGameOver) {
            // Player's Movement
            if ((Input.GetKeyDown(KeyCode.W)) && (transform.position.z < furthestCorner.transform.position.z))
            {
                MakePlayerMove(Vector3.forward);
            }
            else if (Input.GetKeyDown(KeyCode.A) && (transform.position.x > originCorner.transform.position.x))
            {
                MakePlayerMove(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.S) && (transform.position.z > originCorner.transform.position.z))
            {
                MakePlayerMove(Vector3.back);
            }
            else if (Input.GetKeyDown(KeyCode.D) && (transform.position.x < furthestCorner.transform.position.x))
            {
                MakePlayerMove(Vector3.right);
            }
        }
        
    }

    /// <summary>
    /// Make the player move and rotate in the proper directions using DoTween
    /// </summary>
    /// <param name="inDirection"></param>
    void MakePlayerMove(Vector3 inDirection) {
        GameManager.GetInstance().MovementTween(gameObject, inDirection, moveEase);
        transform.DORotateQuaternion(Quaternion.LookRotation(inDirection), GameManager.ROTATION_DURATION);
        npcs.BroadcastMessage("MakeNPCMove");
        StartCoroutine(WaitTillTween());
    }

    IEnumerator WaitTillTween()
    {
        yield return new WaitForSeconds(.55f);
        tiles.BroadcastMessage("TweenExpand");
    }

    /// <summary>
    /// Kill other characters when they are touched
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter(Collider collision) {
        if (collision.CompareTag("NPC")) {
            StartCoroutine(GameManager.GetInstance().LateCall());
            // Trigger score decrease or whatever else is supposed to happen
        } else if (collision.gameObject.CompareTag("Target")) {
            Debug.Log("Target eliminated.");
            GameManager.GetInstance().TriggerGameOver();
        }

        Destroy(collision.gameObject);
    }
}
