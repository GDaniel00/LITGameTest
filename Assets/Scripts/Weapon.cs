using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    [SerializeField] GameObject shotSpawnPoint;
    [SerializeField] GameController gameController;

    private void Start()
    {
        InitializedWeapon();
    }
    public void InitializedWeapon()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        weaponData.RemainigAmmoMagazine = weaponData.AmmoMagazineSize;
        weaponData.TotalAmmoRemaining = weaponData.TotalAmmoSize;
    }

    public void Shoot()
    {
        if (weaponData.RemainigAmmoMagazine > 0)
        {
            GameObject shot = Instantiate(weaponData.AmmunitionType, shotSpawnPoint.transform.position, shotSpawnPoint.transform.rotation);
            SubtractAmmo();
        }
    }
    public void SubtractAmmo()
    {
        weaponData.RemainigAmmoMagazine--;
        if (weaponData.RemainigAmmoMagazine == 0)
        {
            gameController.ShowMessageLoadMagazine();
        }
    }
    public void LoadMagazineAmmo()
    {
        if (weaponData.RemainigAmmoMagazine < weaponData.AmmoMagazineSize && weaponData.TotalAmmoRemaining > 0)
        {
            int subtractTotalMagazine = weaponData.AmmoMagazineSize - weaponData.RemainigAmmoMagazine;
            if (subtractTotalMagazine <= weaponData.TotalAmmoRemaining)
            {
                weaponData.TotalAmmoRemaining -= subtractTotalMagazine;
                weaponData.RemainigAmmoMagazine = weaponData.AmmoMagazineSize;
            }
            else
            {
                weaponData.RemainigAmmoMagazine += weaponData.TotalAmmoRemaining;
                weaponData.TotalAmmoRemaining = 0;
            }
        }
        else if (weaponData.TotalAmmoRemaining == 0)
        {
            gameController.ShowMessageLoadAmmunicion();
        }
    }

    public void ReloadTotalAmmoRemainig()
    {
        if (weaponData.TotalAmmoRemaining == 0)
        {
            weaponData.TotalAmmoRemaining = weaponData.TotalAmmoSize;
            weaponData.RemainigAmmoMagazine = weaponData.AmmoMagazineSize;
        }
    }
}
