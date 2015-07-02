using UnityEngine;
using System.Collections;

public class AbilityManager : MonoBehaviour 
{
	[SerializeField]
	private Material _playerMat;// Temporary for visuals
	private int _abilityID;
	private ParticleSystem _particles;// Temporary for visuals
	
	private Resource _playerAbilityResource;
	
	private int _manaToUse;
	
	public int AbilityID
	{
		get
		{
			return _abilityID;
		}
	}
	
	// Use this for initialization
	void Start () 
	{		
		_particles = this.GetComponent<ParticleSystem>();
		
		// Default to ability 1
		_manaToUse = 10;
		_abilityID = 1;
		_particles.startColor = Color.blue;
		_playerMat.color = Color.blue;
		
		_playerAbilityResource = gameObject.GetComponent<Resource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		ReadyAbility();
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			ActivateAbility();
		}
	}
	
	private void ReadyAbility()
	{
		if(Input.GetKeyUp(KeyCode.P))
		{
			_manaToUse = 10;
			_playerMat.color = Color.blue;
			_particles.startColor = Color.blue;
			_abilityID = 1;
		}
		
		if(Input.GetKeyUp(KeyCode.O))
		{
			_manaToUse = 20;
			_playerMat.color = Color.red;
			_particles.startColor = Color.red;
			_abilityID = 2;
		}
		
		if(Input.GetKeyUp(KeyCode.I))
		{
			_manaToUse = 50;
			_playerMat.color = Color.green;
			_particles.startColor = Color.green;
			_abilityID = 3;
		}
		
		if(Input.GetKeyUp (KeyCode.U))
		{
			_manaToUse = 100;
			_playerMat.color = Color.yellow;
			_particles.startColor = Color.yellow;			
			_abilityID = 4;
		}
	}
	
	public void ActivateAbility()
	{			
		if(_playerAbilityResource.UseResource(_manaToUse))
		{
			Debug.Log ("Activate Ability: " + AbilityID );
			_particles.Emit(50);
		}
		else
		{		
			Debug.Log("InsufficientMana");
		}
	}
}