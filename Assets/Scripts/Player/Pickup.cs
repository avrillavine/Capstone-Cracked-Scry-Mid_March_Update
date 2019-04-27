using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Pickup : MonoBehaviour
{

	public TextMeshProUGUI cash_text;
	public int cash_amount = 0;
	public int cash_counter = 0;
	public AudioSource _audio;
	public AudioClip _clip;
	// Start is called before the first frame update
	void Start()
    {
		_audio.playOnAwake = false;
		_audio.clip = _clip;
    }

    // Update is called once per frame
    void Update()
    {
		cash_text.text = "$" + cash_amount.ToString();
		cash_amount = cash_counter;
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Currency")
		{
			_audio.Play();
			Destroy(other.gameObject);
			cash_counter++;
		}
	}
}
