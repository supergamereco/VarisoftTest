using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform explosionPoint;
    public GameObject explosionEffect;
    public int damage = 25;
    protected Vector3 direction;
    public float speed = 2.4f;
    public float lifeTime = 3;
    // Start is called before the first frame update
    void Awake()
    {
        direction = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (direction * speed * Time.deltaTime);
        Destroy(gameObject, lifeTime);
    }

    public void Initialization(Vector2 playerDirection)
    {
        direction = new Vector3(playerDirection.x, playerDirection.y);
        // Convert input direction to a rotation
        if (playerDirection != Vector2.zero)
        {
            float angle = (Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg) + 90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.GetChild(0).transform.rotation = rotation;
        }
    }

    public void Exploded()
    {
        GameObject go = Instantiate(explosionEffect);
        go.transform.position = explosionPoint.position;
    }
}
