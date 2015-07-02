using UnityEngine;
using System.Collections;

public class Mana : Resource
{		
	private float _refreshTimer;
	
	private bool _refreshMana;
	
	
	void Start () 
	{
		_currentSource = _maxSource;
		_refreshMana = false;
		_refreshTimer = 5.0f;		
	}
	
	// Update is called once per frame
	void Update () 
	{
		CoolDownToRefresh();
		
		ClampMana();
		
		if(_refreshMana)
		{
			RechargeMana();
		}
		
		if(Input.GetKey(KeyCode.LeftControl))
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
			_refreshMana = true;
		}
	}
	
	public override bool UseResource(float amount)
	{
		if(amount > _currentSource)
		{
			_canUseAbility = false;
		}
		else
		{
			_currentSource -= amount;
			_canUseAbility = true;
			_refreshMana = false;
			_refreshTimer = 5.0f;
		}
		
		return _canUseAbility;
	}
	
	public void RechargeMana()
	{	
		_currentSource += (10*Time.deltaTime);
	}
	
	private void ForceRecharge()
	{	
		_currentSource += (20*Time.deltaTime);
		
		if(_refreshMana != false)
		{
			_refreshMana = false;
			_refreshTimer = 5.0f;
		}
	}
	
	private void ClampMana()
	{
		if(_currentSource >= _maxSource)
		{
			_refreshMana = false;
			_currentSource = _maxSource;
		}
		else if(_currentSource < 0.0f)
		{
			_currentSource = 0.0f;
		}
	}
}