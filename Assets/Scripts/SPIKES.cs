using TMPro;
using UnityEngine;

public class SPIKES : MonoBehaviour
{
    public GameObject myPlayer;
    public AudioClip myClip;
    public gameManager myManager;
    public int destroyedMyPlayerCount = 0;
  

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
            
            destroyedMyPlayerCount += 1;

            if (destroyedMyPlayerCount == 3)
            {
                myManager.EndGame();
            }
            
        }
        
    }

}
