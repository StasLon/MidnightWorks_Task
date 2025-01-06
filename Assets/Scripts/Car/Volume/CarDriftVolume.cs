using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriftVolume : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;


    private void Start()
    {
        SaveVolume();
    }

    private void SaveVolume()
    {
        if (PlayerPrefs.HasKey("DriftVolume"))
        {
            audioSource.volume = PlayerPrefs.GetFloat("DriftVolume");
        }
    }

}
