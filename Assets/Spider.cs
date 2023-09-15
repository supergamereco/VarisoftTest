using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    public Vector3 startingPoint;
    public Vector3 endingPoint;
    public float moveSpeed;
    private bool startMove = true;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = startingPoint;
        moveDirection = endingPoint - startingPoint;
    }

    private void FixedUpdate()
    {
        //Movement Patrol
        if (!startMove && transform.localPosition.x < startingPoint.x && transform.localPosition.y < startingPoint.y)
        {
            startMove = !startMove;
            moveDirection = endingPoint - startingPoint;
        }
        else if(startMove && transform.localPosition.x >= endingPoint.x && transform.localPosition.y >= endingPoint.y)
        {
            startMove = !startMove;
            moveDirection = startingPoint - endingPoint;
        }
        this.transform.localPosition += moveDirection.normalized * moveSpeed * Time.deltaTime;
    }
}
