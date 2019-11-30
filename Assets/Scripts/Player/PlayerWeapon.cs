using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] static Weapon weapon;
    private void Awake()
    {
        weapon = new Weapon(-1, 0, 1, 0);
    }
    public void SetWeapon(Weapon wea)
    {
        weapon = wea;

    }
    public Weapon GetWeapon()
    {
        return weapon;

    }
    public int GetWeaponId()
    {
        return weapon.IDweapon;

    }
    public static int GetMyltiplaer()
    {
        if(weapon!=null)
        return weapon.myltiplaer;
        else
        {
            return 1;
        }

    }public int GetWeaponLevel()
    {
        if(weapon!=null)
        return weapon.weaponLevel;
        else
        {
            return 0;
        }

    }

}
