using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }   

    public void MenuUp()
    {
        animator.SetTrigger("Up");
    }

    public void MenuDown()
    {
        animator.SetTrigger("Down");
    }
}
