using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public GameObject gift;
    private void Start()
    {

    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gift == Player.Instance.carriedObject && Player.Instance.isBeingCarried)
        {
            Debug.Log("Destino correcto");
        }
    }
}
