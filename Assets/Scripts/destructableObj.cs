using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(AudioSource))]
public class destructableObj : MonoBehaviour {

	//AudioSource _audio;
	public GameObject remains;
	
	//public AudioClip breaking_sound;

	// Use this for initialization
	void Start () {
		//_audio = GetComponent<AudioSource>();
		//isDead=false;
		//GetComponent<AudioSource>().playOnAwake = false;
		//GetComponent<AudioSource>().clip = breaking_sound;
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetKey(KeyCode.Space))
		//{
		//	Instantiate(remains, remains.transform.position, remains.transform.rotation);
		//	Destroy(gameObject);
			//DestroyObj();
			//isDead=true;
		//}
	}

	private void OnTriggerEnter(Collider other)
	{
		//if (other.tag == "Rock" || other.tag == "Player")
		//{
			//GetComponentInChildren<Animator>().SetTrigger("fall");
			//animator.SetTrigger("fall");
		//	DestroyObj();
			//Instantiate(remains, remains.transform.position, remains.transform.rotation);
			//	Destroy(gameObject);
			//GetComponent<AudioSource>().PlayOneShot(breaking_sound);
			//_audio.clip = breaking_sound;
			//_audio.Play();
		//	Debug.Log("Vase Hit!");
		//}
		if(other.tag == "Rock"||other.tag == "Toe")
		{
			DestroyObj();
			Debug.Log("Vase Hit!");
		}
	}

	private void DestroyObj()
	{

		Instantiate(remains, transform.position, transform.rotation);
		Destroy(gameObject);
	}

	//private void RebuildObj()
	//{
	//	if(!isDead)
	//	{
	//		Instantiate(gameObject, transform.position, transform.rotation);
	//	}
	//	else
	//	{

	//	}
		
	//}
}
