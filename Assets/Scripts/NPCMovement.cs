using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum DIRECTION {STILL, UP, DOWN, LEFT, RIGHT};

public class NPCMovement : MonoBehaviour
{
    // Variables for the direction of the NPC
    public DIRECTION[] arrMovement;
    int index;
    int intLength;

    // Tween variables
    public Ease moveEase;

    void Start()
    {
        index = 0;
        intLength = arrMovement.Length;

        //Adjusting the initial rotation of the player
        RotateTowardsNextDirection(index, arrMovement);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space)) {
    //        MakeNPCMove();
    //    }
    //}

    /// <summary>
    /// Make the NPC move according to the information in its movement array
    /// </summary>
    public void MakeNPCMove() {
        // Move NPC
        if (arrMovement[index] == DIRECTION.UP) {
            GameManager.GetInstance().MovementTween(gameObject, Vector3.forward, moveEase);
        } else if (arrMovement[index] == DIRECTION.DOWN) {
            GameManager.GetInstance().MovementTween(gameObject, Vector3.back, moveEase);
        } else if (arrMovement[index] == DIRECTION.LEFT) {
            GameManager.GetInstance().MovementTween(gameObject, Vector3.left, moveEase);
        } else if (arrMovement[index] == DIRECTION.RIGHT) {
            GameManager.GetInstance().MovementTween(gameObject, Vector3.right, moveEase);
        }

        // Go to the next instruction of the array or to the beginning
        if (index < intLength - 1) {
            index++;
        } else {
            index = 0;
        }

        //Rotate the NPC
        RotateTowardsNextDirection(index, arrMovement);
    }

    /// <summary>
    /// Identify what is the next direction in which the NPC will move
    /// </summary>
    /// <param name="inIndex"></param>
    /// <param name="inDirection"></param>
    /// <returns></returns>
    void RotateTowardsNextDirection(int inIndex, DIRECTION[] inDirection) {
        Vector3 nextTarget;

        // Identify the next direction
        if (inDirection[inIndex] == DIRECTION.UP) {
            nextTarget = Vector3.forward;
        }
        else if (inDirection[inIndex] == DIRECTION.DOWN) {
            nextTarget = Vector3.back;
        }
        else if (inDirection[inIndex] == DIRECTION.LEFT) {
            nextTarget = Vector3.left;
        }
        else if (inDirection[inIndex] == DIRECTION.RIGHT) {
            nextTarget = Vector3.right;
        }
        else { // DIRECTION.STILL
            nextTarget = transform.forward;
        }

        // RotateMode the NPC
        transform.rotation = Quaternion.LookRotation(nextTarget);
    }
}
