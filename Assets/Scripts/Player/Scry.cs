using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scry refers to using a tool to see things that cannot be seen through normal means (future/supernatural phonomenan)
// Scrying in this game does not let you see into the future, it does reveal hidden traps and hides enemies:P 
// cause the scry (magnifying glass) is cracked you see..
public class Scry : MonoBehaviour
{

	//Code was originally based on activating the effects based on distance and whether the player was facing either
	//tagged object, but due to some issues with trying to change which object was being "selected" and the fact
	//the shader effect was global based, this method has been scrapped for right now
	//As a result all specifically tagged objects with specfic shaders attached will activate at once if correct 
	//condition is met (whether or not the player has an object in their right hand)
	
	//References to the previous method (creating arrays and assigning all tagged objects to the arrays, than 
	// using a for loop to activate any in the players field of view) are still lying around
	// in script so that I can later reattempt trying to make the scry mechanic more sophisticated
	public Anim anim;
	//Lists for defining trap and enemy objects 
	//List<GameObject> traps;
	//GameObject[] trap;

	//List<GameObject> enemies;
	//GameObject[] enemy;

	//Timer Values for Shader effect
	public float max = 1.1f; // Fully Transparent
	public float min = 0.0f; // Opaque

	/// 
	/// TRAP VALUES
	///
	//Based off code from here https://gamedev.stackexchange.com/questions/121749/how-do-i-change-a-value-gradually-over-time
	//The whole idea is that the flags for keeping objects visible and enemies invisible is set to false 
	//Until the player sets off the flag
	//Trap Specific Timer Values
	public float rAmount = 1.1f; //Default Amount
	public float rRate = 4.0f;
	public bool materialize; //Effect trigger flag
	public bool trapSpotted;
	float revealTime; // modify the total, every second
    float timePerSecond; // modify the total, every second
	/// 
	/// ENEMY VALUES
	///
	//Enemy Specific Timer Values
	public float vAmount = 0.0f; //Default Amount
	public float vRate = 4.0f;
	public bool dissolve; //Effect trigger flag
	public bool enemySpotted;
	float vanishTime; // modify the total, every second
	int currentTrap;
	int trapInView;


	// Start is called before the first frame update
	void Start()
    {
		//DefineTraps();

		//enemies = new List<GameObject>();
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.H) || Input.GetButtonDown("Btn 0"))
		{
			//TaggedTrapInView();
			//Debug.Log(traps[currentTrap].name);
			//if (trapSpotted)
			//	materialize = true;
			//else
			//	materialize = false;
			
			if(!anim._hasRightHandObject) //Activate effects if hand is free to hold magnifying glass
			{
				materialize = true;
				dissolve = true;
			}
			else						  //Do not activate effects
			{
				materialize = false;
				dissolve = false;
			}
		}

		Reveal();
		Vanish();
	}

	//void DefineTraps()
	//{
	//	traps = new List<GameObject>();
	//	trap = GameObject.FindGameObjectsWithTag("Trap");
	//	traps.AddRange(trap);
	//	string trapList = traps.ToString();

	//	for(int i = 0; i < traps.Count; i++)
	//	{
	//		Debug.Log(traps[i].name + " is " + i);
	//	}
	//}
	// For both boolean functions, a specified current value is set for each shader
	// If flags for either shader is set to true, current value will go up or down at a certain rate
	// If current value is completely at its target amount (either max or min)
	// The current value increments back to its original value (either invisible or opaque)
	// The value from the shader has an underline for shader syntax reasons
	// Reveal's current value is "rAmount"
	// Vanish is "vAmount"
	

	// current value for this shader is set to be 1.1f (completely transparent)
	bool Reveal()
	{

		rAmount = Mathf.Clamp(rAmount + revealTime * Time.deltaTime, min, max); //Adjust values to be within the limits of the max/min values
		Shader.SetGlobalFloat("_rAmount", rAmount); //Affects Reveal Shader via a specificly named variable
		//If player sets boolean to true, start making the object reappear 
		if (materialize)
		{
			revealTime = (min - max) / rRate;
		}
		else
		{
			revealTime = (min + max) / rRate;
		}
		if (rAmount == min) 
		{
			materialize = false;
		}
		return materialize; //return flag 
	}
	// current value for this shader is set to be 0f (completely Opaque)
	bool Vanish()
	{

		vAmount = Mathf.Clamp(vAmount + vanishTime * Time.deltaTime, min, max);
		Shader.SetGlobalFloat("_vAmount", vAmount); //Affects Vanish Shader via a specificly named variable
		//If player sets boolean to true, start making the object reappear 
		if (dissolve)
		{
			vanishTime = (min + max) / vRate;
		}
		else
		{
			vanishTime = (min - max) / vRate;
		}
		if (vAmount == max)
		{
			dissolve = false;
		}
		return dissolve;
	}
	bool IsEnemyInView()
	{
		//traps.
		//Vector3 targetPos = target.transform.position;
		//Vector3 directionToTarget = transform.position - targetPos;
		//float angle = Vector3.Angle(transform.forward, directionToTarget);
		//float distance = directionToTarget.magnitude;
		//if (Mathf.Abs(angle) > 90 && distance < 20)//original (Mathf.Abs(angle) > 90 && distance < 10)
		//{
		//	Debug.DrawRay(targetPos, directionToTarget, Color.green, 2.0f);
		//	Debug.Log(target.name + " is in view");
		//	isInViewA = true;
		//}
		//else
		//{
		//	Debug.DrawRay(targetPos, directionToTarget, Color.red, 2.0f);
		//	Debug.Log(target.name + " is out of view");
		//	isInViewA = false;
		//}
		//return isInViewA;
		//based on code borrowed from here https://answers.unity.com/questions/253606/find-the-closest-target.html
		//if (Vector3.Distance(target.position, thisT.position) > Vector3.Distance(thing2.position, thisT.position))
		//{
		//	target = thing2;
		//	// remove thing2
		//}
		//else
		//{
		//	// remove thing2
		//}


		return enemySpotted;
	}

	//void TrapsClosestToYou()
	//{
		
	//	for(int i = 0;i < traps.Count; i++)
	//	{
	//		float distance = Vector3.Distance(traps[i].transform.position, transform.position);
	//		Debug.Log(traps[i].name + " is located " + distance + "units away");
	//		//Debug.Log(traps[i].name + " is " + tra);
	//		if(distance < 8 )
	//		{
	//			currentTrap = i;
	//		}
	//	}

	//}
	//void TaggedTrapInView()
	//{
	//	TrapsClosestToYou();
	//	for (int i = currentTrap; i < traps.Count; i++)
	//	{
	//		Vector3 target = traps[i].transform.position;
	//		Vector3 directionToTarget = transform.position - target;
	//		float angle = Vector3.Angle(transform.forward, directionToTarget);
	//		float distance = directionToTarget.magnitude;
	//		var st = traps[i].name;
	//		if (Mathf.Abs(angle) > 90 && distance < 20)//original (Mathf.Abs(angle) > 90 && distance < 10)
	//		{
	//			Debug.DrawRay(target, directionToTarget, Color.green, 2.0f);
	//			//Debug.Log("target is in front of me");
	//			Debug.Log(st + " is in view and its value is " + i);
	//			//currentTrap = i;
	//		}
	//	}
	//	//return currentTrap;
	//}
	//bool TriggerReveal()
	//{
	//	TaggedTrapInView();

	//	for(int i = currentTrap; i < traps.Count; i++)
	//	{
	//		if(currentTrap == trapInView)
	//		{
	//			trapSpotted = true;
	//		}
	//		else if (currentTrap != trapInView)
	//		{
	//			trapSpotted = false;
	//		}
	//	}
	//	return trapSpotted;
	//}
}
