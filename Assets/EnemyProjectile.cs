using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Transform explosionPoint;
    public GameObject explosionEffect;
    public int damage = 25;
    protected Vector3 direction;
    public float speed = 1f;
    public float lifeTime = 3;
    // Start is called before the first frame update
    void Awake()
    {
        direction = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (direction.normalized * speed * Time.deltaTime);
        Destroy(gameObject, lifeTime);
    }

    public void Exploded()
    {
        GameObject go = Instantiate(explosionEffect);
        go.transform.position = explosionPoint.position;
    }

    public void Fire(Transform targetTransform)
    {
        direction = targetTransform.position - transform.position;
    }
}
