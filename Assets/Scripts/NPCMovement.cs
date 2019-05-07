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

        //Adjusting the initial rotation of the player
        transform.rotation = Quaternion.LookRotation(CheckNextDirection(index, arrMovement));
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
            MoveDirection(Vector3.forward);
        } else if (arrMovement[index] == DIRECTION.DOWN) {
            MoveDirection(Vector3.back);
        } else if (arrMovement[index] == DIRECTION.LEFT) {
            MoveDirection(Vector3.left);
        } else if (arrMovement[index] == DIRECTION.RIGHT) {
            MoveDirection(Vector3.right);
        }

        // Go to the next instruction of the array or to the beginning
        if (index < intLength - 1) {
            index++;
        } else {
            index = 0;
        }

        //Rotate the player
        transform.rotation = Quaternion.LookRotation(CheckNextDirection(index, arrMovement));
    }

    void MoveDirection(Vector3 direction)
    {
        transform.position += direction * GameManager.fltScaler;
    }

    Vector3 CheckNextDirection(int inIndex, DIRECTION[] inDirection) {

        if (inDirection[inIndex] == DIRECTION.UP) {
            return Vector3.forward;
        }
        else if (inDirection[inIndex] == DIRECTION.DOWN) {
            return Vector3.back;
        }
        else if (inDirection[inIndex] == DIRECTION.LEFT) {
            return Vector3.left;
        }
        else if (inDirection[inIndex] == DIRECTION.RIGHT) {
            return Vector3.right;
        }
        return Vector3.zero;
    }
}
