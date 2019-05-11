using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCaster : MonoBehaviour
{
    float m_MaxDistance;
    //float m_Speed;
    bool m_HitDetect;
    bool m_HitDetectF;
    bool m_HitDetectB;
    bool m_HitDetectL;
    bool m_HitDetectR;

    Collider m_Collider;
    RaycastHit m_Hit;
    RaycastHit m_HitF;
    RaycastHit m_HitB;
    RaycastHit m_HitL;
    RaycastHit m_HitR;

    Vector3 orientation = Vector3.left;

    void Start()
    {
        //Choose the distance the Box can reach to
        m_MaxDistance = 3.0f;
        //m_Speed = 20.0f;
        m_Collider = GetComponent<Collider>();
    }

    //void Update()
    //{
    //    //Simple movement in x and z axes
    //    float xAxis = Input.GetAxis("Horizontal") * m_Speed;
    //    float zAxis = Input.GetAxis("Vertical") * m_Speed;
    //    transform.Translate(new Vector3(xAxis, 0, zAxis));
    //}

    void FixedUpdate()
    {
        //Test to see if there is a hit using a BoxCast
        //Calculate using the center of the GameObject's Collider(could also just use the GameObject's position), half the GameObject's size, the direction, the GameObject's rotation, and the maximum distance as variables.
        //Also fetch the hit data
        //m_HitDetect = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, Quaternion.Euler(0, 90, 0) * transform.forward, out m_Hit, transform.rotation, m_MaxDistance);
        //if (m_HitDetect)
        //{
        //    //Output the name of the Collider your Box hit
        //    Debug.Log("Hit : " + m_Hit.collider.name);
        //}

        m_HitDetectF = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, Quaternion.Euler(0, 0, 0) * transform.forward, out m_HitF, transform.rotation, m_MaxDistance);
        if (m_HitDetectF)
        {
            //Output the name of the Collider your Box hit
            Debug.Log("FORWARD Hit : " + m_HitF.collider.name);
        }

        m_HitDetectB = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, Quaternion.Euler(0, 180, 0) * transform.forward, out m_HitB, transform.rotation, m_MaxDistance);
        if (m_HitDetectB)
        {
            //Output the name of the Collider your Box hit
            Debug.Log("BACK Hit : " + m_HitB.collider.name);
        }

        m_HitDetectL = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, Quaternion.Euler(0, -90, 0) * transform.forward, out m_HitL, transform.rotation, m_MaxDistance);
        if (m_HitDetectL)
        {
            //Output the name of the Collider your Box hit
            Debug.Log("LEFT Hit : " + m_HitL.collider.name);
        }

        m_HitDetectR = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, Quaternion.Euler(0, 90, 0) * transform.forward, out m_HitR, transform.rotation, m_MaxDistance);
        if (m_HitDetectR)
        {
            //Output the name of the Collider your Box hit
            Debug.Log("RIGHT Hit : " + m_HitR.collider.name);
        }
    }

    //Draw the BoxCast as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        //if (m_HitDetect)
        //{
        //    //Draw a Ray forward from GameObject toward the hit
        //    Gizmos.DrawRay(transform.position, transform.forward * m_Hit.distance);
        //    //Gizmos.DrawRay(transform.position, orientation * m_Hit.distance);
        //    //Draw a cube that extends to where the hit exists
        //    Gizmos.DrawWireCube(transform.position + transform.forward * m_Hit.distance, transform.localScale);
        //    //Gizmos.DrawWireCube(transform.position + orientation * m_Hit.distance, transform.localScale);
        //}
        ////If there hasn't been a hit yet, draw the ray at the maximum distance
        //else
        //{
        //    //Draw a Ray forward from GameObject toward the maximum distance
        //    Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 90, 0) * transform.forward * m_MaxDistance);
        //    //Gizmos.DrawRay(transform.position, Vector3.left * m_MaxDistance);
        //    //Draw a cube at the maximum distance
        //    Gizmos.DrawWireCube(transform.position + transform.forward * m_MaxDistance, transform.localScale);
        //    //Gizmos.DrawWireCube(transform.position + orientation * m_MaxDistance, transform.localScale);
        //}

        if (m_HitDetectF)
        {
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0, 0) * transform.forward * m_HitF.distance);
            Gizmos.DrawWireCube(transform.position + Quaternion.Euler(0, 0, 0) * transform.forward * m_HitF.distance, transform.localScale);
        }
        else
        {
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0, 0) * transform.forward * m_MaxDistance);
            Gizmos.DrawWireCube(transform.position + Quaternion.Euler(0, 0, 0) * transform.forward * m_MaxDistance, transform.localScale);
        }

        if (m_HitDetectB)
        {
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 180, 0) * transform.forward * m_HitB.distance);
            Gizmos.DrawWireCube(transform.position + Quaternion.Euler(0, 180, 0) * transform.forward * m_HitB.distance, transform.localScale);
        }
        else
        {
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 180, 0) * transform.forward * m_MaxDistance);
            Gizmos.DrawWireCube(transform.position + Quaternion.Euler(0, 180, 0) * transform.forward * m_MaxDistance, transform.localScale);
        }

        if (m_HitDetectL)
        {
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -90, 0) * transform.forward * m_HitL.distance);
            Gizmos.DrawWireCube(transform.position + Quaternion.Euler(0, -90, 0) * transform.forward * m_HitL.distance, transform.localScale);
        }
        else
        {
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -90, 0) * transform.forward * m_MaxDistance);
            Gizmos.DrawWireCube(transform.position + Quaternion.Euler(0, -90, 0) * transform.forward * m_MaxDistance, transform.localScale);
        }

        if (m_HitDetectR)
        {
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 90, 0) * transform.forward * m_HitR.distance);
            Gizmos.DrawWireCube(transform.position + Quaternion.Euler(0, 90, 0) * transform.forward * m_HitR.distance, transform.localScale);
        }
        else
        {
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 90, 0) * transform.forward * m_MaxDistance);
            Gizmos.DrawWireCube(transform.position + Quaternion.Euler(0, 90, 0) * transform.forward * m_MaxDistance, transform.localScale);
        }
    }
}
