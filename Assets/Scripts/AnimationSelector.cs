using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationSelector : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void ChangeDance(int codeAnim)
    {
        switch (codeAnim)
        {
            default:
                Debug.LogError("No se a encontrado animacion");
                break;
            case 0:
                animator.Play("HouseDancing");
                break;
            case 1:
                animator.Play("MacarenaDance");
                break;
            case 2:
                animator.Play("WaveHipHopDance");
                break;
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
