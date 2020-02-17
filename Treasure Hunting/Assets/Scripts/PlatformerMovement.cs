using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The player's movement in a 3D platformer.
/// </summary>
public class PlatformerMovement : MonoBehaviour {

	public Rigidbody r;
	public float speed;
	public float jumpSpeed;
	public float jumpTime = 2;

	private Vector3 desiredVelocity = Vector3.zero;
	private float moveHorizontal;
	private bool jump;
	private bool grounded = true;

	void Start() {
		r = GetComponent<Rigidbody>();
    }

    private void Update() {
		moveHorizontal = Input.GetAxis("Horizontal");
		jump = Input.GetButtonDown("Jump");
		Vector3 currentVelocity = r.velocity;
		Vector3 desiredVelocity = new Vector3(0, 0, moveHorizontal * speed);
		if(grounded == false) {
			jump = false;
		}
		if (jump) {
			desiredVelocity.y = jumpSpeed;
			grounded = false;
		}
		else
			desiredVelocity.y = currentVelocity.y;
		grounded = true;
		

		r.AddForce(desiredVelocity - r.velocity, ForceMode.VelocityChange);

		//if (jump > 0.1f)
		//	StartCoroutine(JumpRoutine());
	}

	//private IEnumerator JumpRoutine() {
	//	r.velocity = Vector3.zero;
	//	Vector3 jumpVector = new Vector3(0, 1, 0) * jumpSpeed;

		//float timer = 0;
		//while (Input.GetAxis("Jump") > 0.1f && timer < jumpTime) {
			//Calculate how far through the jump we are as a percentage
			//apply the full jump force on the first frame, then apply less force
			//each consecutive frame

			//float portionCompleted = timer / jumpTime;
			//Vector3 thisFrameJumpVector = Vector3.Lerp(jumpVector, Vector3.zero, portionCompleted);
			//r.AddForce(thisFrameJumpVector);
			//timer += Time.deltaTime;
			//yield return null;
		//}
	//}
}
