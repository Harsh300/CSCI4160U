using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFinish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject hitObj = collider.gameObject;
        if (hitObj.tag == "Player")
        {
            Application.LoadLevel(2);
        }
    }
}
