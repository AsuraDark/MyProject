using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AudioMixerSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private string _mixerParameter;

    private Slider _volumeSlider;

    private void Awake()
    {
        _volumeSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        _volumeSlider.value = Mathf.Pow(10,(GetMixerVolume()/20));
    }

    public void ChangeVolume(float volume)
    {
        _mixer.SetFloat(_mixerParameter, Mathf.Log10(volume) * 20);
    }

    private float GetMixerVolume()
    {
        _mixer.GetFloat(_mixerParameter, out float mixerVolume);

        return mixerVolume;
    }
}
