using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    public float moveSpeed;
    private Transform target;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.parent.transform.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        direction = target.position - transform.position;
        transform.position += (direction.normalized * moveSpeed * Time.deltaTime);
    }
}
