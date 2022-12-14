using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    public float speed = 10f;

    public bool isLaser;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //bullet will Facing at player
        gameObject.transform.LookAt(GameObject.Find("Player Head").transform);
        
        // Bullet moving forward
        bulletRigidbody.velocity = transform.forward * speed;
        Invoke("DestroyLaser", 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //On hitting Player
        Move player = other.gameObject.GetComponent<Move>();
        if(player != null)
            {

                if(isLaser == true){
                player.LaserDamage();}

                else{
                player.TakeDamage();}
            }
            
        if(other.tag != "enemy" && isLaser == false)
        Destroy(gameObject);
    }
    void DestroyLaser()
    {
    Destroy(gameObject);
    }
}
