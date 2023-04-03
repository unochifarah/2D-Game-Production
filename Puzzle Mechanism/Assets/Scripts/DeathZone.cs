using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    //public GameObject PointCounter;
    //public float points;
    public string beastType;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(beastType))
        {
            Destroy(collider.gameObject);
            //PoCo.GetComponent<PointsController>().AddPoints(points);
        }
    }
}