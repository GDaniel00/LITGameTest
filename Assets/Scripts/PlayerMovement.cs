using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed;
    [SerializeField] float backwardSpeed;
    public Weapon currWeapon;

    float finalSpeed;

    Vector3 movementAxisHorizontal;
    Vector3 movementAxisVertical;

    [SerializeField] Animator animator;
    private void Update()
    {
        transform.Translate(movementAxisVertical * Time.deltaTime);
        transform.Translate(movementAxisHorizontal * Time.deltaTime);

        if (Input.GetAxis("Vertical") == 0)
        {
            movementAxisHorizontal = new Vector3().normalized;
            movementAxisVertical = new Vector3().normalized;
            animator.SetFloat("movement", 0f);
        }
        else
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                movementAxisVertical = Vector3.forward * Input.GetAxis("Vertical") * finalSpeed;

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    finalSpeed = forwardSpeed * 2;
                    animator.SetFloat("movement", 0.6f);
                }
                else
                {
                    finalSpeed = forwardSpeed;
                    animator.SetFloat("movement", 0.3f);
                }
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                movementAxisVertical = Vector3.forward * Input.GetAxis("Vertical") * backwardSpeed;
                animator.SetFloat("movement", 1f);
            }
        }
        if (currWeapon != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                currWeapon.Shoot();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                currWeapon.LoadMagazineAmmo();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                currWeapon.ReloadTotalAmmoRemainig();
            }
        }
    }
}
