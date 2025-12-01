using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderVolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _audioMixerParameter;

    private Slider _volumeSlider;

    private void Awake()
    {
        _volumeSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        _volumeSlider.value = Mathf.Pow(10, (GetMixerVolume() / 20));
    }

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
    }

    public void ChangeVolume(float volume)
    {
        SetMixerVolume(Mathf.Log10(volume) * 20);
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
