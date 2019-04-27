using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootGenerator : MonoBehaviour
{
	//Based on code from https://answers.unity.com/questions/48566/instantiate-a-random-number-of-one-prefab.html
	public GameObject gold;
    // Start is called before the first frame update
    void Start()
    {
		int numOfLoot = Random.Range(0, 10);   // this will return a number between 0 and 9
		for (var i = 0; i < numOfLoot; i++)
			Instantiate(gold, transform.position, Quaternion.identity);


		if (numOfLoot == 1)
		{
			Debug.Log(numOfLoot + " coin dropped!");
		}
		if(numOfLoot == 0)
		{
			Debug.Log("Nothing dropped..");
		}
		if(numOfLoot > 1)
		{
			Debug.Log(numOfLoot + " coins dropped!");
		}
	}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
