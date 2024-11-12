using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public static SettingManager instance;

    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public TMP_Dropdown qualityDropdown; // Dropdown cho độ nét
    public TMP_Dropdown resolutionDropdown; // Dropdown cho độ phân giải
    public Toggle fullscreenToggle;
    public Toggle musicToggle;
    public Toggle sfxToggle;

    public AudioSource musicSource; // Tham chiếu đến AudioSource cho âm thanh nền
    public AudioSource sfxSource;   // Tham chiếu đến AudioSource cho âm thanh hiệu ứng
    public AudioClip jumpSound;      // Âm thanh nhảy
    public AudioClip collisionSound;  // Âm thanh va chạm
    public AudioClip clickSound;    // Âm thanh click
    public AudioClip coinSound;

    private float previousMusicVolume; // Lưu giá trị âm lượng nhạc nền trước khi tắt
    private float previousSfxVolume;   // Lưu giá trị âm lượng SFX trước khi tắt

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Load settings đã lưu
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1);
        qualityDropdown.value = PlayerPrefs.GetInt("QualityLevel", 1); // Giả sử chất lượng mặc định là Medium
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 0) == 1;

        // Khởi tạo dropdown cho độ phân giải
        InitializeResolutionDropdown();

        // Thêm listener cho các thành phần
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        qualityDropdown.onValueChanged.AddListener(SetQuality); // Thêm listener cho chất lượng
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
        musicToggle.onValueChanged.AddListener(SetOnMusic);
        sfxToggle.onValueChanged.AddListener(SetOnSfx);
        resolutionDropdown.onValueChanged.AddListener(SetResolution); // Thêm listener cho dropdown độ phân giải

        // Khởi tạo âm lượng cho các AudioSource
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1);
        sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume", 1);
    }

    private void InitializeResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        foreach (Resolution res in Screen.resolutions)
        {
            options.Add(res.width + " x " + res.height);
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionIndex", 0);
        resolutionDropdown.RefreshShownValue();
    }

    public void SetMusicVolume(float value)
    {
        musicSource.volume = value; // Cập nhật âm lượng nhạc nền
        PlayerPrefs.SetFloat("MusicVolume", value); // Lưu cài đặt
    }

    public void SetSFXVolume(float value)
    {
        sfxSource.volume = value; // Cập nhật âm lượng hiệu ứng
        PlayerPrefs.SetFloat("SFXVolume", value); // Lưu cài đặt
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex); // Cập nhật chất lượng
        PlayerPrefs.SetInt("QualityLevel", qualityIndex); // Lưu cài đặt
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen; // Chuyển đổi chế độ toàn màn hình
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0); // Lưu cài đặt
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution selectedResolution = Screen.resolutions[resolutionIndex];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex); // Lưu cài đặt
    }

    public void PlayJumpSound()
    {
        sfxSource.PlayOneShot(jumpSound); // Phát âm thanh nhảy
    }

    public void PlayCollisionSound()
    {
        sfxSource.PlayOneShot(collisionSound); // Phát âm thanh va chạm
    }

    public void PlayClickSound()
    {
        sfxSource.PlayOneShot(clickSound); // Phát âm thanh click
    }

    public void SetOnMusic(bool isOn)
    {
        if (isOn)
        {
            musicSource.volume = previousMusicVolume; // Khôi phục âm lượng nếu bật
            musicVolumeSlider.interactable = true; // Cho phép chỉnh slider
        }
        else
        {
            previousMusicVolume = musicSource.volume; // Lưu âm lượng trước khi tắt
            musicSource.volume = 0; // Tắt âm thanh nhạc nền
            musicVolumeSlider.interactable = false; // Vô hiệu hóa slider
        }
    }

    public void SetOnSfx(bool isOn)
    {
        if (isOn)
        {
            sfxSource.volume = previousSfxVolume; // Khôi phục âm lượng nếu bật
            sfxVolumeSlider.interactable = true; // Cho phép chỉnh slider
        }
        else
        {
            previousSfxVolume = sfxSource.volume; // Lưu âm lượng trước khi tắt
            sfxSource.volume = 0; // Tắt âm thanh hiệu ứng
            sfxVolumeSlider.interactable = false; // Vô hiệu hóa slider
        }
    }
}