using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowHighscore : MonoBehaviour {
    Image spin;
    Text backspin;
	// Use this for initialization
	void Start () {
        FindObjectOfType<Canvas>().GetComponentInChildren<Text>().text = "Highscore: " + PlayerPrefs.GetInt("highscore").ToString();
        Debug.Log(PlayerPrefs.GetInt("highscore"));

        spin = GameObject.Find("Play").GetComponent<Image>();
        backspin = GameObject.Find("Play").GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        spin.transform.Rotate(0, 0, 0.2f);
        backspin.transform.Rotate(0, 0, -0.2f);
        
	
	}
}
