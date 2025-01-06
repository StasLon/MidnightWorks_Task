using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngineVolume : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;


    private void Start()
    {
        SaveVolume();
    }

    private void SaveVolume()
    {
        if (PlayerPrefs.HasKey("EngineVolume"))
        {
            audioSource.volume = PlayerPrefs.GetFloat("EngineVolume");
        }
    }
}
