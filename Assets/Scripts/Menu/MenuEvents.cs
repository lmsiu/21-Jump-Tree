using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class MenuEvents : MonoBehaviour
{
    public Slider VolumeSlider;
    public AudioMixer mixer;

    public void SetVolume()
    {
        mixer.SetFloat("volume", VolumeSlider.value);
        
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
