using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource; // El �nico AudioSource que reproducir� la m�sica.
    public AudioClip[] musicClips; // Lista de canciones.
    public float timeBetweenSongs = 30f; // Tiempo (en segundos) para cambiar de canci�n.

    private int currentClipIndex = 0; // El �ndice de la canci�n actual.
    private float timer = 0f; // Temporizador para controlar el cambio de canci�n.

    void Start()
    {
        if (musicClips.Length > 0)
        {
            PlayMusicClip(currentClipIndex); // Iniciar la primera canci�n.
        }
    }

    void Update()
    {
        // Aumentar el temporizador.
        timer += Time.deltaTime;

        // Si ha pasado el tiempo especificado, cambiar de canci�n.
        if (timer >= timeBetweenSongs)
        {
            ChangeToNextSong();
            timer = 0f; // Reiniciar el temporizador.
        }
    }

    void PlayMusicClip(int index)
    {
        musicSource.clip = musicClips[index]; // Asignar la canci�n actual.
        musicSource.Play(); // Reproducir la canci�n.
    }

    void ChangeToNextSong()
    {
        currentClipIndex++; // Ir a la siguiente canci�n.

        // Volver al principio si es necesario.
        if (currentClipIndex >= musicClips.Length)
        {
            currentClipIndex = 0;
        }

        PlayMusicClip(currentClipIndex); // Reproducir la nueva canci�n.
    }
}

