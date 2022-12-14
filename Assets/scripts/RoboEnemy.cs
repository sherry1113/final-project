using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoboEnemy : MonoBehaviour
{
    public float health;
    public float timeBtwFiring;
    public ParticleSystem muzzleFlash;
    public ParticleSystem muzzleFlash2;

    public GameObject Explosin;
    public GameObject projectile;
    public GameObject Laser;

    public GameObject scorePopup;
    public Transform aim;
    public Transform player;

    AudioSource enemySound;
    public AudioClip GunShot;
    public float range = 100f;

    public Transform firePoint1;
    public Transform firePoint2;
    public Transform LaserPoint;
    
    public void TakeDamage (float amount)
    {
        // Firing Laser On these health
        if(health == 400f)
        {
            Instantiate(Laser, LaserPoint.position,  transform.rotation);
        }
        if(health == 300)
        {
            Instantiate(Laser, LaserPoint.position,   transform.rotation);
        }
        if(health == 200)
        {
            Instantiate(Laser, LaserPoint.position,   transform.rotation);
        }
        if(health == 100f)
        {
            Instantiate(Laser, LaserPoint.position, transform.rotation);
        }

        // Score popup when get hit by player
        scorePopup.GetComponent<Text>().text = "" + Random.Range(50, 70);
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

   //Dying Script Of Boss
    void Die()
    {
        Instantiate(Explosin, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    
//Shooting Script of Boss
    void Shoot()
    {
        Instantiate(projectile, firePoint1.position, transform.rotation);
        Instantiate(projectile, firePoint2.position, transform.rotation);

        muzzleFlash.Play();
        muzzleFlash2.Play();
        enemySound.PlayOneShot(GunShot);
    }

    void Start()
    {
        enemySound = GetComponent<AudioSource>();
        //Checking if sound is on or Of
        if(PlayerPrefs.GetInt("ToolTips")==0){
            enemySound.enabled = false;
        }

        Check();
    }

    void Update()
    {
        //looking At Player
        aim.LookAt(player);

        Vector3 targetPostition = new Vector3( player.position.x, 
                                        this.transform.position.y, 
                                        player.position.z ) ;
        this.transform.LookAt( targetPostition ) ;


    }

// Checking if player is in range of shooting or not
    void Check()
    {
        
        RaycastHit hit;
        if(Physics.Raycast(aim.position, aim.forward, out hit, range) && hit.collider.gameObject.tag == "Player")
        {
            Shoot();
            
        }
        Invoke("Check", timeBtwFiring);

    }

}
