using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCaster : MonoBehaviour
{
    // Range of the box casted
    const float RAY_RANGE = 2.5f;

    // Booleans to check for collision in each direction
    public bool isHittingForward;
    public bool isHittingBack;
    public bool isHittingLeft;
    public bool isHittingRight;

    // Collider of the player
    public Collider thisCollider;

    // Raycasts in each direction
    RaycastHit rayHitForward;
    RaycastHit rayHitBack;
    RaycastHit rayHitLeft;
    RaycastHit rayHitRight;

    // Vectors for each direction
    Vector3 directionForward = Vector3.forward;
    Vector3 directionBack = Vector3.back;
    Vector3 directionLeft = Vector3.left;
    Vector3 directionRight = Vector3.right;

    /// <summary>
    /// Check if the player is close to obstacles
    /// </summary>
    public void CheckForObstacles()
    {
        //Check for collisions on each side

        isHittingForward = CastBoxCollider(directionForward, rayHitForward);
        //if (isHittingForward)
        //{
        //    //Output the name of the Collider your Box hit
        //    Debug.Log("FORWARD Hit : " + rayHitForward.collider.name);
        //}

        isHittingBack = CastBoxCollider(directionBack, rayHitBack);
        isHittingLeft = CastBoxCollider(directionLeft, rayHitLeft);
        isHittingRight = CastBoxCollider(directionRight, rayHitRight);
    }

    // Use the rays to draw feedback images
    void OnDrawGizmos()
    {
        DrawBoxAndRay(Color.red, isHittingForward, directionForward, rayHitForward); // Draw FORWARD
        DrawBoxAndRay(Color.blue, isHittingBack, directionBack, rayHitBack); // Draw BACK
        DrawBoxAndRay(Color.yellow, isHittingLeft, directionLeft, rayHitLeft); // Draw LEFT
        DrawBoxAndRay(Color.black, isHittingRight, directionRight, rayHitRight); // Draw RIGHT
    }

    /// <summary>
    /// Cast the box collider in the assigned direction. Returns true if it is colliding with an obstacle.
    /// </summary>
    /// <param name="inDirection"></param>
    /// <param name="inRayDirection"></param>
    /// <returns></returns>
    bool CastBoxCollider(Vector3 inDirection, RaycastHit inRayDirection) {
        bool tempHitting = Physics.BoxCast(thisCollider.bounds.center, transform.localScale, inDirection, out inRayDirection, transform.rotation, RAY_RANGE);
        //if (tempHitting) { Debug.Log(inRayDirection.collider.name); }
        // Check if the collision is with an obstacle
        return tempHitting && inRayDirection.collider.CompareTag("Obstacle");
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
