using UnityEngine;
using UnityEngine.UI;

public class SettingsCanvas : MonoBehaviour
{
    [SerializeField] Slider sfx;
    [SerializeField] Slider mfx;
    [SerializeField] AudioSource sfxAudio;
    [SerializeField] AudioSource mfxAudio;
    [SerializeField] AudioClip click;
    float mfxValue = 0;
    float sfxValue = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if(PlayerPrefs.GetInt("iteration") == 0)
        {
            sfxValue = sfx.value;
            mfxValue = mfx.value;
            PlayerPrefs.SetInt("iteration", 1);
        }
        sfxValue = PlayerPrefs.GetFloat(sfx.name);
        mfxValue = PlayerPrefs.GetFloat(mfx.name);
        mfx.value = mfxValue;
        sfx.value = sfxValue;
        Time.timeScale = 0f;
        mfxAudio.volume = mfxValue;
        sfxAudio.volume = sfxValue;
    }
    public void ChangeMusic()
    {
        mfxValue = mfx.value;
        mfxAudio.volume = mfxValue;
        sfxAudio.volume = sfxValue;
        PlayerPrefs.SetFloat(mfx.name, mfxValue);
    }
    public void ChangeSound()
    {
        sfxValue = sfx.value;
        mfxAudio.volume = mfxValue;
        sfxAudio.volume = sfxValue;
        PlayerPrefs.SetFloat(sfx.name, sfxValue);
    }

    public void Play()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
    public void PlayClick()
    {
        sfxAudio.PlayOneShot(click);
    }
}
