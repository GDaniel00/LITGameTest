using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalonT7Ammunition : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * weaponData.PowerShot;
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(weaponData.ActionDelay);

        Collider[] colliders = Physics.OverlapSphere(transform.position, weaponData.ActionRatio);

        foreach (var item in colliders)
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(weaponData.ActionForce * 10, transform.position, weaponData.ActionRatio);
            }
        }
        Destroy(gameObject);
    }
}
