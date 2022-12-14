using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health;
    public float timeBtwFiring;
    public ParticleSystem muzzleFlash;

    public Transform aim;
    public Transform player;
    public float range = 100f;

    bool inRange;

    AudioSource enemySound;
    public AudioClip GunShot;

    public GameObject HeartLive;

    public GameObject Explosin;
    public GameObject projectile;
    
    public GameObject scorePopup;

    //Taking Damage when bullet hits    
    public void TakeDamage (float amount)
    {
        scorePopup.GetComponent<Text>().text = "" + Random.Range(50, 70);
        scorePopup.GetComponent<Animator>().SetTrigger("popup");
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

// Dying Function
    void Die()
    {
        Instantiate(Explosin, transform.position, Quaternion.identity);
        int Heart = Random.Range(-2,2);
        if(Heart <= 0){
        Instantiate(HeartLive, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    
// Shooting functions
    void Shoot()
    {
        Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), transform.rotation);

        muzzleFlash.Play();
        enemySound.PlayOneShot(GunShot);
    }

    void Start()
    {
        enemySound = GetComponent<AudioSource>();
        if(PlayerPrefs.GetInt("ToolTips")==0){
            enemySound.enabled = false;
        }

        Check();
        
        //Checking Difficulty from data 
        if(GameObject.Find("Data").GetComponent<Data>().medium == true)
        {
            health = 100f;
            timeBtwFiring = 2f;

        }else if(GameObject.Find("Data").GetComponent<Data>().hard == true)
        {
            health = 200f;
            timeBtwFiring = 1f;
        }else{
            
            health = 50f;
            timeBtwFiring = 3f;
        }
    }


    void Update()
    {
        //Facing At player
        aim.LookAt(player);

        Vector3 targetPostition = new Vector3( player.position.x, 
                                        this.transform.position.y, 
                                        player.position.z ) ;
 this.transform.LookAt( targetPostition ) ;


    }

// Checking if player is in shooting range or not before shooting
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
