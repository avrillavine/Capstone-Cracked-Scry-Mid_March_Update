using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Based off of code from here https://answers.unity.com/questions/171492/how-to-make-a-pause-menu-in-c.html
// I added in references to hiding and confining cursor to screen, and than making cursor appear again so player can
// select button to resume play

//Currently no implemented in this version 

//TODO 
// make start button of controller activate menu
// Have 2 options with arrow indicating current selection
// 2 options being:
// Resume (default)
// Return to main menu
// Mouse click or controller buttons should be able to select either option (either make sperate menu 
// based on whether the player has controller plugged in with a flag to check this, or make options work in 2 
// different ways)
// Mouse  --> clicks button or having only mouse brings up a specfic menu
// Controller --> open pause by clicking start button, change options (indicate by arrows pointing to 
// currently selected option) with dpad up and down (anim script must be referenced/deactivated to avoid conflict)
// Pressing 4 or jump key should be how button is activated

// Make XBox compatible

public class Pause : MonoBehaviour
{
	bool paused = false;
	public Movement _movementScript;
	public Canvas pauseMenu; 
	void Start()
	{
		//_movementScript = _movementScript.GetComponent<Movement>();
		pauseMenu = pauseMenu.GetComponent<Canvas>();
		pauseMenu.enabled = false;
		_movementScript.enabled = true;
	}
	void Update()
	{
		//Pressing escape key brings up pause menu, hitting escape again closes pause menu

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//Pause2();
			paused = TogglePause();
			//UnPause();
			//_movementScript.enabled = false;
			//pauseMenu.enabled = true;
			//paused = true;
		}
		//TODO Add return to menu button
	}

	//This function works by checking a flag that states whether the game time is at zero or not
	//So player can turn menu on and off using same key/controller button
	bool TogglePause()
	{

		if (Time.timeScale == 0f)						//Game can resume if time is already stopped
		{
			Time.timeScale = 1f;						//Starts time again
			_movementScript.enabled = true;				//Player can move again
			pauseMenu.enabled = false;					//Close pause menu
			
			Cursor.visible = false;						//Hide Cursor
			Cursor.lockState = CursorLockMode.Confined; //Confine cursor in screen
			return (false);
		}
		else										//Pause Game
		{
			Time.timeScale = 0f;					//Time is stopped
			_movementScript.enabled = false;		//Player cannot move around while pause menu is enabled
			pauseMenu.enabled = true;				//Brings up pause menu
			Cursor.visible = true;					//Brings up cursor
			Cursor.lockState = CursorLockMode.None;
			return (true);
		}
	}


}
