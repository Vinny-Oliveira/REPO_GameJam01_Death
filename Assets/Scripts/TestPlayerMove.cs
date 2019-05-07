using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{

    float fltScaler = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            //transform.position += Vector3.left;
            transform.position += Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            //transform.position += Vector3.back;
            transform.position += Vector3.back;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.forward;
        }
    }
}
