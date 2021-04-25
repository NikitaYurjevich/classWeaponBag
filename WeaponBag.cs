/*
 *   Принцип смены оружия: префабы не создаются/удаляются, а 
 *   лежат в руке изначально, но они скрыты.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBag : MonoBehaviour
{   
    // Здесь мы указываем объектам ссылки на префабы оружий и пустых объектов
    void Awake()
    {
        WeaponSlots[0].GoWeapon = Rifle;
        WeaponSlots[1].GoWeapon = Pistol;
        WeaponSlots[2].GoWeapon = Knife;

        WeaponSlots[0].shootPlace = rifleShootPoint;
        WeaponSlots[1].shootPlace = pistolShootPoint;
    }

    public Weapon[] WeaponSlots = {
        new Weapon("Автомат", 10f, WeaponType.Rifle, 30, 30, 120, 0.1f),
        new Weapon("Пистолет", 20f, WeaponType.Pistol, 12, 12, 40, 0.5f),
        new Weapon("Нож", 50f, WeaponType.Knife, 0,0,0, 1f)
    };

    public int CurrentWeapon = 2;
    public GameObject Knife;  // Ссылки на префабы оружий 
    public GameObject Pistol; //
    public GameObject Rifle;  //
    public Transform rifleShootPoint;  // Ссылки на пустые объекты(у каждого оружия - свой)
    public Transform pistolShootPoint; // Нужны для создания эффекта выстрела у дула

    //Этот метод, как мне кажется, стал более читаемым + стал короче
    public void SwitchWeapon(int weaponNum)
    {      
        if( weaponNum != CurrentWeapon)
        {
        WeaponSlots[CurrentWeapon].GoWeapon.SetActive(false); // Скрываем одно оружие
        WeaponSlots[weaponNum].GoWeapon.SetActive(true);      // Достаем другое

        CurrentWeapon = weaponNum;
        }
    }
}
public class Weapon
{
    public string Name;
    public float Damage;
    public WeaponType WType;
    public int Magazine;
    public int MaxMagazine;   
    public int AllAmmo;
    public float AttackSpeed;

    public GameObject GoWeapon;  // Каждый экземпляр класса будет ссылаться на свой префаб
    public Transform shootPlace; // У каждого экземпляра своя точка для создания эффекта выстрела(у дула)


    public Weapon(string name, float damage, WeaponType wtype, int magazine, int maxMagazine, int allAmmo, float attackSpeed)
    {
        this.Name = name;
        this.Damage = damage;
        this.WType = wtype;
        this.Magazine = magazine;
        this.MaxMagazine = maxMagazine;
        this.AllAmmo = allAmmo;
        this.AttackSpeed = attackSpeed;
    }
}

public enum WeaponType
{
    Knife,
    Pistol,
    Rifle
}
