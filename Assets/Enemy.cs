using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 80;
    public int health;
    public int score = 100;
    public GameObject healthbarPrefab;
    private GameObject healthbar;
    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
        healthbar = Instantiate(healthbarPrefab);
        healthbar.GetComponent<HealthbarBehaviour>().SetupHealthbar(health, maxHealth);
        healthbar.transform.SetParent(transform.parent.transform.Find("EnemyCanvas").transform);
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            health -= collision.transform.GetComponentInParent<Projectile>().damage;
            healthbar.GetComponent<HealthbarBehaviour>().SetupHealthbar(health, maxHealth);
            if (health <= 0)
            {
                Destroy(healthbar);
                Destroy(gameObject);
            }
            collision.transform.GetComponentInParent<Projectile>().Exploded();
            Destroy(collision.gameObject);
        }
    }
}
