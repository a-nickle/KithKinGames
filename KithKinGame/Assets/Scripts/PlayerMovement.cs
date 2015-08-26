using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{	
	[SerializeField]
	private int playerID;
	
	void FixedUpdate()
	{
		MovePlayer();
		RotatePlayer();
		
		if(playerID < 1)
		{
			playerID = 1;
		}
		
		else if(playerID > 5)
		{
			playerID = 5;
		}
	}
	
	/// <summary>
	/// Function gets the input and moves the player.
	/// </summary>
	private void MovePlayer()
	{
		float fwdmove;
		float sdemove;
		
		fwdmove = Input.GetAxis("VerticalP" + playerID) * Constants.PLAYER_MOVE_SPEED * Time.deltaTime;
		sdemove = Input.GetAxis("HorizontalP" + playerID) * Constants.PLAYER_MOVE_SPEED * Time.deltaTime;
		
		// Move forward and rotate based on input.
		transform.Translate(Vector3.forward * fwdmove);
		transform.Translate(Vector3.left * sdemove);
	}
	
	private void RotatePlayer()
	{
		float xAxis = Input.GetAxis("RotationXP" + playerID);
		float yAxis = -Input.GetAxis("RotationYP" + playerID);
		
		if(xAxis != 0.0f || yAxis != 0.0f)
		{
			float angle = Mathf.Atan2(yAxis, xAxis) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(90.0f - angle, Vector3.up);
		}
	}
	
}