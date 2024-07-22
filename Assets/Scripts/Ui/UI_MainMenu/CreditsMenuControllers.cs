using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenuControllers : MonoBehaviour
{

    public GameObject ProB1;
    public GameObject ProB2;
    public GameObject ProB3;
    public GameObject ProB4;
    public GameObject ProB5;
    public GameObject ProB6;
    public GameObject ProB7;
    public GameObject ProB8;

    public void ProfileOnOff(GameObject P1, GameObject P2, GameObject P3, GameObject P4,
    GameObject P5, GameObject P6, GameObject P7, GameObject P8){
        P1.SetActive(true);
        P2.SetActive(false);
        P3.SetActive(false);
        P4.SetActive(false);
        P5.SetActive(false);
        P6.SetActive(false);
        P7.SetActive(false);
        P8.SetActive(false);
    }

    public void Profile1()
    {
        ProfileOnOff(ProB1, ProB2, ProB3, ProB4, ProB5, ProB6, ProB7, ProB8);
    }

    public void Profile2()
    {
        ProfileOnOff(ProB2, ProB3, ProB4, ProB5, ProB6, ProB7, ProB8, ProB1);
    }

    public void Profile3()
    {
        ProfileOnOff(ProB3, ProB4, ProB5, ProB6, ProB7, ProB8, ProB1, ProB2);
    }

    public void Profile4()
    {
        ProfileOnOff(ProB4, ProB5, ProB6, ProB7, ProB8, ProB1, ProB2, ProB3);
    }

    public void Profile5()
    {
        ProfileOnOff(ProB5, ProB6, ProB7, ProB8, ProB1, ProB2, ProB3, ProB4);
    }

    public void Profile6()
    {
        ProfileOnOff(ProB6, ProB7, ProB8, ProB1, ProB2, ProB3, ProB4, ProB5);
    }

    public void Profile7()
    {
        ProfileOnOff(ProB7, ProB8, ProB1, ProB2, ProB3, ProB4, ProB5, ProB6);
    }

    public void Profile8()
    {
        ProfileOnOff(ProB8, ProB1, ProB2, ProB3, ProB4, ProB5, ProB6, ProB7);
    }
}
