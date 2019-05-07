using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTION {STILL, UP, DOWN, LEFT, RIGHT};

public class NPCMovement : MonoBehaviour
{
    public DIRECTION[] arrMovement;
    int index;
    int intLength;

    void Start()
    {
        index = 0;
        intLength = arrMovement.Length;
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
    [ContextMenu("MoveNPC")]
    public void MakeNPCMove() {
        // Move NPC
        if (arrMovement[index] == DIRECTION.UP) {
            transform.position += Vector3.forward * GameManager.fltScaler;
            transform.rotation = Quaternion.LookRotation(CheckNextDirection(index, arrMovement));
        } else if (arrMovement[index] == DIRECTION.DOWN) {
            transform.position += Vector3.back * GameManager.fltScaler;
        } else if (arrMovement[index] == DIRECTION.LEFT) {
            transform.position += Vector3.left * GameManager.fltScaler;
        } else if (arrMovement[index] == DIRECTION.RIGHT) {
            transform.position += Vector3.right * GameManager.fltScaler;
        }

        // Go to the next instruction of the array or to the beginning
        if (index < intLength - 1) {
            index++;
        } else {
            index = 0;
        }
    }

    Vector3 CheckNextDirection(int inIndex, DIRECTION[] inDirection) {

        if (inDirection[inIndex+1] == DIRECTION.UP) {
            return Vector3.forward;

        }
        return Vector3.zero;
    }
}
