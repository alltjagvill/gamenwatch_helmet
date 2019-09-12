using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public List<AudioClip> sounds = new List<AudioClip>();

    public AudioClip onClearSound;
    public AudioClip onHitSound;
    public AudioClip gameOverSound;

    private AudioClip moveSound;

    private int soundListNumber;

    AudioSource audioSource;

    void OnEnable()
    {
        GameManager.OnGameOver += PlayGameOverSound;
        ToolsController.OnHelmetKill += PlayHitSound;
    }

    void OnDisable()
    {
        GameManager.OnGameOver -= PlayGameOverSound;
        ToolsController.OnHelmetKill -= PlayHitSound;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMoveSound()
    {
        soundListNumber = Random.Range(0, sounds.Count);

        moveSound = sounds[soundListNumber];
        audioSource.clip = moveSound;
        audioSource.Play();
    }

    public void PlayClearSound()
    {
        audioSource.clip = onClearSound;
        audioSource.Play();
    }

    private void PlayHitSound()
    {
        audioSource.clip = onHitSound;
        audioSource.Play();
    }

    private void PlayGameOverSound()
    {
        audioSource.clip = gameOverSound;
        audioSource.Play();
    }
}
