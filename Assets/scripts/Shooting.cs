using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public Camera cam;
    public AudioClip GunShot;
    public AudioSource SoldierDemo;

    public ParticleSystem muzzleFlash;

    public GameObject sparkEffect;

    private float nextTimeToFire = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            Shoot();
        }
    }

    //Shooting of player
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            RoboEnemy BossEnemy = hit.transform.GetComponent<RoboEnemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
                Instantiate(sparkEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
            if(BossEnemy != null)
            {
                BossEnemy.TakeDamage(damage);
                Instantiate(sparkEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }

        muzzleFlash.Play();
        SoldierDemo.PlayOneShot(GunShot);
    }
}
