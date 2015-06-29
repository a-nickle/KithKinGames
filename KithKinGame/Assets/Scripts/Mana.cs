using UnityEngine;
using System.Collections;

public class Mana : MonoBehaviour 
{		
	[SerializeField]
	private float _maxMana;
	[SerializeField]
	private float _currentMana;
	
	private bool _canUseMana;
	
	private float _refreshTimer;
	
	private bool _refreshMana;
	
	public bool CanUseMana
	{
		get
		{
			return _canUseMana;
		}
	}
	
	public float CurrentMana
	{
		get
		{
			return _currentMana;
		}
	}
	
	// Use this for initialization
	void Start () 
	{
		_currentMana = _maxMana;
		_canUseMana = true;
		_refreshMana = false;
		_refreshTimer = 5.0f;		
	}
	
	// Update is called once per frame
	void Update () 
	{
		ClampMana();
		CoolDownToRefresh();
		Debug.Log(_currentMana);
		
		if(_refreshMana)
		{
			StartCoroutine(RechargeMana());
		}
	}
	
	public void UseMana(int amount)
	{
		if(_currentMana < amount)
		{
			_canUseMana = false;
			Debug.Log("Insufficient Mana");
			return;		
		}
		_refreshTimer = 5.0f;
		_refreshMana = false;
		_canUseMana = true;
		_currentMana -= amount;
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
	
	public IEnumerator RechargeMana()
	{	
		while(_currentMana != _maxMana && _refreshMana)	
		{
			yield return new WaitForSeconds(1);
			_currentMana += 5.0f;
		}
		
		yield return 0;
		_refreshMana = false;
	}
	
	private void ClampMana()	
	{
		if(_currentMana >= _maxMana)
		{
			_currentMana = _maxMana;
		}
		
		else if(_currentMana <= 0)
		{
			_currentMana = 0;
		}
	}
}