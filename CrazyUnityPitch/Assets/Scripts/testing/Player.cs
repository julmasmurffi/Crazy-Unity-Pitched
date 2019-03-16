using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MovingObj
{

    private int hp;

    // Start is called before the first frame update
    protected override void Start()
    {
        //call the base class Start method
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //game managing methods
    private void CheckIfZeroHp()
    {
        if (hp <= 0)
        {
            GameManager.instance.GameOver();
        }
    }


    //moving methods, moving is now in xy coordinates
    protected override void AttemptMove<T>(int xDir, int yDir)
    {

        base.AttemptMove<T>(xDir, yDir);

        RaycastHit2D hit;
    }

    protected override void OnCantMove<T>(T component)
    {
        //what to do when we can not move at all
        throw new System.NotImplementedException();
    }

    //utility methods that take care of various tasks
    private void Restart()
    {
        //what level to load after restart
        SceneManager.LoadScene(0);
    }

    
}
