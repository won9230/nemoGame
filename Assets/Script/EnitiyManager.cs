using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class EnitiyManager : MonoBehaviour
{
	public int hp
	{
		get 
		{  
			return hp; 
		}
		set 
		{ 
			hp = value;
		}
	}
}