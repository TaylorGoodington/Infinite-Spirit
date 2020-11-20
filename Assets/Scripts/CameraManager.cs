using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    private bool followPlayer = false;

    private float zDistanceFromPlayerOnMap = -30f;
    private float yDistanceFromPlayerOnMap = 19.5f;
    //private float xRotationForPlayerOnMap = 30f;
    private Transform target = null;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    private void LateUpdate()
    {
        AdjustPosition();
    }

    private void AdjustPosition()
    {
        if (followPlayer)
        {
            transform.position = new Vector3(target.position.x, target.position.y + yDistanceFromPlayerOnMap, target.position.z + zDistanceFromPlayerOnMap);
        }
    }

    public void ChangeTaget (Transform newTarget)
    {
        target = newTarget;
    }
}