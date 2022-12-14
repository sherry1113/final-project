using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCollector : MonoBehaviour
{
    public GameObject DoubleEnemies;
    public GameObject TripleEnemies;

    public AudioSource playerAudio, demoSoldier, BGmusic;

    // Start is called before the first frame update
    void Start()
    {
        //Collecting info about difficulty of level from data Script and increasing the difficulty
        if(GameObject.Find("Data").GetComponent<Data>().medium == true)
        {
            DoubleEnemies.SetActive(true);
            GameObject.FindWithTag("enemy").GetComponent<Enemy>().health = 100f;
            GameObject.FindWithTag("enemy").GetComponent<Enemy>().timeBtwFiring = 2f;

        }else if(GameObject.Find("Data").GetComponent<Data>().hard == true)
        {
            DoubleEnemies.SetActive(true);
            TripleEnemies.SetActive(true);
            GameObject.FindWithTag("enemy").GetComponent<Enemy>().health = 200f;
            GameObject.FindWithTag("enemy").GetComponent<Enemy>().timeBtwFiring = 1f;
        }else{
            
            GameObject.FindWithTag("enemy").GetComponent<Enemy>().health = 50f;
            GameObject.FindWithTag("enemy").GetComponent<Enemy>().timeBtwFiring = 3f;
        }


        //Collecting info about sounds of game
        if(PlayerPrefs.GetInt("ToolTips")==0){
            playerAudio.enabled=false;
            demoSoldier.enabled=false;
        }
        BGmusic.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
