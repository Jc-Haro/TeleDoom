using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnAble : PlaySound
{
    private void OnEnable()
    {
        PlaySoundOneShot();
    }
}
