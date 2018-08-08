using UnityEngine;
using UnityEngine.UI;


public class Spawn : MonoBehaviour {

    public Sprite fourWheel;
    public Sprite fiveWheel;
    public Sprite sixWheel;
    public GameObject destroyAll;
    public GameObject enemy;
    public GameObject wheel;
    public static int score;
    public float delay;
    public int nrGates;
    public int nrColors;
    Vector3[] Gates;
    Color[] Colors;
    float timer;
    SpriteRenderer wheelSprites;
    SpriteRenderer sr;
    EnemyMove mov;
    bool sentDestroyer;
    EdgeCollider2D blue;
    EdgeCollider2D red;
    EdgeCollider2D green;
    EdgeCollider2D yellow;
    EdgeCollider2D cyan;
    EdgeCollider2D violet;


    Text ScoreLable;

    // Use this for initialization
    void Start () {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //PlayerPrefs.SetInt("highscore", 0);
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        ScoreLable = FindObjectOfType<Canvas>().GetComponentInChildren<Text>();
        timer = Time.time;
        score = 0;
        delay = 2;
        nrGates = 1;
        sentDestroyer = false;
        Gates = new Vector3[8];
        Gates[0] = new Vector3(1.3f , 0, 0);
        Gates[1] = new Vector3(-1.3f, 0, 0);
        Gates[2] = new Vector3(0    , 1.3f, 0);
        Gates[3] = new Vector3(0    ,-1.3f, 0);
        Gates[4] = new Vector3(0.92f , 0.92f, 0);
        Gates[5] = new Vector3(-0.92f, 0.92f, 0);
        Gates[6] = new Vector3(0.92f ,-0.92f, 0);
        Gates[7] = new Vector3(-0.92f,-0.92f, 0);
        Colors = new Color[6];
        Colors[0] = new Color(0.86f, 0.16f, 0.16f, 1); //red
        Colors[1] = new Color(0.16f, 0.27f, 0.86f, 1); //blue
        Colors[2] = new Color(0.85f, 0.86f, 0.16f, 1);//yellow 
        Colors[3] = new Color(0.16f, 0.86f, 0.28f, 1); //green
        Colors[4] = new Color(0.16f, 0.86f, 0.86f, 1);//cyan
        Colors[5] = new Color(0.78f, 0.16f, 0.86f, 1);//violet
        wheelSprites = wheel.GetComponent<SpriteRenderer>();
         sr = enemy.GetComponent<SpriteRenderer>();
        mov = enemy.GetComponent<EnemyMove>();
        mov.speed = 0.008f;

        blue = wheel.transform.FindChild("Blue").GetComponent<EdgeCollider2D>(); 
        blue.name = "RGBA(0.160, 0.270, 0.860, 1.000)";
        red = wheel.transform.FindChild("Red").GetComponent<EdgeCollider2D>();
        red.name = "RGBA(0.860, 0.160, 0.160, 1.000)";
        green = wheel.transform.FindChild("Green").GetComponent<EdgeCollider2D>();
        green.name = "RGBA(0.160, 0.860, 0.280, 1.000)";
        yellow = wheel.transform.FindChild("Yellow").GetComponent<EdgeCollider2D>();
        yellow.name = "RGBA(0.850, 0.860, 0.160, 1.000)";
        violet = wheel.transform.FindChild("Violet").GetComponent<EdgeCollider2D>();
        violet.name = "RGBA(0.780, 0.160, 0.860, 1.000)";
        cyan = wheel.transform.FindChild("Cyan").GetComponent<EdgeCollider2D>();
        cyan.name = "RGBA(0.160, 0.860, 0.860, 1.000)";
        violet.enabled = false;
        cyan.enabled = false;
        setFourColor();

    }

    // Update is called once per frame
    void Update()
    {
       
       
        ScoreLable.text = "Score: " + score.ToString();
        if (Time.time > timer)
        {
            sr.color = Colors[Random.Range(0, nrColors)];
            Instantiate(enemy, Gates[Random.Range(0, nrGates)], Quaternion.identity);
            timer += delay;
            mov.speed = Mathf.Clamp(0.008f + (Mathf.Pow(score,0.7f) * 0.00014f), 0.008f, 0.03f);
            
            delay = Mathf.Clamp(2 - (Mathf.Pow(score,0.7f) * .04f), 0.75f, 2);
        }
      
        switch (score)  //difficulties
        {

            case 5:
                nrGates=2;
                break;
            case 15:
                nrGates=3; break;
            case 30:
                nrGates=4; break;
            case 50:

                if (!sentDestroyer)
                {
                    setFiveColor();
                    Instantiate(destroyAll, new Vector3(0, 0, 0), Quaternion.identity);
                    sentDestroyer = true;
                }
                break;
            case 65:
                sentDestroyer = false;
                nrGates=5; break;
            case 80:
                nrGates=6; break;
            case 100:

                if (!sentDestroyer)
                {
                    setSixColor();
                    Instantiate(destroyAll, new Vector3(0, 0, 0), Quaternion.identity);
                    sentDestroyer = true;
                }
                break;
            case 120:
                sentDestroyer = false;
                nrGates=7; break;
            case 140:
                nrGates=8; break;
                

        }








    }

    public void setFourColor() {
        nrColors = 4;
        wheelSprites.sprite = fourWheel;
       
        Vector2[] blueCoords = new Vector2[8];
        blueCoords[0] = new Vector2(0.5f,0f);
        blueCoords[1] = new Vector2(0.488f, 0.104f);
        blueCoords[2] = new Vector2(0.458f, 0.198f);
        blueCoords[3] = new Vector2(0.401f, 0.295f);
        blueCoords[4] = new Vector2(0.299f, 0.398f);
        blueCoords[5] = new Vector2(0.202f, 0.458f);
        blueCoords[6] = new Vector2(0.109f, 0.493f);
        blueCoords[7] = new Vector2(0f, 0.5f);
        blue.points = blueCoords;

        Vector2[] redCoords = new Vector2[8];
        redCoords[0] = new Vector2(0f, 0.5f);
        redCoords[1] = new Vector2(-0.101f, 0.488f);
        redCoords[2] = new Vector2(-0.200f, 0.459f);
        redCoords[3] = new Vector2(-0.305f, 0.398f);
        redCoords[4] = new Vector2(-0.404f, 0.296f);
        redCoords[5] = new Vector2(-0.460f, 0.197f);
        redCoords[6] = new Vector2(-0.492f, 0.098f);
        redCoords[7] = new Vector2(-0.5f, 0f);
        red.points = redCoords;

        Vector2[] greenCoords = new Vector2[8];
        greenCoords[0] = new Vector2(0.5f, 0f);
        greenCoords[1] = new Vector2(0.483f, -0.098f);
        greenCoords[2] = new Vector2(0.460f, -0.198f);
        greenCoords[3] = new Vector2(0.401f, -0.301f);
        greenCoords[4] = new Vector2(0.299f, -0.398f);
        greenCoords[5] = new Vector2(0.202f, -0.459f);
        greenCoords[6] = new Vector2(0.102f, -0.491f);
        greenCoords[7] = new Vector2(0f, -0.5f);
        green.points = greenCoords;

        Vector2[] yellowCoords = new Vector2[8];
        yellowCoords[0] = new Vector2(-0.5f, 0f);
        yellowCoords[1] = new Vector2(-0.488f, -0.104f);
        yellowCoords[2] = new Vector2(-0.458f, -0.198f);
        yellowCoords[3] = new Vector2(-0.401f, -0.295f);
        yellowCoords[4] = new Vector2(-0.299f, -0.398f);
        yellowCoords[5] = new Vector2(-0.202f, -0.458f);
        yellowCoords[6] = new Vector2(-0.109f, -0.493f);
        yellowCoords[7] = new Vector2(0f, -0.5f);
        yellow.points = yellowCoords;
    }

    public void setFiveColor()
    {
        nrColors = 5;
        wheelSprites.sprite = fiveWheel;

        Vector2[] blueCoords = new Vector2[8];
        blueCoords[0] = new Vector2(0f, 0.5f);
        blueCoords[1] = new Vector2(0.105f, 0.488f);
        blueCoords[2] = new Vector2(0.196f, 0.463f);
        blueCoords[3] = new Vector2(0.274f, 0.422f);
        blueCoords[4] = new Vector2(0.364f, 0.344f);
        blueCoords[5] = new Vector2(0.430f, 0.256f);
        blueCoords[6] = new Vector2(0.463f, 0.201f);
        blueCoords[7] = new Vector2(0.478f, 0.156f);
        blue.points = blueCoords;

        Vector2[] redCoords = new Vector2[8];
        redCoords[0] = new Vector2(-0.478f, 0.154f);
        redCoords[1] = new Vector2(-0.437f, 0.251f);
        redCoords[2] = new Vector2(-0.380f, 0.328f);
        redCoords[3] = new Vector2(-0.302f, 0.398f);
        redCoords[4] = new Vector2(-0.205f, 0.459f);
        redCoords[5] = new Vector2(-0.111f, 0.487f);
        redCoords[6] = new Vector2(-0.053f, 0.497f);
        redCoords[7] = new Vector2(0.002f, 0.5f);
        red.points = redCoords;

        Vector2[] greenCoords = new Vector2[8];
        greenCoords[0] = new Vector2(0.291f, -0.405f);
        greenCoords[1] = new Vector2(0.347f, -0.359f);
        greenCoords[2] = new Vector2(0.400f, -0.297f);
        greenCoords[3] = new Vector2(0.460f, -0.201f);
        greenCoords[4] = new Vector2(0.490f, -0.103f);
        greenCoords[5] = new Vector2(0.498f, -0.005f);
        greenCoords[6] = new Vector2(0.498f, 0.073f);
        greenCoords[7] = new Vector2(0.478f, 0.15f);
        green.points = greenCoords;

        Vector2[] yellowCoords = new Vector2[8];
        yellowCoords[0] = new Vector2(-0.479f, 0.154f);
        yellowCoords[1] = new Vector2(-0.490f, 0.087f);
        yellowCoords[2] = new Vector2(-0.498f, 0f);
        yellowCoords[3] = new Vector2(-0.488f, -0.102f);
        yellowCoords[4] = new Vector2(-0.465f, -0.178f);
        yellowCoords[5] = new Vector2(-0.428f, -0.267f);
        yellowCoords[6] = new Vector2(-0.372f, -0.333f);
        yellowCoords[7] = new Vector2(-0.294f, -0.402f);
        yellow.points = yellowCoords;


        cyan.enabled = true;
        Vector2[] cyanCoords = new Vector2[8];
        cyanCoords[0] = new Vector2(0.291f, -0.405f);
        cyanCoords[1] = new Vector2(0.198f, -0.458f);
        cyanCoords[2] = new Vector2(0.103f, -0.488f);
        cyanCoords[3] = new Vector2(-0.002f, -0.503f);
        cyanCoords[4] = new Vector2(-0.100f, -0.493f);
        cyanCoords[5] = new Vector2(-0.206f, -0.453f);
        cyanCoords[6] = new Vector2(-0.251f, -0.430f);
        cyanCoords[7] = new Vector2(-0.287f, -0.404f);
        cyan.points = cyanCoords;
    }

    public void setSixColor()
    {
        nrColors = 6;
        wheelSprites.sprite = sixWheel;

        Vector2[] blueCoords = new Vector2[6];
        blueCoords[0] = new Vector2(0.433f, 0.253f);
        blueCoords[1] = new Vector2(0.379f, 0.330f);
        blueCoords[2] = new Vector2(0.315f, 0.387f);
        blueCoords[3] = new Vector2(0.203f, 0.460f);
        blueCoords[4] = new Vector2(0.102f, 0.487f);
        blueCoords[5] = new Vector2(0.000f, 0.500f);
        blue.points = blueCoords;

        Vector2[] redCoords = new Vector2[6];
        redCoords[0] = new Vector2(-0.433f, 0.250f);
        redCoords[1] = new Vector2(-0.472f, 0.177f);
        redCoords[2] = new Vector2(-0.493f, 0.082f);
        redCoords[3] = new Vector2(-0.499f, -0.045f);
        redCoords[4] = new Vector2(-0.476f, -0.159f);
        redCoords[5] = new Vector2(-0.435f, -0.250f);
        red.points = redCoords;

        Vector2[] greenCoords = new Vector2[6];
        greenCoords[0] = new Vector2(0.433f, 0.253f);
        greenCoords[1] = new Vector2(0.472f, 0.158f);
        greenCoords[2] = new Vector2(0.493f, 0.082f);
        greenCoords[3] = new Vector2(0.500f, -0.045f);
        greenCoords[4] = new Vector2(0.475f, -0.162f);
        greenCoords[5] = new Vector2(0.430f, -0.244f);
        green.points = greenCoords;

        Vector2[] yellowCoords = new Vector2[6];
        yellowCoords[0] = new Vector2(0.000f, -0.501f);
        yellowCoords[1] = new Vector2(-0.097f, -0.494f);
        yellowCoords[2] = new Vector2(-0.196f, -0.460f);
        yellowCoords[3] = new Vector2(-0.287f, -0.410f);
        yellowCoords[4] = new Vector2(-0.363f, -0.346f);
        yellowCoords[5] = new Vector2(-0.431f, -0.252f);
        yellow.points = yellowCoords;


        cyan.enabled = true;
        Vector2[] cyanCoords = new Vector2[6];
        cyanCoords[0] = new Vector2(0.001f, -0.498f);
        cyanCoords[1] = new Vector2(0.094f, -0.491f);
        cyanCoords[2] = new Vector2(0.202f, -0.454f);
        cyanCoords[3] = new Vector2(0.299f, -0.401f);
        cyanCoords[4] = new Vector2(0.365f, -0.337f);
        cyanCoords[5] = new Vector2(0.430f, -0.244f);
        cyan.points = cyanCoords;


        violet.enabled = true;
        Vector2[] violetCoords = new Vector2[6];
        violetCoords[0] = new Vector2(-0.433f, 0.250f);
        violetCoords[1] = new Vector2(-0.375f, 0.333f);
        violetCoords[2] = new Vector2(-0.306f, 0.395f);
        violetCoords[3] = new Vector2(-0.232f, 0.442f);
        violetCoords[4] = new Vector2(-0.117f, 0.491f);
        violetCoords[5] = new Vector2(-0.003f, 0.500f);
        violet.points = violetCoords;
    }

}
