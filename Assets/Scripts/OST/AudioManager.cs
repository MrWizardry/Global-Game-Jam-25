using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip[] backgound;
    public AudioClip death;
    public AudioClip hurt;
    public AudioClip ButtonSound;
    public AudioClip Bird_Attack;
    public AudioClip Warning;
    public AudioClip Soap;
    public AudioClip startSound;

    private int currentBackgroundIndex = 0;
    [SerializeField] private float fadeDuration = 1.0f;
    private float maxMusicVolume = 1.0f; // Volume máximo ajustado pelo jogador

    void Start()
    {
        // Obtém o volume inicial da música configurado no PlayerPrefs
        maxMusicVolume = PlayerPrefs.GetFloat("Music", 1.0f);
        musicSource.volume = maxMusicVolume;

        if (backgound.Length > 0)
        {
            musicSource.clip = backgound[currentBackgroundIndex];
            musicSource.Play();
            StartCoroutine(PlayBackgroundMusicLoopWithFade());
        }
        else
        {
            Debug.LogWarning("Nenhum áudio encontrado na lista de background!");
        }
    }

    IEnumerator PlayBackgroundMusicLoopWithFade()
    {
        while (true)
        {
            // Aguarda até que a música atual termine menos o tempo do fade
            yield return new WaitForSeconds(musicSource.clip.length - fadeDuration);

            // Inicia o fade out
            yield return StartCoroutine(FadeOut());

            // Incrementa o índice para o próximo clip
            currentBackgroundIndex = (currentBackgroundIndex + 1) % backgound.Length;

            // Atualiza o clip
            musicSource.clip = backgound[currentBackgroundIndex];
            musicSource.Play();

            // Inicia o fade in
            yield return StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeOut()
    {
        float startVolume = musicSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        musicSource.volume = 0;
    }

    IEnumerator FadeIn()
    {
        float startVolume = 0;
        musicSource.volume = startVolume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(startVolume, maxMusicVolume, t / fadeDuration);
            yield return null;
        }

        musicSource.volume = maxMusicVolume;
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    // Método para atualizar o volume da música quando o jogador altera o slider
    public void UpdateMusicVolume(float volume)
    {
        maxMusicVolume = volume;
        musicSource.volume = maxMusicVolume; // Atualiza o volume atual
    }
}
