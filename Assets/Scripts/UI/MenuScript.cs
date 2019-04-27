
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine; 

//Borrowed from http://www.xenosmashgames.com/creating-start-menu-unity-5/
public class MenuScript : MonoBehaviour {
	
	//TODO unrelated but fix up dungeon after making settings menu
	//Play
	public Canvas playMenu;
	public Button startBtn;
	
	//Quit
	public Canvas quitMenu;
	public Button exitBtn;

	//Settings
	//public Canvas optMenu;
	//public Button optBtn;
	//public Dropdown m_Dropdown;
	//public List<string> m_DropOptions = new List<string> { "800x600", "1024x768" };
	void Start()
	{
		//Screen.fullScreen = false;
		//Screen.SetResolution(800, 600, false);
		quitMenu=quitMenu.GetComponent<Canvas>();
		exitBtn = exitBtn.GetComponent<Button>();
		quitMenu.enabled = false;

		playMenu =playMenu.GetComponent<Canvas>();
		startBtn=startBtn.GetComponent<Button>();
		playMenu.enabled = true;

		//optMenu = optMenu.GetComponent<Canvas>();
		//optBtn = optBtn.GetComponent<Button>();
		//optMenu.enabled = false;

		//m_Dropdown = m_Dropdown.GetComponent<Dropdown>();

	}
	void Update()
	{
		//TODO include code below in player controls script
		//if (Input.GetKey(KeyCode.Escape))
		//	SceneManager.LoadScene(0);
		//For cursor 
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	void FixedUpdate()
	{
		if (Input.GetAxis("Cancel") == 1)
		{
			Debug.Log("Cancel");
			NoPress();
		}

		if(Input.GetAxis("Start") == 1)
		{
			StartLevel();
		}
	}
	//Opens up Exit Menu
	public void ExitPress() //this function will be used on our Exit button
	{
		quitMenu.enabled = true; //enable the Quit menu when we click the Exit button
		exitBtn.enabled=true;

		playMenu.enabled = false;
		startBtn.enabled = false; //then disable the Play and Exit buttons so they cannot be clicked

		//optMenu.enabled = false;
		//optBtn.enabled = false;
	}
	//For Cancel
	public void NoPress() //this function will be used for our "NO" button in our Quit Menu
	{
		quitMenu.enabled=false; //we'll disable the quit menu, meaning it won't be visible anymore
		startBtn.enabled=true; //enable the Play and Exit buttons again so they can be clicked
		exitBtn.enabled=true;
		playMenu.enabled=true;
		//optMenu.enabled = false;
		//optBtn.enabled = true;
	}

	//public void OptPress() // Opens popup menu to choose either single or multiplayer
	//{
	//	playMenu.enabled = false;
	//	startBtn.enabled = false;

	//	quitMenu.enabled = false;
	//	exitBtn.enabled = false;

	//	optMenu.enabled = true;
	//	optBtn.enabled = true;
	//	ChangeRes();

	//}
	// Functions that affect the game's state
	//TODO make state-based game manager
	//Opens up game level
	public void StartLevel() //this function will be used on our Play button
	{
		SceneManager.LoadScene(1); //this will load our first level from our build settings. "1" is the second scene in our game
	}

	//Adjust resolution
	//public void ChangeRes()
	//{
	//	//Fetch the Dropdown GameObject the script is attached to
	//	//m_Dropdown = GetComponent<Dropdown>();
	//	//Clear the old options of the Dropdown menu
	//	m_Dropdown.ClearOptions();
	//	//Add the options created in the List above
	//	m_Dropdown.AddOptions(m_DropOptions);
	//	if (m_Dropdown.value == 0)
	//	{
	//		Screen.SetResolution(800, 600, false);
	//	}
	//	if (m_Dropdown.value == 1)
	//	{
	//		Screen.SetResolution(1024, 768, false);
	//	}
	//}
	// Exits Game
	public void ExitGame() //This function will be used on our "Yes" button in our Quit menu
	{
		Application.Quit(); //this will quit our game. Note this will only work after building the game
	}


}
