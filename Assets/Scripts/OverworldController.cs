using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldController : MonoBehaviour
{
    private Rigidbody body;
    private Animator animator;
    private Vector3 normalVector = new Vector3(0, 1, 0);

    //TODO Turn private after testing is done.
    public float stationaryTurnSpeed = 360;
    public float movingTurnSpeed = 720;

    void Start ()
    {
        body = GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        animator = GetComponent<Animator>();
	}

    public void RecieveInput(Vector2 input)
    {
        DetermineState(input);
        Move(input);
    }

    private void DetermineState (Vector2 input)
    {
        
    }

    private void Move(Vector3 input)
    {
        input = transform.InverseTransformDirection(input);
        input = Vector3.ProjectOnPlane(input, normalVector);
        float turnAmount = Mathf.Atan2(input.x, input.z);
        float turnSpeed = Mathf.Lerp(stationaryTurnSpeed, movingTurnSpeed, input.z);
        transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
    }
}