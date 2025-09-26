using TMPro;
using UnityEngine;

public class WASDcontroller : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D myRB;
    public float jumpForce = 200f;
    public bool jumped = false;
    public bool grounded = false;
    public int destroyedCount = 0;
    public GameObject myPlayer;
    public gameManager myManager;
    public int destroyedMyPlayerCount = 0;
    public TextMeshProUGUI timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       myRB = GetComponent<Rigidbody2D>();
        grounded = false;
        destroyedCount = 0;
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && grounded)
        {
            jumped = true;
        }
    }


    void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            {
            velocity.y = speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.y = -speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = speed;
        }
        myRB.AddForce(velocity);

        if (jumped)
        {
            Jump();
            jumped = false;
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spike")
        {

            destroyedMyPlayerCount += 1;

            if (destroyedMyPlayerCount == 3)
            {
                timerText.enabled = false;
                myManager.EndGame();
            }

        }
        if (other.gameObject.tag == "Destructible")
        {
            Destroy(other.gameObject);
            destroyedCount += 1;
        }

        if(other.gameObject.tag == "winPad")
        {
           if (destroyedCount == 3)
            {
                timerText.enabled = false;
                myManager.EndGame();

            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        grounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
    void Jump()
    {
        myRB.AddForce(Vector3.up * jumpForce);
    }
}

   