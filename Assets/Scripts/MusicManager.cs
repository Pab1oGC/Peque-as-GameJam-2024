using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource; // El único AudioSource que reproducirá la música.
    public AudioClip[] musicClips; // Lista de canciones.
    public float timeBetweenSongs = 30f; // Tiempo (en segundos) para cambiar de canción.

    private int currentClipIndex = 0; // El índice de la canción actual.
    private float timer = 0f; // Temporizador para controlar el cambio de canción.

    void Start()
    {
        if (musicClips.Length > 0)
        {
            PlayMusicClip(currentClipIndex); // Iniciar la primera canción.
        }
    }

    void Update()
    {
        // Aumentar el temporizador.
        timer += Time.deltaTime;

        // Si ha pasado el tiempo especificado, cambiar de canción.
        if (timer >= timeBetweenSongs)
        {
            ChangeToNextSong();
            timer = 0f; // Reiniciar el temporizador.
        }
    }

    void PlayMusicClip(int index)
    {
        musicSource.clip = musicClips[index]; // Asignar la canción actual.
        musicSource.Play(); // Reproducir la canción.
    }

    void ChangeToNextSong()
    {
        currentClipIndex++; // Ir a la siguiente canción.

        // Volver al principio si es necesario.
        if (currentClipIndex >= musicClips.Length)
        {
            currentClipIndex = 0;
        }

        PlayMusicClip(currentClipIndex); // Reproducir la nueva canción.
    }
}

