using UnityEngine;
using System.Collections;

public class DestroyExpander : MonoBehaviour {
    int helper;
	// Use this for initialization
	void Start () {
        Collider2D collider = gameObject.AddComponent<CircleCollider2D>();
        collider.name = "destroyer";
        helper = Spawn.score;
	}
	
	// Update is called once per frame
	void Update () {

        if (Spawn.score > helper)
        {
            helper = Spawn.score;
            gameObject.GetComponent<AudioSource>().Play();
        }
        gameObject.transform.localScale *= 1.02f;
        if (gameObject.transform.localScale.x > 0.5f)
            Destroy(gameObject);
    }
}
