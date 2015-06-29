using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	void FixedUpdate()
	{
		MovePlayer();
	}
	
	/// <summary>
	/// Function gets the input and moves the player.
	/// </summary>
	private void MovePlayer()
	{
		float move;
		float rotation;
		
		move =  Input.GetAxis("Vertical") * Constants.PLAYER_MOVE_SPEED * Time.deltaTime;
		
		rotation = Input.GetAxis("Horizontal") * Constants.PLAYER_ROTATION_SPEED * Time.deltaTime;
		
		// Move forward and rotate based on input.
		transform.Translate(Vector3.forward * move);
		transform.Rotate(Vector3.up * rotation);
	}
	
}