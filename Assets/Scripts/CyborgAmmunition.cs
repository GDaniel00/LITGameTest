using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyborgAmmunition : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * weaponData.PowerShot;
        StartCoroutine(DestroyObj());
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
}
