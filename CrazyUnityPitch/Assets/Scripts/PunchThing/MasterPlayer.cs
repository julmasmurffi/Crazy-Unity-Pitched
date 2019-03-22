using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterPlayer
{
    public MasterPlayer()
    {
        Debug.Log("Master Player Called");
    }

    //config params to help with the ruleset
    [SerializeField] public float moveSpeed = 10f;
    [SerializeField] public float padding = 0.3f;
    [SerializeField] public float punchPeriod;

    //add these to a global conf param list?
   

    // Start is called before the first frame update
    public virtual void Start()
    {
        SetupMoveBoundaries();
    }


    //methods to override in the base classes
    public virtual void SetupMoveBoundaries()
    {
        
    }

    public virtual IEnumerator Punching()
    {
        yield return new WaitForSeconds(punchPeriod);    
    }

    public virtual void MoveXY()
    {
        //new position that we want to move to
        //implement a rule for the ai to get a new position
    }

    
}
