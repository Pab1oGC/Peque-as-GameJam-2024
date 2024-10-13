using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Debug.Log("eNTRO AL IF");
            Destroy(gameObject);
        }
    }

}
