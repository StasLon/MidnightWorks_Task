using UnityEngine;
using UnityEngine.UI;

public class VolumeEngineSettings : MonoBehaviour
{
    [SerializeField] private Slider EngineVolumeSlider;
    private const string engineVolumeKey = "EngineVolume";

    private void Start()
    {
        if (PlayerPrefs.HasKey(engineVolumeKey))
        {
            float saveVolume = PlayerPrefs.GetFloat(engineVolumeKey);
            EngineVolumeSlider.value = saveVolume;
        }
    }

    public void UpdateVolume()
    {
        PlayerPrefs.SetFloat(engineVolumeKey, EngineVolumeSlider.value);
        PlayerPrefs.Save();
    }

}
