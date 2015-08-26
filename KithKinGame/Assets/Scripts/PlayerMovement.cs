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
		float fwdmove;
		float sdemove;
		
		fwdmove =  Input.GetAxis("Vertical") * Constants.PLAYER_MOVE_SPEED * Time.deltaTime;
		
		sdemove = Input.GetAxis("Horizontal") * (-Constants.PLAYER_MOVE_SPEED) * Time.deltaTime;
		
		// Move forward and rotate based on input.
		transform.Translate(Vector3.forward * fwdmove);
		transform.Translate(Vector3.left * sdemove);
	}
	
}