using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Photon.Pun;

public class WeaponBase : MonoBehaviourPunCallbacks
{
    public List<Weapon> weapons;
    public List<TextMeshProUGUI> CostsWeapon;
    public GameObject[] tmp;
    public PlayerInfo playerInfo;
    void Start()
    {
        FindCostWeapon();
        weapons = new List<Weapon>();
        weapons.Add(new Weapon(0,1,2,200));
        weapons.Add(new Weapon(1,1,4,840));
        weapons.Add(new Weapon(2,1,6,4200));
        weapons.Add(new Weapon(3,2,8,8500));
        weapons.Add(new Weapon(4,2,10,16845));
        weapons.Add(new Weapon(4,2,12,18845));
        weapons.Add(new Weapon(4,3,14,19845));
        weapons.Add(new Weapon(4,3,16,20000));
    }

    private void FixedUpdate()
    {
        UpdateCostWeapon();
    }
    private void UpdateCostWeapon()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            CostsWeapon[i].text = weapons[i].cost.ToString();
        }
    }
    private void FindCostWeapon()
    {
        tmp = GameObject.FindGameObjectsWithTag("CostWeapon");
        tmp = tmp
            .OrderBy(c=> c.GetComponent<CostID>().ID)
            .ToArray();
        for (int i = 0; i < tmp.Length-1; i++)
        {
            if (tmp[i].GetComponent<CostID>().ID == tmp[i + 1].GetComponent<CostID>().ID)
            { Debug.LogError("Error duplicate ID found. Please check if the ID on CostID script in Upgrade_Panel, Store_Panel, Costs is correct"); break; }
        }
        for (int i = 0; i < tmp.Length; i++)
        {
            CostsWeapon.Add(tmp[i].GetComponent<TextMeshProUGUI>());
        }
        tmp = null;
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
    }
    public override void OnJoinedRoom()
    {
        
    }
    public void Buy(int index)
    {
        print(playerInfo.GetWeaponId());
        if(index <= weapons.Count)
        if (playerInfo.GetWeapon() != weapons[index] && playerInfo.GetWeaponId() < weapons[index].IDweapon)
        {
            print(ScoreManager.GetScore());
            if (ScoreManager.GetScore() >= weapons[index].cost)
            {
                playerInfo.SetWeapon(weapons[index]); print("Купленно");                //что мы делаем
                ScoreManager.AddScore(-weapons[index].cost);             //вычитаем стоимость из очков
                                                                      
            }
        }
        else print("У вас такое же оружее");
      
    }
}
