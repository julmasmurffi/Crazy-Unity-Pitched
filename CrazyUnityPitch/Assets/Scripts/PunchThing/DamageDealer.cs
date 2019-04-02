using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    //conf params
    [SerializeField] int damage = 1;

    //methods
    public int GetDamage() { return damage; }

    public void Hit() { Destroy(gameObject); }
}
