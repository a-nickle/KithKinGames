using UnityEngine;
using System.Collections;

public class Darkness : Resource 
{
	private float _refreshTimer;
	
	private bool _refreshDarkness;
	
	private PlayerMovement _playerMovement;
	private AbilityManager _abilityManager;	
	private Health _playerHealth;
	
	private bool _forcingRecharge;
	
	void Start () 
	{
		_currentSource = 0.0f;
		_refreshDarkness = false;
		_refreshTimer = 5.0f;
		_playerMovement = GetComponent<PlayerMovement>();
		_abilityManager = GetComponent<AbilityManager>();
		_playerHealth = GetComponent<Health>();		
	}
	
	// Update is called once per frame
	void Update () 
	{
		CoolDownToRefresh();
		
		ClampDarkness();
		
		if(_refreshDarkness)
		{
			RechargeDarkness();
		}
		
		if(Input.GetKey(KeyCode.LeftControl))
		{
			_forcingRecharge = true;
		}
		
		if(_forcingRecharge)
		{
			ForceRecharge();
		}
	}
	
	public void CoolDownToRefresh()
	{
		if(_refreshTimer > 0.0f)
		{
			_refreshTimer -= Time.deltaTime;
		}		
		else
		{
			_refreshDarkness = true;
		}
	}
	
	public override bool UseResource(float amount)
	{
		if(_currentSource == _maxSource)
		{ 
			_playerHealth.TakeDamage(amount);
		}
		else if ((_currentSource + amount) > _maxSource)
		{
			float container = _currentSource + amount;
			float difference = container - _maxSource;
			
			_currentSource = _maxSource;
			_playerHealth.TakeDamage(difference);
		}
		else
		{
			_currentSource += amount;
		}
		
		_refreshDarkness = false;
		_refreshTimer = 5.0f;
		
		return true;
	}
	
	public void RechargeDarkness()
	{	
		if(_currentSource > 0.0f)
		{
			_currentSource -= (10*Time.deltaTime);
		}
		else if( _currentSource < 0.0f)
		{
			_refreshTimer = 5.0f;
			_refreshDarkness = false;
		}
	}
	
	private void ForceRecharge()
	{
		if(_currentSource > 0.0f)	
		{
			_currentSource -= (20*Time.deltaTime);
			
			if(_refreshTimer != 5.0f)
			{
				_refreshDarkness = false;
				_refreshTimer = 5.0f;
			}
			_playerMovement.enabled = false;
			_abilityManager.enabled = false;
		}
		else if(_currentSource <= 0.0f)
		{
			_playerMovement.enabled = true;
			_abilityManager.enabled = true;	
			_forcingRecharge = false;		
		}
	}
	
	private void ClampDarkness()
	{
		if(_currentSource >= _maxSource)
		{
			_refreshDarkness = false;
			_currentSource = _maxSource;
		}
		else if(_currentSource < 0.0f)
		{
			_currentSource = 0.0f;
		}
	}
}
