using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject digitalWorldTrigger;

    private float zDistanceFromPlayerOnMap = -30f;
    private float yDistanceFromPlayerOnMap = 19.5f;
    //private float xRotationForPlayerOnMap = 30f;
    private Transform target = null;
    private Transform player;
    private Transform avatar;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        avatar = GameObject.FindGameObjectWithTag("PlayerAvatar").transform;
        target = player;
        InputManager.worldSwitch += AdjustForSelectedWorld;
    }

    private void LateUpdate()
    {
        AdjustPosition();
    }

    private void ChangeTaget (Transform newTarget)
    {
        target = newTarget;
    }

    private void AdjustPosition ()
    {
        if (MasterControl.Instance.isInCombat)
        {

        }
        else
        {
            transform.position = new Vector3(target.position.x, target.position.y + yDistanceFromPlayerOnMap, target.position.z + zDistanceFromPlayerOnMap);
        }
    }

    //Switch camera to digital world avatar and back based on the selected world
    private void AdjustForSelectedWorld ()
    {
        digitalWorldTrigger.SetActive(MasterControl.Instance.isInDigitalWorld);

        if (MasterControl.Instance.isInDigitalWorld)
        {
            target = avatar;
        }
        else
        {
            target = player;
        }
    }
}