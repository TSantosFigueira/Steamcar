using UnityEngine;
using System.Collections;

public class carController : MonoBehaviour
{

    public float carSpeed;
   
    Vector3 position;
    public uiManager ui;
    public AudioManager am;
    public Sprite femaleCar;
    public Sprite maleCar;

    public static int life;
    public static int score;

    private bool currentPlatformAndroid = false;
    private float maxPos;
    private Vector3 cam;
    private Rigidbody2D rb;
    private string gender;

    void Awake()
    {
       // am.carSound.Play();
        rb = GetComponent<Rigidbody2D>();

#if UNITY_ANDROID
        currentPlatformAndroid = true;
#else
        currentPlatformAndroid = false;
#endif

    }

    void Start()
    {
        position = transform.position;
        score = 0;
        // Permite que o carro ajuste seu curso em diferentes resoluções e tipos de tela
        cam = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        maxPos = -cam.x - 0.5f;

        gender = PlayerPrefs.GetString("gender", "female");

        if (gender == "female")
        {
            life = 1;
            GetComponent<SpriteRenderer>().sprite = femaleCar;
        }
        else
        {
            life = 2;
            GetComponent<SpriteRenderer>().sprite = maleCar;
        }
    }


    void Update()
    {
        if (!currentPlatformAndroid)
        {
            position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        }

        position = transform.position;
        position.x = Mathf.Clamp(position.x, -maxPos, maxPos);
        transform.position = position;

        if (Input.GetButton("RightButton")) MoveRight();
        else if (Input.GetButton("LeftButton")) MoveLeft();
        else { SetVelocityZero(); }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
        if (col.gameObject.tag == "Enemy Car")
        {
            //Destroy(gameObject);
            //gameObject.SetActive(false);
            //ui.gameOverActivated();
            //am.carSound.Stop();
            life--;
        }
        if(col.gameObject.tag == "Droid")
        {
            if(gender == "female")
            {
                score += 100 * 2;
            }
            else
            {
                score += 100;
            }
        }
    }

    public void MoveLeft ()
    {
        rb.velocity = new Vector2(-carSpeed, 0);
    }

    public void MoveRight ()
    {
        rb.velocity = new Vector2(carSpeed, 0);
    }

    public void SetVelocityZero ()
    {
        rb.velocity = Vector2.zero;
    }
}
