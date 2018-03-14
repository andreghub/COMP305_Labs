using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour {

    public Text Object0Text;
    public Text Object1Text;
    public Text Object2Text;

    private PlayerControllerLab5 playerController;

    // Use this for initialization
    void Start () {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerLab5>();
        Object0Text.text = playerController.objectCollected[0].ToString();
        Object1Text.text = playerController.objectCollected[1].ToString();
        Object2Text.text = playerController.objectCollected[2].ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
