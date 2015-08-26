using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{	
	void FixedUpdate()
	{
		MovePlayer();
		RotatePlayer ();
	}
	
	/// <summary>
	/// Function gets the input and moves the player.
	/// </summary>
	private void MovePlayer()
	{
		float fwdmove;
		float sdemove;
		
		//fwdmove = -Input.GetAxis("RotationY");
		fwdmove = Input.GetAxis("Vertical") * Constants.PLAYER_MOVE_SPEED * Time.deltaTime;
		sdemove = Input.GetAxis("Horizontal") * -Constants.PLAYER_MOVE_SPEED * Time.deltaTime;
		//sdemove = -Input.GetAxis("RotationX");
		
		// Move forward and rotate based on input.
		transform.Translate(Vector3.forward * fwdmove);
		transform.Translate(Vector3.left * sdemove);
	}
	
	private void RotatePlayer()
	{
		float xAxis = Input.GetAxis("RotationX");
		float yAxis = -Input.GetAxis("RotationY");
		
		if(xAxis != 0.0f || yAxis != 0.0f)
		{
			float angle = Mathf.Atan2(yAxis, xAxis) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(90.0f - angle, Vector3.up);
		}
	}
	
}