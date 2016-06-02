using UnityEngine;
using System.Collections;



public class carController : MonoBehaviour
{

    public float carSpeed;
    public float maxPos = 2.2f;

    Vector3 position;
    public uiManager ui;
    public AudioManager am;

    private bool currentPlatformAndroid = false;

    Rigidbody2D rb;

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
        position.x = Mathf.Clamp(position.x, -2.2f, 2.2f);
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
