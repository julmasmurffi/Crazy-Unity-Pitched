using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MasterPlayer
{
    //config params
    
    
    //[SerializeField] float projectileSpeed = 10f;
    //[SerializeField] float projectileFiringPeriod = 1f;

    //Coroutine firingCoroutine;

    float xMin;
    float xMax;

    float yMin;
    float yMax;

    // Start is called before the first frame update
    override public void Start()
    {
        //TODO move this to a game manager object for better code manageability
        //TODO create boundaries for the player
        SetUpMoveBoundaries();

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
        Fire();
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

    public override void MoveXY()
    {
        //new position that we want to move to
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newxPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newyPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        //TODO new position finding
        //transform.position = new Vector2(newxPos, newyPos);
    }
}
