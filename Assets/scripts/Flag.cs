using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public AudioClip Collected;
    AudioSource playerAudio;
    public GameObject Checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Will Destroy and add flag number in the text and playing collecting sound
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            playerAudio.PlayOneShot(Collected);
            other.gameObject.GetComponent<Move>().Flags += 1;
            Checkpoint.GetComponent<Renderer>().material.color = Color.green;
            Destroy(this.gameObject);
        }
    }
}
