using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
    public float speed;
    public Vector3 target;
    Vector3 direction;
    public bool getSucked;
	// Use this for initialization
	void Start () {
      
        direction = (target - gameObject.transform.position).normalized;
        
    }
	
	// Update is called once per frame
	void Update () {
        
        gameObject.transform.Translate(direction*speed*Time.deltaTime*60);

        if (getSucked) {
            speed *= 1.05f;
            gameObject.transform.localScale *= 0.95f;
        }


        
    }

}
