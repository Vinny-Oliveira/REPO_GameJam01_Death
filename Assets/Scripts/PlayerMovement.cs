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

    // Tween variables
    public Ease moveEase;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetInstance().isMovable) {
            // Player's Movement
            if ((Input.GetKeyDown(KeyCode.W)) && (transform.position.z < furthestCorner.transform.position.z))
            {
                GameManager.GetInstance().MovementTween(gameObject, Vector3.forward, moveEase);
                transform.DORotateQuaternion(Quaternion.LookRotation(Vector3.forward), GameManager.ROTATION_DURATION);
                npcs.BroadcastMessage("MakeNPCMove");
            }
            else if (Input.GetKeyDown(KeyCode.A) && (transform.position.x > originCorner.transform.position.x))
            {
                GameManager.GetInstance().MovementTween(gameObject, Vector3.left, moveEase);
                transform.DORotateQuaternion(Quaternion.LookRotation(Vector3.left), GameManager.ROTATION_DURATION);

                npcs.BroadcastMessage("MakeNPCMove");
            }
            else if (Input.GetKeyDown(KeyCode.S) && (transform.position.z > originCorner.transform.position.z))
            {
                GameManager.GetInstance().MovementTween(gameObject, Vector3.back, moveEase);
                transform.DORotateQuaternion(Quaternion.LookRotation(Vector3.back), GameManager.ROTATION_DURATION);

                npcs.BroadcastMessage("MakeNPCMove");
            }
            else if (Input.GetKeyDown(KeyCode.D) && (transform.position.x < furthestCorner.transform.position.x))
            {
                GameManager.GetInstance().MovementTween(gameObject, Vector3.right, moveEase);
                transform.DORotateQuaternion(Quaternion.LookRotation(Vector3.right), GameManager.ROTATION_DURATION);

                npcs.BroadcastMessage("MakeNPCMove");
            }
        }
        
    }

    /// <summary>
    /// Kill other characters when they are touched
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("NPC")) {
            // Do something for this situation
        } else if (collision.gameObject.CompareTag("Target")) {
            // Do something else for this situation
        }

        Destroy(collision.gameObject);
    }
}
