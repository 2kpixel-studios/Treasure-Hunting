using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Rigidbody r;
	public float speed;
	public float jumpSpeed;
	public float jumpTime = 2;
	
	private float moveHorizontal;
	private float jump;

	void Start() {
		r = GetComponent<Rigidbody>();
    }

    private void Update() {
		moveHorizontal = Input.GetAxis("Horizontal");
		jump = Input.GetAxis("Jump");
		Vector3 horizontalMovement = new Vector3(0, 0, moveHorizontal);

		if(moveHorizontal != 0)
			r.AddForce(horizontalMovement * speed);
		if (jump > 0.1f)
			StartCoroutine(JumpRoutine());
	}

	private IEnumerator JumpRoutine() {
		r.velocity = Vector3.zero;
		Vector3 jumpVector = new Vector3(0, 1, 0) * jumpSpeed;

		float timer = 0;
		while (Input.GetAxis("Jump") > 0.1f && timer < jumpTime) {
			//Calculate how far through the jump we are as a percentage
			//apply the full jump force on the first frame, then apply less force
			//each consecutive frame

			float portionCompleted = timer / jumpTime;
			Vector3 thisFrameJumpVector = Vector3.Lerp(jumpVector, Vector3.zero, portionCompleted);
			r.AddForce(thisFrameJumpVector);
			timer += Time.deltaTime;
			yield return null;
		}
	}
}
