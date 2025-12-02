using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderVolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _audioMixerParameter;

    private Slider _volumeSlider;

    private float _volumeModificator = 20;
    private float _minVolume = -80;

    private void Awake()
    {
        _volumeSlider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
    }
    private void Start()
    {
        _volumeSlider.value = Mathf.Pow(10, (GetMixerVolume() / _volumeModificator));
    }

    public void ChangeVolume(float volume)
    {
        if( volume == 0)
        {
            SetMixerVolume(_minVolume);
            return;
        }

        SetMixerVolume(Mathf.Log10(volume) * _volumeModificator);
    }

    private float GetMixerVolume()
    {
        _audioMixer.GetFloat(_audioMixerParameter, out float mixerVolume);

        return mixerVolume;
    }

    private void SetMixerVolume(float volume)
    {
        _audioMixer.SetFloat(_audioMixerParameter, volume);
    }
}
