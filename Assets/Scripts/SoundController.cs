using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


// �ڵ��ϼ����� ��������� �����̴� ����Ʈ 2D�� ����
// Rigidbody ���� ��� �޴� ���� ������Ʈ�� �������� ���� ���� �̲������� �ϴ� ������ �� �� ���
// Ex) �̴��� ��

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
        // ����� �ͼ��� ������ �ִ� �Ķ����(Expose)�� ��ġ�� �����ϴ� ���
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);

        // �̹� ���������� ����� �ͼ��� �ּ� ~ �ִ� ���� �� ������ �α� �Լ��� ����
        // �ּҰ� -80, �ִ밡 0
        // �׷��� ��ġ ���� �� Mathf.Log10(�����̴� ��ġ*20)�� ���� ������ �����ϰ�
        // �����̴��� �ּ� ���� 0.0001�� ��� -80�� 1�� ��� 0�� ����
    }
}
