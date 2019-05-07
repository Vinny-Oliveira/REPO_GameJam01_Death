using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    // Limiters for the player's movement so it does not leave the board
    public GameObject originCorner;
    public GameObject furthestCorner;

    public GameObject npcs;

    private Vector3 target;
    public GameManager gameMng;
    public Ease moveEase;

    // Start is called before the first frame update
    void Start()
    {
        gameMng = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player's Movement
        if((Input.GetKeyDown(KeyCode.W)) && (transform.position.z < furthestCorner.transform.position.z))
        {
            target = transform.position + Vector3.forward;// * GameManager.fltScaler;
            Debug.Log(target);
            gameMng.CallTween(target, 2f, moveEase);
            npcs.BroadcastMessage("MakeNPCMove");
        }
        else if (Input.GetKeyDown(KeyCode.A) && (transform.position.x > originCorner.transform.position.x))
        {
            transform.position += Vector3.left * GameManager.fltScaler;
            npcs.BroadcastMessage("MakeNPCMove");
        }
        else if (Input.GetKeyDown(KeyCode.S) && (transform.position.z > originCorner.transform.position.z))
        {
            transform.position += Vector3.back * GameManager.fltScaler;
            npcs.BroadcastMessage("MakeNPCMove");
        }
        else if (Input.GetKeyDown(KeyCode.D) && (transform.position.x < furthestCorner.transform.position.x))
        {
            transform.position += Vector3.right * GameManager.fltScaler;
            npcs.BroadcastMessage("MakeNPCMove");
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
