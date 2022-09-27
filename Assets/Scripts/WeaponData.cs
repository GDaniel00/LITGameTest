using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Weapon Data")]

public class WeaponData : ScriptableObject
{
    private enum StyleWeapon { Default, Rifle, Pistol }

    [Header("Weapon Info")]
    [SerializeField] string weaponName;
    [SerializeField] StyleWeapon weaponStyle;

    [Header("Weapon Characteristics")]
    [SerializeField] GameObject ammunitionType;
    [SerializeField] int ammoMagazineSize;
    [SerializeField] int totalAmmoSize;

    [Header("Current State")]
    [SerializeField] int remainigAmmoMagazine;
    [SerializeField] int totalAmmoRemaining;

    [Header("Ammunition Properties")]
    [SerializeField] float powerShot;
    [SerializeField] float actionRatio;
    [SerializeField] float actionForce;
    [SerializeField] float actionDelay;

    public string WeaponName { get => weaponName; set => weaponName = value; }
    private StyleWeapon WeaponStyle { get => weaponStyle; set => weaponStyle = value; }
    public GameObject AmmunitionType { get => ammunitionType; set => ammunitionType = value; }
    public int AmmoMagazineSize { get => ammoMagazineSize; set => ammoMagazineSize = value; }
    public int TotalAmmoSize { get => totalAmmoSize; set => totalAmmoSize = value; }
    public int RemainigAmmoMagazine { get => remainigAmmoMagazine; set => remainigAmmoMagazine = value; }
    public int TotalAmmoRemaining { get => totalAmmoRemaining; set => totalAmmoRemaining = value; }
    public float PowerShot { get => powerShot; set => powerShot = value; }
    public float ActionRatio { get => actionRatio; set => actionRatio = value; }
    public float ActionForce { get => actionForce; set => actionForce = value; }
    public float ActionDelay { get => actionDelay; set => actionDelay = value; }
}
