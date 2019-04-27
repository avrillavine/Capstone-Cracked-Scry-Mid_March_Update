using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	public AudioSource _audio;
	public AudioClip _clip;
	public bool keyfound = false;
	public bool playSound = false;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			GetComponent<Renderer>().enabled = false;
			keyfound = true;
			if (!playSound)
			{
				_audio.clip = _clip;
				_audio.playOnAwake = false;
				_audio.Play();
				playSound = true;
			}
		}
	}
}
