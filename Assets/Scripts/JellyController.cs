using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JellyController : MonoBehaviour
{
	public bool canMove = true;
	public bool canLook = true;
	public bool canStretch = true;
	public int jumpCost = 1;
	public int hookCost = 2;
	public int maxEnergy = 10;
	public int energy = 10;
	public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
		slider.maxValue = maxEnergy;
		slider.value = energy;
	}

    // Update is called once per frame
    void Update()
    {
		slider.value = energy;
	}

	public void AddEnergy(int e)
	{
		if(e + energy <= maxEnergy)
		{
			energy += e;
		}
		else
		{
			energy = maxEnergy;
		}
	}

	public void ConsumeEnergy(int e)
	{
		if (energy - e >= 0)
		{
			energy -= e;
		}
		else
		{
			energy = 0;
		}
	}

	public bool canJump()
	{
		if(energy >= jumpCost)
		{
			energy -= 1;
			return true;
		}

		return false;
	}

	public bool CanHook()
	{
		if(energy >= hookCost)
		{
			return true;
		}

		return false;
	}

	public void ConsumeHookEnergy()
	{
		energy -= hookCost;
	}
}
