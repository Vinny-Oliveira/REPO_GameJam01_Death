using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{
    [SerializeField]
    float fltScaler = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player's Movement
        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.forward * fltScaler;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left * fltScaler;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += Vector3.back * fltScaler;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right * fltScaler;
        }
    }
}
