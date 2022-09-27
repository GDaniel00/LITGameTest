using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolLazerAmmunition : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;

    [SerializeField] float rotationSpeed;
    [SerializeField] float minDistance;
    [SerializeField] float atractionTime;
    [SerializeField] Rigidbody rb;
    public Collider[] colliders;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * weaponData.PowerShot;
        StartCoroutine(DestroyBullet());
    }

    void Update()
    {
        foreach (var item in colliders)
        {
            if (item.CompareTag("Object"))
            {
                if (item.GetComponent<Rigidbody>())
                {
                    item.GetComponent<Rigidbody>().isKinematic = true;
                }
                if (item.transform.parent != transform)
                {
                    item.transform.SetParent(transform);
                }
                item.transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
                float distance = Vector3.Distance(transform.position, new Vector3(item.transform.position.x, transform.position.y,
                        transform.position.z));
                if (distance > minDistance)
                {
                    item.transform.position = Vector3.Lerp(item.transform.position, new Vector3(transform.position.x, item.transform.position.y,
                        item.transform.position.z), atractionTime * Time.deltaTime);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        colliders = Physics.OverlapSphere(transform.position, weaponData.ActionRatio);
    }
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(weaponData.ActionDelay);
        foreach (var item in colliders)
        {
            if (item.CompareTag("Object"))
            {
                item.transform.SetParent(null);
                if (item.GetComponent<Rigidbody>())
                {
                    item.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, weaponData.ActionRatio);
    }
}
