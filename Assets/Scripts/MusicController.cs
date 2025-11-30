using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private string _mixerParameter;

    private float _minVolume = -80;
    private float _maxVolume = 0;

    public void MuteMusic()
    {
        if(IsMuted())
            _mixer.SetFloat(_mixerParameter, _maxVolume);
        else
            _mixer.SetFloat(_mixerParameter, _minVolume);
    }

    private bool IsMuted()
    {
        if (GetMixerVolume() == _minVolume)
            return true;

        return false;
    }

    private float GetMixerVolume()
    {
        _mixer.GetFloat(_mixerParameter, out float mixerVolume);

        return mixerVolume;
    }
}
