using UnityEngine;
using System.Collections;

public class PlayMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume", 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
