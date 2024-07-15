using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnAble : PlaySound
{
    private void OnEnable()
    {
        PlaySoundOneShot();
    }
}
