using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    private bool isBeingCarried = false;
    public Transform player;
    private static bool isCarryingObject = false;
    private bool inInteractionRange = false; // Para saber si estamos cerca del objeto

    public GameObject correspondingDestination;

    void Update()
    {
        if (isBeingCarried)
        {
            // Hacer que el objeto siga al jugador
            transform.position = player.position + new Vector3(0, 1, 0); // Ejemplo: lo posiciona encima del jugador.
        }

        HandleActionInput();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCarryingObject)
        {
            player = collision.transform;
            inInteractionRange = true; // Marca que el jugador está en el rango de interacción
            Debug.Log("Jugador ha entrado en el área de interacción");
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Jugador ha salido del área de interacción");
            inInteractionRange = false; // Marca que el jugador ya no está en el rango de interacción

            // Si el jugador sale del área, solo dejará de seguir si no está siendo llevado
            if (!isBeingCarried)
            {
                player = null; // Reseteamos la referencia del jugador
            }
        }
    }
    void HandleActionInput()
    {
        if (Player.Instance.invertedControls)
        {
            if (inInteractionRange && Input.GetKeyDown(KeyCode.Q) && !isBeingCarried && !isCarryingObject)
            {
                PickObject();
            }
            if (isBeingCarried && Input.GetKeyDown(KeyCode.E))
            {
                DropObject();
            }
        }
        else
        {
            if (inInteractionRange && Input.GetKeyDown(KeyCode.E) && !isBeingCarried && !isCarryingObject)
            {
                PickObject();
            }
            if (isBeingCarried && Input.GetKeyDown(KeyCode.Q))
            {
                DropObject();
            }
        }
    }
    void PickObject()
    {
        isBeingCarried = true;
        isCarryingObject = true;
        Player.Instance.isBeingCarried = true;
        Player.Instance.carriedObject = gameObject;
    }

    void DropObject()
    {
        isBeingCarried = false;
        isCarryingObject = false;
        Player.Instance.isBeingCarried = false;
        Player.Instance.carriedObject = null;
    } 
}
