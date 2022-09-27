using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject msLoadMagazine;
    [SerializeField] GameObject msLoadAmmunicion;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ShowMessageLoadMagazine()
    {
        msLoadMagazine.SetActive(true);
        StartCoroutine(HideMessageLoadMagazine());
    }
    IEnumerator HideMessageLoadMagazine()
    {
        yield return new WaitForSeconds(3);
        msLoadMagazine.SetActive(false);
    }

    public void ShowMessageLoadAmmunicion()
    {
        msLoadAmmunicion.SetActive(true);
        StartCoroutine(HideMessageLoadAmmunition());
    }
    IEnumerator HideMessageLoadAmmunition()
    {
        if (msLoadMagazine)
        {
            msLoadMagazine.SetActive(false);
        }
        yield return new WaitForSeconds(3);
        msLoadAmmunicion.SetActive(false);
    }
}
