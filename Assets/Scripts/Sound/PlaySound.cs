using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip[] m_AudioClip;

    public void PlaySoundOneShot()
    {
        m_AudioSource.pitch = Random.Range(1.0f, 2.0f);
        int randomIndex = Random.Range(0, m_AudioClip.Length);
        m_AudioSource.PlayOneShot(m_AudioClip[randomIndex]);
    }

}
