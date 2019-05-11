using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCaster : MonoBehaviour
{
    const float RAY_RANGE = 3f;

    public bool isHittingForward;
    public bool isHittingBack;
    public bool isHittingLeft;
    public bool isHittingRight;

    public Collider thisCollider;

    RaycastHit rayHitForward;
    RaycastHit rayHitBack;
    RaycastHit rayHitLeft;
    RaycastHit rayHitRight;

    Vector3 directionForward = Vector3.forward;
    Vector3 directionBack = Vector3.back;
    Vector3 directionLeft = Vector3.left;
    Vector3 directionRight = Vector3.right;

    //void Start()
    //{
    //    thisCollider = GetComponent<Collider>();
    //}

    void Update()
    {
        //Check for collisions of each side
        isHittingForward = CastBoxCollider(directionForward, rayHitForward);
        //if (isHittingForward)
        //{
        //    //Output the name of the Collider your Box hit
        //    Debug.Log("FORWARD Hit : " + rayHitForward.collider.name);
        //}

        isHittingBack = CastBoxCollider(directionBack, rayHitBack);
        //if (isHittingBack)
        //{
        //    //Output the name of the Collider your Box hit
        //    Debug.Log("BACK Hit : " + rayHitBack.collider.name);
        //}

        isHittingLeft = CastBoxCollider(directionLeft, rayHitLeft);
        //if (isHittingLeft)
        //{
        //    //Output the name of the Collider your Box hit
        //    Debug.Log("LEFT Hit : " + rayHitLeft.collider.name);
        //}

        isHittingRight = CastBoxCollider(directionRight, rayHitRight);
        //if (isHittingRight)
        //{
        //    //Output the name of the Collider your Box hit
        //    Debug.Log("RIGHT Hit : " + rayHitRight.collider.name);
        //}
    }

    // Use the rays to draw feedback images
    void OnDrawGizmos()
    {
        DrawBoxAndRay(Color.red, isHittingForward, directionForward, rayHitForward); // Draw FORWARD
        DrawBoxAndRay(Color.blue, isHittingBack, directionBack, rayHitBack); // Draw BACK
        DrawBoxAndRay(Color.yellow, isHittingLeft, directionLeft, rayHitLeft); // Draw LEFT
        DrawBoxAndRay(Color.black, isHittingRight, directionRight, rayHitRight); // Draw RIGHT

        //Gizmos.color = Color.red;

        //if (isHittingForward)
        //{
        //    Gizmos.DrawRay(transform.position, directionForward * rayHitForward.distance);
        //    Gizmos.DrawWireCube(transform.position + directionForward * rayHitForward.distance, transform.localScale);
        //}
        //else
        //{
        //    Gizmos.DrawRay(transform.position, directionForward * RAY_RANGE);
        //    Gizmos.DrawWireCube(transform.position + directionForward * RAY_RANGE, transform.localScale);
        //}

        //// Draw BACK
        //Gizmos.color = Color.blue;

        //if (isHittingBack)
        //{
        //    Gizmos.DrawRay(transform.position, directionBack * rayHitBack.distance);
        //    Gizmos.DrawWireCube(transform.position + directionBack * rayHitBack.distance, transform.localScale);
        //}
        //else
        //{
        //    Gizmos.DrawRay(transform.position, directionBack * RAY_RANGE);
        //    Gizmos.DrawWireCube(transform.position + directionBack * RAY_RANGE, transform.localScale);
        //}

        //// Draw LEFT
        //Gizmos.color = Color.yellow;

        //if (isHittingLeft)
        //{
        //    Gizmos.DrawRay(transform.position, directionLeft * rayHitLeft.distance);
        //    Gizmos.DrawWireCube(transform.position + directionLeft * rayHitLeft.distance, transform.localScale);
        //}
        //else
        //{
        //    Gizmos.DrawRay(transform.position, directionLeft * RAY_RANGE);
        //    Gizmos.DrawWireCube(transform.position + directionLeft * RAY_RANGE, transform.localScale);
        //}

        //if (m_HitDetectR)
        //{
        //    Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 90, 0) * transform.forward * m_HitR.distance);
        //    Gizmos.DrawWireCube(transform.position + Quaternion.Euler(0, 90, 0) * transform.forward * m_HitR.distance, transform.localScale);
        //}
        //else
        //{
        //    Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 90, 0) * transform.forward * m_MaxDistance);
        //    Gizmos.DrawWireCube(transform.position + Quaternion.Euler(0, 90, 0) * transform.forward * m_MaxDistance, transform.localScale);
        //}
    }

    /// <summary>
    /// Cast the box collider in the assigned direction
    /// </summary>
    /// <param name="inDirection"></param>
    /// <param name="inRayDirection"></param>
    /// <returns></returns>
    bool CastBoxCollider(Vector3 inDirection, RaycastHit inRayDirection) {
        return Physics.BoxCast(thisCollider.bounds.center, transform.localScale, inDirection, out inRayDirection, transform.rotation, RAY_RANGE);
    }

    /// <summary>
    /// Draw a ray and a box in the direction assigned. The length of the ray depends on the collision.
    /// </summary>
    /// <param name="inColor"></param>
    /// <param name="inIsHitting"></param>
    /// <param name="inDirection"></param>
    /// <param name="inRayDirection"></param>
    void DrawBoxAndRay(Color inColor, bool inIsHitting, Vector3 inDirection, RaycastHit inRayDirection) {
        Gizmos.color = inColor;

        if (inIsHitting)
        {
            Gizmos.DrawRay(transform.position, inDirection * inRayDirection.distance);
            Gizmos.DrawWireCube(transform.position + inDirection * inRayDirection.distance, transform.localScale);
        }
        else
        {
            Gizmos.DrawRay(transform.position, inDirection * RAY_RANGE);
            Gizmos.DrawWireCube(transform.position + inDirection * RAY_RANGE, transform.localScale);
        }
    }
}
