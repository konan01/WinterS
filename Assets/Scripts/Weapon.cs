using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   public int IDweapon;
   public int weaponLevel;
   public int myltiplaer;
   public Int64 cost;

    public Weapon(int dweapon, int weaponLevel, int myltiplaer, Int64 cost)
    {
        IDweapon = dweapon;
        this.weaponLevel = weaponLevel;
        this.myltiplaer = myltiplaer;
        this.cost = cost;
    }
}
