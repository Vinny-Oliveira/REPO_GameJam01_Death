﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    // Limiters for the player's movement so it does not leave the board
    public GameObject originCorner;
    public GameObject furthestCorner;

    // Other objects tweened in the scene
    public GameObject npcs;
    public GameObject tiles;

    // Tween variables
    public Ease moveEase;
    public float movementRadius = 3f;
    public float npcKillRadius = 5f;
    public float targetKillRadius = 20f;

    // Camera
    public CameraFollow mainCamera;

    // Update is called once per frame
    void Update()
    {
                // Character is movable //                  // Game is not over //                  // Game is not paused //
        if ((GameManager.GetInstance().isMovable) && (!GameManager.GetInstance().isGameOver) && (!GameManager.GetInstance().isGamePaused)) {

            // Player's Movement
                    // Key pressed //                           // Close to walls //                                    // Close to obstacles //
            if ((Input.GetKeyDown(KeyCode.W)) && (transform.position.z < furthestCorner.transform.position.z) && (!GameManager.GetInstance().collisionChecker.isHittingForward))
            {
                MakePlayerMove(Vector3.forward);
            }
            else if (Input.GetKeyDown(KeyCode.A) && (transform.position.x > originCorner.transform.position.x) && (!GameManager.GetInstance().collisionChecker.isHittingLeft))
            {
                MakePlayerMove(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.S) && (transform.position.z > originCorner.transform.position.z) && (!GameManager.GetInstance().collisionChecker.isHittingBack))
            {
                MakePlayerMove(Vector3.back);
            }
            else if (Input.GetKeyDown(KeyCode.D) && (transform.position.x < furthestCorner.transform.position.x) && (!GameManager.GetInstance().collisionChecker.isHittingRight))
            {
                MakePlayerMove(Vector3.right);
            }
            else if (Input.GetKeyDown(KeyCode.Space)) // The player stays still and everything else moves
            {
                MakePlayerMove(Vector3.zero);
            }
        }
        
    }

    /// <summary>
    /// Make the player move and rotate in the proper directions using DoTween
    /// </summary>
    /// <param name="inDirection"></param>
    void MakePlayerMove(Vector3 inDirection) {
        // Move the player
        GameManager.GetInstance().MovementTween(gameObject, inDirection, moveEase);
        StartCoroutine(MoveCamera());
        transform.DORotateQuaternion(Quaternion.LookRotation(inDirection), GameManager.ROTATION_DURATION);

        // Move the NPCs
        npcs.BroadcastMessage("MakeNPCMove");

        // Tween the tiles around
        StartCoroutine(WaitTillTween());
    }

    IEnumerator MoveCamera() {
        yield return new WaitForSeconds(0.2f);
        mainCamera.MakeCameraFollow();
    }

    /// <summary>
    /// Wait for a fraction of second and tween the tiles around the player
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitTillTween()
    {
        yield return new WaitForSeconds(GameManager.TWEEN_EXPAND_DURATION);
        tiles.BroadcastMessage("TweenExpand", movementRadius);
    }

    /// <summary>
    /// Kill other characters when they are touched
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter(Collider collision) {
        if (collision.CompareTag("NPC")) {
            // Increase the count of NPCs killed
            StartCoroutine(GameManager.GetInstance().DisplayNPCKilledMsg());
            tiles.BroadcastMessage("TweenExpand", npcKillRadius);
            npcKillRadius++;
        }
        else if (collision.gameObject.CompareTag("Target")) {
            // When the target is killed, end the level
            Debug.Log("Target eliminated.");
            GameManager.GetInstance().TriggerGameOver();
            tiles.BroadcastMessage("TweenExpand", targetKillRadius);
        }

        Destroy(collision.gameObject);
    }
}
