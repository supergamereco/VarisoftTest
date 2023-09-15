using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 80;
    public int health;
    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            Debug.Log("Attacked!!");
            health -= collision.transform.GetComponentInParent<EnemyProjectile>().damage;
            //healthbar.GetComponent<HealthbarBehaviour>().SetupHealthbar(health, maxHealth);
            if (health <= 0)
            {

            }
            collision.transform.GetComponentInParent<EnemyProjectile>().Exploded();
            Destroy(collision.gameObject);
        }
    }
}
