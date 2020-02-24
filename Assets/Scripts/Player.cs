using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody body;
    private Animator animator;
    private Vector3 normalVector = new Vector3(0, 1, 0);
    private bool isAvatar = false;

    //TODO Turn private after testing is done.
    public float stationaryTurnSpeed = 360;
    public float movingTurnSpeed = 720;

    void Start ()
    {
        isAvatar = (tag == "PlayerAvatar") ? true : false ;
        body = GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        animator = GetComponent<Animator>();
	}
	
	void Update ()
    {
        if (MasterControl.Instance.isInDigitalWorld)
        {
            if (isAvatar)
            {
                Move(InputManager.ProcessInput());
                DetermineState();
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
        else
        {
            if (!isAvatar)
            {
                Move(InputManager.ProcessInput());
                DetermineState();
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
	}

    private void DetermineState ()
    {
        if (MasterControl.Instance.isInCombat)
        {

        }
        else
        {
            animator.SetBool("isInCombat", false);

            if (InputManager.ProcessInput().magnitude > 0)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
    }

    private void Move(Vector3 move)
    {
        move = transform.InverseTransformDirection(move);
        move = Vector3.ProjectOnPlane(move, normalVector);
        float turnAmount = Mathf.Atan2(move.x, move.z);
        float turnSpeed = Mathf.Lerp(stationaryTurnSpeed, movingTurnSpeed, move.z);
        transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
    }
}