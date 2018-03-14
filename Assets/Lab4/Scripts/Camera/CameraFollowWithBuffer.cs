using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowWithBuffer : MonoBehaviour
{

    public Transform playerPosition;
    public Transform safeZoneLeftLimit;
    public Transform safeZoneRightLimit;
    public bool gameOver = false;
    public Transform gameOverText;
    public Transform playerWinsText;
    private Vector3 velocity = Vector3.zero;


    // Use this for initialization
    void Start()
    {
        safeZoneLeftLimit = transform.GetChild(0);
        safeZoneRightLimit = transform.GetChild(1);
    }

    // Update is called once per framet\
    void Update()
    {
        if (!gameOver)
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

    public void GameOver()
    {
        gameOver = true;
        gameOverText.GetComponent<SpriteRenderer>().enabled = true;
        //this.transform.position = Vector3.Lerp(this.transform.position, , 0.2f);
        this.transform.position = Vector3.Lerp(transform.position, new Vector3(gameOverText.position.x + 15, gameOverText.position.y + 10, transform.position.z), 0.5f);
        this.GetComponent<Camera>().orthographicSize = 13;
        //this.transform.position = new Vector3(gameOverText.position.x, gameOverText.position.y, transform.position.z);
        playerPosition.GetComponent<PlayerMovement>().enabled = false;
    }

    public void PlayerWins()
    {
        gameOver = true;
        playerWinsText.GetComponent<SpriteRenderer>().enabled = true;
        //this.transform.position = Vector3.Lerp(this.transform.position, , 0.2f);
        this.transform.position = Vector3.Lerp(transform.position, new Vector3(playerWinsText.position.x - 20, playerWinsText.position.y + 10, transform.position.z), 0.5f);
        this.GetComponent<Camera>().orthographicSize = 13;
        //this.transform.position = new Vector3(gameOverText.position.x, gameOverText.position.y, transform.position.z);
        playerPosition.GetComponent<PlayerMovement>().enabled = false;
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
    }
}
