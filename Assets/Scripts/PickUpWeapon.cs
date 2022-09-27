using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    public Transform positionHand;
    public Animator animator;
    public GameObject msPickUp;
    public GameObject msDrop;

    public bool isTrigger = false;
    public bool isPickup = false;
    public int codeWeapon;

    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }
    private void Update()
    {
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E) && playerMovement.currWeapon == null)
            {
                isPickup = true;
                gameObject.transform.SetParent(positionHand);
                transform.localPosition = new Vector3(0, 0, 0);
                transform.localRotation = Quaternion.identity;
                GetComponent<Rigidbody>().isKinematic = true;
                GameObject.FindObjectOfType<PlayerMovement>().currWeapon = GetComponent<Weapon>();
                msPickUp.SetActive(false);
                msDrop.SetActive(true);

                animator.SetInteger("codeWeapon", codeWeapon);
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            gameObject.transform.SetParent(null);
            GetComponent<Rigidbody>().isKinematic = false;
            GameObject.FindObjectOfType<PlayerMovement>().currWeapon = null;
            isPickup = false;
            msDrop.SetActive(false);
            animator.SetInteger("codeWeapon", 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPickup && playerMovement.currWeapon == null)
        {
            isTrigger = true;
            msPickUp.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isPickup && playerMovement.currWeapon == null)
        {
            isTrigger = false;
            msPickUp.SetActive(false);
        }
    }
}
