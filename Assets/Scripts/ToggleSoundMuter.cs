using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleSoundMuter : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _audioMixerParameter;

    private Toggle _soundToggle;

    private float _minVolume = -80;
    private float _currentVolume;

    public bool IsMuted { get; private set; }

    private void Awake()
    {
        _soundToggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        IsMuted = _soundToggle.isOn;
        SetCurrentVolume(GetMixerVolume());

        if (IsMuted == true)
        {
            SetMixerVolume(_minVolume);
        }
    }

    private void OnEnable()
    {
        _soundToggle.onValueChanged.AddListener(MuteSound);
    }

    private void OnDisable()
    {
        _soundToggle.onValueChanged.RemoveListener(MuteSound);
    }

    public void MuteSound(bool isMuted)
    {
        IsMuted = isMuted;

        if(IsMuted == true)
        {
            SetCurrentVolume(GetMixerVolume());
            SetMixerVolume(_minVolume);
        }
        else
        {
            SetMixerVolume(_currentVolume);
        }
    }
    public void SetCurrentVolume(float volume)
    {
        _currentVolume = volume;
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