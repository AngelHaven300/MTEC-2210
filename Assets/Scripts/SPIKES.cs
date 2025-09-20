using UnityEngine;

public class SPIKES : MonoBehaviour
{
    public GameObject myPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myPlayer = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spike")
        {
            Destroy(myPlayer);
            
        }
    }

}
