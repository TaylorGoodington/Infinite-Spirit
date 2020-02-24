using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void WorldSwitch();
    public static event WorldSwitch worldSwitch;

	void Start ()
    {
		
	}

    private void Update()
    {
        //TODO Testing for changing worlds
        if (Input.GetButtonDown("Start"))
        {
            SwitchWorlds();
        }
    }

    //TODO add conditions for when playerMovementInput gets set
    public static Vector3 ProcessInput ()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void SwitchWorlds ()
    {
        if (MasterControl.Instance.isInDigitalWorld == true)
        {
            MasterControl.Instance.isInDigitalWorld = false;
        }
        else
        {
            MasterControl.Instance.isInDigitalWorld = true;
        }

        worldSwitch();
    }
}