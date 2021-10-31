using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.Signals;
using UnityEngine;
using Zenject;

public class CharController : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip[] clips;
    private Animator _animator;
    private AudioSource _audioSource;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        Appear();
    }

    public void Appear() => _animator.SetTrigger("Appear");
    public void GetPrize() => _animator.SetTrigger("Prize");
    
    public void PlaySoundOnAnim(int soundIndex) => _audioSource.PlayOneShot(clips[soundIndex]);

    public void Interact()
    {
        GetPrize();
    }
}
