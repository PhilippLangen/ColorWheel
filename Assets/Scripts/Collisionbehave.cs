using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Collisionbehave : MonoBehaviour {
    
    string color;
    AudioSource scoreSound;
	// Use this for initialization
	void Start () {
	color= gameObject.GetComponent<SpriteRenderer>().color.ToString();
    scoreSound = gameObject.GetComponent<AudioSource>();
        scoreSound.volume *=  PlayerPrefs.GetFloat("soundVolume");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        if (other.name == color || other.name == "Goal" || other.name== "destroyer")
        {
            Mathf.Clamp(scoreSound.pitch = 0.5f + Spawn.score /200f,0.5f,1.85f);
            scoreSound.Play();
            Debug.Log(scoreSound.pitch+" pitch");
            gameObject.GetComponent<EnemyMove>().getSucked = true;
            if (other.name == "Goal" || other.name == "destroyer")
            {
                
                Destroy(gameObject);
                Spawn.score++;
                
               


            }

        }
        else
        {
            if(gameObject.GetComponent<EnemyMove>().getSucked == false){
            if (PlayerPrefs.GetInt("highscore") < Spawn.score)
            {
                PlayerPrefs.SetInt("highscore", Spawn.score);
            }
            SceneManager.LoadScene("gameOver");
            Debug.Log("Lost");
            }

        }




    }


    
}
