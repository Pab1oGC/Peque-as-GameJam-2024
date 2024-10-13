using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    public enum GameMode
    {
        Normal,
        InvertedControls,
        SelfDamage
    }

    public static GameMode currentMode = GameMode.Normal;
    private bool firstMode = true;

    private void Start()
    {
        InvokeRepeating("ChangeGameMode", 0, 10f); // Cambia el modo cada 10 segundos
    }

    private void ChangeGameMode()
    {
        currentMode = (GameMode)Random.Range(0, System.Enum.GetValues(typeof(GameMode)).Length);
        if (firstMode)
        {
            currentMode = GameMode.Normal;
            firstMode = false;
        }
        Debug.Log("Modo de juego cambiado a: " + currentMode);
    }
}
