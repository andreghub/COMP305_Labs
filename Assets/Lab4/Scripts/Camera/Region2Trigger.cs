using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region2Trigger : MonoBehaviour
{

    public Camera region1Camera;
    public Camera region2Camera;

    // Defined by unity
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the other object is a player, then do something
        if (other.gameObject.tag == "Player")
        {
            region1Camera.enabled = false;
            region2Camera.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            region2Camera.enabled = false;
            region1Camera.enabled = true;
        }
    }
}
