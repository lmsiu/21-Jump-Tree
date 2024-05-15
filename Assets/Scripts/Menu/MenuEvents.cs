using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvents : MonoBehaviour
{

    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _sfxSlider;

    /*
    public void BGMVolume()
    {
        AudioManager.instance.BGMVolume(_bgmSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(_sfxSlider.value);
    }
    */

    private void Start()
    {
        SetSFXVolume();
        SetBGMVolume();
    }
    

    public void SetSFXVolume()
    {
        float volume = _sfxSlider.value;
        myMixer.SetFloat("sfx", volume);
    }
     
     
    public void SetBGMVolume()
    {
        float volume = _bgmSlider.value;
        myMixer.SetFloat("bgm", volume);
    }
    

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
