using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBook : Enemy
{
    private Transform target;
    public float detectRadius = 20;
    public GameObject AttackProjectiles;
    public float attackInterval = 1.5f;
    public float attackCoolDown;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.parent.transform.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target.position.x < transform.position.x + detectRadius && target.position.y < transform.position.y + detectRadius)
        {
            //Debug.Log("In Radius!");
            if (attackCoolDown > attackInterval)
                attackCoolDown = 0;
            if (attackCoolDown == 0)
                Attack();
            attackCoolDown += Time.deltaTime;
        }
    }

    public void Attack()
    {
        GameObject go = Instantiate(AttackProjectiles);
        go.transform.position = transform.position;
        go.GetComponent<EnemyProjectile>().Fire(target);
    }
}
