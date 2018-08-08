using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void TogglePause() {

        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            GameObject.Find("Music").GetComponent<AudioSource>().Pause();
            

        }
        else {
            Time.timeScale = 1;
            GameObject.Find("Music").GetComponent<AudioSource>().UnPause();
        }


    }

    public void ApplySettings()
    {
        
        PlayerPrefs.SetFloat("musicVolume", GameObject.Find("VolumeMusic").GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("soundVolume", GameObject.Find("VolumeSFX").GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("wheelSpeed", GameObject.Find("Wheelsensitivity").GetComponent<Slider>().value);
        SceneManager.LoadScene("gameOver");
    }

}


