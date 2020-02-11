using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;
	public Rigidbody r;

    void Start() {
		r = GetComponent<Rigidbody>();
    }

    void Update() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float jump = Input.GetAxis("Jump");

		Vector3 movement = new Vector3(0, jump, moveHorizontal);

		r.AddForce(movement * speed);
    }
}
