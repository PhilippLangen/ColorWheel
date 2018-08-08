using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadSliderPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
         GameObject.Find("VolumeMusic").GetComponent<Slider>().value= PlayerPrefs.GetFloat("musicVolume",1);
         GameObject.Find("VolumeSFX").GetComponent<Slider>().value= PlayerPrefs.GetFloat("soundVolume", 1);
         GameObject.Find("Wheelsensitivity").GetComponent<Slider>().value= PlayerPrefs.GetFloat("wheelSpeed", 1);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
