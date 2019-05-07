using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Limiters for the player's movement so it does not leave the board
    public GameObject originCorner;
    public GameObject furthestCorner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player's Movement
        if((Input.GetKeyDown(KeyCode.W)) && (transform.position.z < furthestCorner.transform.position.z))
        {
            transform.position += Vector3.forward * GameManager.fltScaler;
        }
        else if (Input.GetKeyDown(KeyCode.A) && (transform.position.x > originCorner.transform.position.x))
        {
            transform.position += Vector3.left * GameManager.fltScaler;
        }
        else if (Input.GetKeyDown(KeyCode.S) && (transform.position.z > originCorner.transform.position.z))
        {
            transform.position += Vector3.back * GameManager.fltScaler;
        }
        else if (Input.GetKeyDown(KeyCode.D) && (transform.position.x < furthestCorner.transform.position.x))
        {
            transform.position += Vector3.right * GameManager.fltScaler;
        }
    }

    //Add new function here
}
