using UnityEngine;
using System.Collections;



public class carController : MonoBehaviour
{

    public float carSpeed;
   
    Vector3 position;
    public uiManager ui;
    public AudioManager am;

    public static int life;

    private bool currentPlatformAndroid = false;
    private float maxPos;
    private Vector3 cam;
    private Rigidbody2D rb;

    void Awake()
    {
        am.carSound.Play();
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

        // Permite que o carro ajuste seu curso em diferentes resoluções e tipos de tela
        cam = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        maxPos = -cam.x - 0.5f;
    }


    void Update()
    {
        if (currentPlatformAndroid)
        {
            
        }
        else
        {
            position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;  
        }

        position = transform.position;
        position.x = Mathf.Clamp(position.x, -maxPos, maxPos);
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy Car")
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            ui.gameOverActivated();
            am.carSound.Stop();
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
