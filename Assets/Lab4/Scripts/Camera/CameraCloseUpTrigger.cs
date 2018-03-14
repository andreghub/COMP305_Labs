using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCloseUpTrigger : MonoBehaviour {

    public Camera mainCamera;
    public Camera closeUpCamera;

    // Defined by unity
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the other object is a player, then do something
        if(other.gameObject.tag == "Player")
        {
            mainCamera.GetComponent<CameraFollowWithBuffer>().PlayerWins();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // If the other object is a player, then do something
        if (other.gameObject.tag == "Player")
        {
            float newSize = closeUpCamera.orthographicSize;
            if (other.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0.00f)
            {
                newSize -= 0.01f;
            }
            else if(other.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0.00f)
            {
                newSize += 0.01f;
            }

            if(newSize < 1)
            {
                newSize = 1;
            }
            if (newSize > 3)
            {
                newSize = 3;
            }

            closeUpCamera.orthographicSize = newSize;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            closeUpCamera.enabled = false;
            mainCamera.enabled = true;
        }
    }
}
