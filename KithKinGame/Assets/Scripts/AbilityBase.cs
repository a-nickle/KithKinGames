using UnityEngine;
using System.Collections;

public abstract class AbilityBase : MonoBehaviour 
{
	protected float damage;
	
	protected float cooldown;
	
	abstract protected void Activate();
}
