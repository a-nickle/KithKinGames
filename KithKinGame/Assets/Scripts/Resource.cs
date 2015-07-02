using UnityEngine;
using System.Collections;

public abstract class Resource : MonoBehaviour 
{
	[SerializeField]
	protected float _maxSource;
	[SerializeField]
	protected float _currentSource;
	
	protected bool _canUseAbility;
	
	public bool CanUseAbility
	{
		get
		{
			return _canUseAbility;
		}
	}
	
	public abstract bool UseResource(float amount);
}
