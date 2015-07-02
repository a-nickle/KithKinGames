using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
	private bool _isDead = false;
	public bool IsDead
	{
		get
		{
			return _isDead;
		}
	}
	
	[SerializeField]
	private float _maxHealth;
	[SerializeField]
	private float _currentHealth;
	
	public float _damageReduction;
	
	// Use this for initialization
	void Start () 
	{
		_currentHealth = _maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		ClampHealth();
		
		if(_currentHealth <= 0.0f)
		{
			_isDead = true;
		}
		
		// Kill switch for the player *testing purposes*
		if(Input.GetKeyDown(KeyCode.RightControl))
		{
			_isDead = true;
			TakeDamage(_currentHealth + _damageReduction);
		}
		
		// Return the player to max health *testing purposes*
		if(Input.GetKeyDown (KeyCode.Return))
		{
			_currentHealth = _maxHealth;
			_isDead = false;
			
			Debug.Log("Player Revived");
		}
	}
	
	public void TakeDamage(float amount)
	{
		float damageTaken = amount - _damageReduction;
		
		if(damageTaken > _currentHealth)
		{
			damageTaken = _currentHealth;
		}
		
		_currentHealth -= damageTaken;
		Debug.Log("Is the Player Dead: " + _isDead);
	}
	
	private void ClampHealth()
	{
		if(_currentHealth >= _maxHealth)
		{
			_currentHealth = _maxHealth;
		}
		else if(_currentHealth <= 0.0f)
		{
			_currentHealth = 0.0f;
		}
	}
}
