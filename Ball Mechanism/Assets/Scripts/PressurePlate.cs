using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private List<Door> doorsToControl = new List<Door>();

    private int ballCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            ballCount++;
            if (ballCount == 1)
            {
                OpenDoors();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            ballCount--;
            if (ballCount == 0)
            {
                CloseDoors();
            }
        }
    }

    private void OpenDoors()
    {
        foreach (Door door in doorsToControl)
        {
            door.Open();
        }
    }

    private void CloseDoors()
    {
        foreach (Door door in doorsToControl)
        {
            door.Close();
        }
    }
}
