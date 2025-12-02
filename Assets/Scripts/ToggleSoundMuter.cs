using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleSoundMuter : MonoBehaviour
{
    private Toggle _soundToggle;

    private float _minVolume = 1;
    private float _maxVolume = 0;

    private void Awake()
    {
        _soundToggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _soundToggle.onValueChanged.AddListener(MuteSound);
    }

    private void OnDisable()
    {
        _soundToggle.onValueChanged.RemoveListener(MuteSound);
    }

    private void Start()
    {
        MuteSound(_soundToggle.isOn);
    }
    
    public void MuteSound(bool isMuted)
    {
        if(isMuted == true)
        {
            AudioListener.volume = _minVolume;
        }
        else
        {
            AudioListener.volume = _maxVolume;
        }
    }
}