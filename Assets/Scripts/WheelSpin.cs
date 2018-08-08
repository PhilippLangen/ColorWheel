using UnityEngine;
using System.Collections;
public class WheelSpin : MonoBehaviour
{
  
    Vector3 mousePos;
    Vector3 objectCenter;
    float angle;
    float angleOld;

    // Use this for initialization
    void Start()
    {
        objectCenter = new Vector3(Screen.width / 2, Screen.height / 2,0);
        Debug.Log(PlayerPrefs.GetFloat("wheelSpeed",1));

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        { //something is touching


            mousePos = Input.mousePosition - objectCenter;

            Vector3 mouseDir = mousePos.normalized;

            angle = Mathf.Acos(mouseDir.y) * Mathf.Rad2Deg;

            
            if (angleOld == 1000) //notCurrentlyInitialized
                angleOld = angle;

            float deltaAngle = (angleOld - angle);


            if (mouseDir.x < 0) {
            deltaAngle *= -1;
            }

            //  if (Mathf.Abs(mouseDir.x)> 0.2f) //bugfix dirty
            //     deltaAngle *= PlayerPrefs.GetFloat("wheelSpeed", 1);
      
            gameObject.transform.Rotate(0, 0, deltaAngle*Time.deltaTime*60*PlayerPrefs.GetFloat("wheelSpeed",1));
           
            angleOld = angle;


        }
        else
            angleOld = 1000; //deInitialize


    }
}