using UnityEngine;
using UnityEngine.Audio;

// ���带 �̿��ؼ� ������� ȭ�鿡�� ǥ���ϴ� ����
public class AudioBoardVisualizer : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public AudioMixer audioMixer;

    public Board[] boards;

    // ���� ������
    public float minBoard = 50.0f;
    public float maxBoard = 500.0f;

    // ����Ʈ�� �� samples
    public int samples = 64;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boards = GetComponentsInChildren<Board>();

        if(audioSource ==  null)
        {
            audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
        }
        else
        {
            audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        }

        audioSource.clip = audioClip;
        audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];
        // AudioMixer �׷� �߿��� "Master"�׷��� ã�� ����
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float[] data = audioSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular);
        // GetSpectrumData(samples, channel, FFTWindow);
        
        // samples = FFT(��ȣ�� ���� ���ļ� ����)�� ������ �迭, �� �迭 ���� 2�� ���� ���� ǥ��
        // ä���� �ִ� 8���� ä���� �������ְ� ����. �Ϲ������δ� 0�� ���
        // FFTWindow�� ���ø� ������ �� ���� ��

        // ���� �� ������ŭ �۾��� ������
        for(int i=0; i<boards.Length; i++)
        {
            var size = boards[i].GetComponent<RectTransform>().rect.size;
            // ���� ������ ������ �ִ� ����� ����
            size.y = minBoard + (data[i] * (maxBoard - minBoard));

            boards[i].GetComponent<RectTransform>().sizeDelta = size;
            // sizeDelta�� �θ� �������� ũ�Ⱑ �󸶳� ū�� �������� ��Ÿ�� ��ġ�� �ǹ�
        }
    }
}
