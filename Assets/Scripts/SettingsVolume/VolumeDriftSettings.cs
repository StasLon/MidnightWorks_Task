using UnityEngine;
using UnityEngine.UI;

public class VolumeDriftSettings : MonoBehaviour
{

    [SerializeField] private Slider DriftVolumeSlider;
    private const string driftVolumeKey = "DriftVolume";

    private void Start()
    {
        if (PlayerPrefs.HasKey(driftVolumeKey))
        {
            float saveVolume = PlayerPrefs.GetFloat(driftVolumeKey);
            DriftVolumeSlider.value = saveVolume;
        }
    }

    public void UpdateVolume()
    {
        PlayerPrefs.SetFloat(driftVolumeKey, DriftVolumeSlider.value);
        PlayerPrefs.Save();
    }

}
