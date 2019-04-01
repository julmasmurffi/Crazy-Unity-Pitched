using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //config params

    //not of use for now unless we want to shoot
    //[SerializeField] float projectileSpeed = 10f;
    //[SerializeField] float projectileFiringPeriod = 1f;

    //TODO animator fot the player character
    [SerializeField] Collider2D punchHitBox;
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float padding = 0.3f;
    [SerializeField] float health;

    [SerializeField] float attackCd = 0.3f;
    private float attackTimer;
    private bool isAttacking = false;
   

    //Coroutine punchCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    public void Start()
    {
        SetUpMoveBoundaries();
        punchHitBox.enabled = false;
    }

    //gives the boundaries for the space ship
    public void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        MoveXY();
        Punch();


        //TODO firing coroutine
        Fire();
    }


    //TODO implement and test the method
    private void Punch()
    {
        if (Input.GetKeyDown("space") && !isAttacking)
        {
            isAttacking = true;
            attackTimer = attackCd;

            punchHitBox.enabled = true;
        }
        //TODO start a chain of punches

        if(isAttacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                punchHitBox.enabled = false;
            }
        }

    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //firingCoroutine = StartCoroutine(Firing());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            //StopCoroutine(firingCoroutine);
        }
    }

    //TODO implement a new firing method
    IEnumerator Firing()
    {
        while (true)
        {
            //GameObject laser = Instantiate(LaserPrefab, transform.position, Quaternion.identity) as GameObject;
            //TODO make a sound
            //laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            //yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    public void MoveXY()
    {
        //new position that we want to move to
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newxPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newyPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newxPos, newyPos);
    }
}
