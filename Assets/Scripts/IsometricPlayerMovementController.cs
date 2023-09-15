using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IsometricPlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;
    PlayerInput playerInput;
    public GameObject[] AttackProjectiles;
    private Vector2 playerDirection;
    public int maxHealth = 80;
    public int health;

    Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        playerInput = GetComponent<PlayerInput>();
        playerDirection = new Vector2(0, 1);
        health = maxHealth;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;
        Vector2 input = playerInput.actions["Movement"].ReadValue<Vector2>();
        Vector2 inputVector = new Vector2(input.x, input.y);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        if (inputVector != Vector2.zero)
        {
            playerDirection = inputVector;
        }
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
    }

    public void Attack()
    {
        GameObject go = Instantiate(AttackProjectiles[0]);
        go.transform.position = transform.position;
        go.GetComponent<Projectile>().Initialization(playerDirection);
        Debug.Log(transform.eulerAngles);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
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
