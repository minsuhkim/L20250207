using UnityEngine;
using UnityEngine.Audio;

// 보드를 이용해서 오디오를 화면에서 표현하는 도구
public class AudioBoardVisualizer : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public AudioMixer audioMixer;

    public Board[] boards;

    // 보드 증가량
    public float minBoard = 50.0f;
    public float maxBoard = 500.0f;

    // 스펙트럼 용 samples
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
        // AudioMixer 그룹 중에서 "Master"그룹을 찾아 적용
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float[] data = audioSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular);
        // GetSpectrumData(samples, channel, FFTWindow);
        
        // samples = FFT(신호에 대한 주파수 영역)를 저장할 배열, 이 배열 값은 2의 제곱 수로 표현
        // 채널은 최대 8개의 채널을 지원해주고 있음. 일반적으로는 0을 사용
        // FFTWindow는 샘플링 진행할 때 쓰는 값

        // 보드 총 개수만큼 작업을 진행함
        for(int i=0; i<boards.Length; i++)
        {
            var size = boards[i].GetComponent<RectTransform>().rect.size;
            // 보드 각각이 가지고 있는 사이즈를 얻어옴
            size.y = minBoard + (data[i] * (maxBoard - minBoard));

            boards[i].GetComponent<RectTransform>().sizeDelta = size;
            // sizeDelta는 부모를 기준으로 크기가 얼마나 큰지 작은지를 나타낸 수치를 의미
        }
    }
}
