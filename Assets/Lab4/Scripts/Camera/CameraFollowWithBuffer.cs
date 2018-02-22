using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowWithBuffer : MonoBehaviour
{

    public Transform playerPosition;
    public Transform safeZoneLeftLimit;
    public Transform safeZoneRightLimit;
    public Transform region2Limit;


    // Use this for initialization
    void Start()
    {
        safeZoneLeftLimit = transform.GetChild(0);
        safeZoneRightLimit = transform.GetChild(1);
        region2Limit = transform.GetChild(2);
    }

    // Update is called once per framet\
    void Update()
    {
        if (playerPosition.position.x > region2Limit.position.x)
        {
            if (playerPosition.position.x > safeZoneRightLimit.position.x)
            {
                this.transform.position = new Vector3(playerPosition.position.x, transform.position.y, transform.position.z);
            }
            else if (playerPosition.position.x < safeZoneLeftLimit.position.x)
            {
                this.transform.position = new Vector3(playerPosition.position.x, transform.position.y, transform.position.z);
            }
        }
    }

    // Predefined Unity function for drawing Gizmos in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(safeZoneRightLimit.position, new Vector3(safeZoneRightLimit.position.x, safeZoneRightLimit.position.y + 100, safeZoneRightLimit.position.z));
        Gizmos.DrawLine(safeZoneRightLimit.position, new Vector3(safeZoneRightLimit.position.x, safeZoneRightLimit.position.y - 100, safeZoneRightLimit.position.z));
        Gizmos.DrawLine(safeZoneLeftLimit.position, new Vector3(safeZoneLeftLimit.position.x, safeZoneLeftLimit.position.y + 100, safeZoneLeftLimit.position.z));
        Gizmos.DrawLine(safeZoneLeftLimit.position, new Vector3(safeZoneLeftLimit.position.x, safeZoneLeftLimit.position.y - 100, safeZoneLeftLimit.position.z));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(region2Limit.position, new Vector3(region2Limit.position.x, region2Limit.position.y + 100, region2Limit.position.z));
        Gizmos.DrawLine(region2Limit.position, new Vector3(region2Limit.position.x, region2Limit.position.y - 100, region2Limit.position.z));
    }
}
