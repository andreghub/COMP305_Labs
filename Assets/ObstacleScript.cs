using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {

    
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the other object is a player, then do something
        if (other.gameObject.tag == "Player")
        {
           Camera.main.GetComponent<CameraFollowWithBuffer>().GameOver();        
        }
    }
}
