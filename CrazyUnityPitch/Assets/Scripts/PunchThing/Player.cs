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
    [SerializeField] float health = 5f;

    [SerializeField] float attackCd = 0.3f;
    [SerializeField] private float attackTimer;
    [SerializeField] private bool isAttacking = false;
   
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


        //TODO firing coroutine for player ranged attacks
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
        //TODO anim set attacking to trigger animations?
    }

    //TODO implement and test the method
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

    //TODO check and validate method
    //checking for collisions on our player character
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO validate
        //TODO tag damaging items in editor
        if (collision.gameObject.CompareTag("damaging"))
        {
            DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
            HpCheck(damageDealer);
            //endtag damaging collision
        }

        //pickup object
        //compare tag is the best way to check for a certain type
        if (collision.gameObject.CompareTag("pickup"))
        {
            Debug.Log("pickup hidden");
            collision.gameObject.SetActive(false);

        }
    }

    //check if we have 0 hp and also deduct our hp when a trigger hits us
    private void HpCheck(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if(health <= 0)
        {
            //Destroy(gameObject);
            Debug.Log("ow, taking damage");
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
