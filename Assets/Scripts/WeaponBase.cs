using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] List<Weapon> weapons;
    public List<TextMeshProUGUI> CostsWeapon;
    public GameObject[] tmp;
    PlayerWeapon playerWeapon;
    void Start()
    {

        //playerWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeapon>();

        FindCostWeapon();
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
        tmp = GameObject.FindGameObjectsWithTag("CostWeapon").OrderBy(c => c.GetHashCode()).ToArray();
        
        for (int i = 0; i < tmp.Length; i++)
        {
            CostsWeapon.Add(tmp[i].GetComponent<TextMeshProUGUI>());
            
        }
       
    }
    
    public void Buy(int index)
    {
        if (playerWeapon.GetWeapon() != weapons[index] && playerWeapon.GetWeaponId() < weapons[index].IDweapon)
        {
            print("Оружее стоит" + weapons[index].cost);
            if (ScoreManager.GetScore() >= weapons[index].cost)
            {
                playerWeapon.SetWeapon(weapons[index]);                    //что мы делаем
                ScoreManager.AddScore(-weapons[index].cost);            //вычитаем стоимость из очков
                print("Вы купили= " + weapons[index].name);                                                       //увеличиваем стоимость
            }
        }
        else print("У вас такое же оружее");
      
    }
}
