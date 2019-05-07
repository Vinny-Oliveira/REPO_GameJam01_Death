using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float fltScaler = 5f; // Scaler for the size of the board tiles

    // Limiters for the player's movement so it does not leave the board
    public GameObject originCorner;
    //public GameObject goNWCorner;
    public GameObject furthestCorner;
    //public GameObject goSECorner;

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
            transform.position += Vector3.forward * fltScaler;
        }
        else if (Input.GetKeyDown(KeyCode.A) && (transform.position.x > originCorner.transform.position.x))
        {
            transform.position += Vector3.left * fltScaler;
        }
        else if (Input.GetKeyDown(KeyCode.S) && (transform.position.z > originCorner.transform.position.z))
        {
            transform.position += Vector3.back * fltScaler;
        }
        else if (Input.GetKeyDown(KeyCode.D) && (transform.position.x < furthestCorner.transform.position.x))
        {
            transform.position += Vector3.right * fltScaler;
        }
    }

    //Add new function here
}
