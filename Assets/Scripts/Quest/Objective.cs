using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objective : MonoBehaviour
{
	public TextMeshProUGUI quest_text;
	public GameObject door;
	public Key key;

	//public bool keyfound;
	//public bool keyFound = false;
	// Start is called before the first frame update


	//   // Update is called once per frame
	void Update()
	{

		if (!key.keyfound)
		{
			quest_text.text = "Find Key";
		}
		else
		{
			door.transform.rotation = Quaternion.AngleAxis(90, Vector3.up)* Quaternion.AngleAxis(-90, Vector3.right);
			quest_text.text = "Exit Opened";

		}
	}
}
