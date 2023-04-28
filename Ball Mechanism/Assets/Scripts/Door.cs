using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool isOpen = false;

    public void Open()
    {
        if (!isOpen)
        {
            animator.Play("DoorOpen");
            isOpen = true;
        }
    }

    public void Close()
    {
        if (isOpen)
        {
            animator.Play("DoorClose");
            isOpen = false;
        }
    }
}
