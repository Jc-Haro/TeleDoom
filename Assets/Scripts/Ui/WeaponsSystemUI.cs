using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponsSystemUI : MonoBehaviour
{
    private float bullet;

    public Slider lifePlayer;

    public Slider shieldPlayer;

    public Image Image;

    public TextMeshProUGUI textMesh;

    private void Update()
    {
        textMesh.text = bullet.ToString("0");
    }
    public void BulletsUI(float Weapon)
    {
        bullet = Weapon;
    }

    public void IconUI(Sprite icon)
    {
        Image.sprite = icon;
    }

    public void MaxLifePlayer(float maxLife){
        lifePlayer.maxValue = maxLife;
        NewLifePlayer(maxLife);
    }

    public void NewLifePlayer(float newLife){
        lifePlayer.value = newLife;
    }

    public void MaxShieldPlayer(float maxShield){
        shieldPlayer.maxValue = maxShield;
        NewShieldPlayer(maxShield);
    }

    public void NewShieldPlayer(float newShield){
        shieldPlayer.value = newShield;
    }
}

    
