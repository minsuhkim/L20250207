using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


// 자동완성으로 만들어지는 슬라이더 조인트 2D의 경우는
// Rigidbody 물리 제어를 받는 게임 오브젝트가 공간에서 선을 따라 미끄러지게 하는 설정을 할 때 사용
// Ex) 미닫이 문

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider masterVolumeSlider;
    [SerializeField]
    private Slider bgmVolumeSlider;
    [SerializeField]
    private Slider sfxVolumeSlider;

    private void Awake()
    {
        masterVolumeSlider.onValueChanged.AddListener(SetMaster);
        bgmVolumeSlider.onValueChanged.AddListener(SetBGM);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFX);
    }

    private void SetSFX(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    private void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }

    private void SetMaster(float volume)
    {
        // 오디오 믹서가 가지고 있는 파라미터(Expose)의 수치를 설정하는 기능
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);

        // 이번 예제에서는 오디오 믹서의 최소 ~ 최대 볼륨 값 때문에 로그 함수가 사용됨
        // 최소가 -80, 최대가 0
        // 그래서 수치 변경 시 Mathf.Log10(슬라이더 수치*20)을 통해 범위를 설정하고
        // 슬라이더의 최소 값이 0.0001일 경우 -80이 1일 경우 0이 계산됨
    }
}
