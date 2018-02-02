using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(2, 0);
	}


}
