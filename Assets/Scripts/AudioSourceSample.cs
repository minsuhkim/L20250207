using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AudioSourceSample : MonoBehaviour
{
    // 0) 인스펙터에서 직접 연결하는 경우
    public AudioSource audioSourceBGM;

    // 1) AudioSourceSample 객체가 자체적으로 소스를 가지고 있는 경우
    //private AudioSource ownAudioSource;

    // 2) 씬에서 찾아서 연결하는 경우
    // 3) Resources.Load() 기능을 이용해 리소스 폴더에 있는 오디오 소스의 클립을 받아오는 경우
    [SerializeField]
    private AudioSource audioSourceSFX;

    public AudioClip bgm; // 오디오 클립 연결

    private void Start()
    {
        // 1)의 경우 GetComponent를 사용

        // 2)의 경우 GameObject.Find()를 사용
        audioSourceSFX = GameObject.Find("SFX").GetComponent<AudioSource>();

        //audioSourceBGM.clip = bgm;

        //audioSourceSFX.clip = Resources.Load("Explosion") as AudioClip;
        // Resources.Load()는 리소스 폴더에서 오브젝트를 찾아 로드하는 기능
        // 이때 받아오는 값은 같은 Object이므로, as 클래스명을 통해 해당 데이터가 어떤 형태인지 표현해주면
        // 그 형태로 받아오게 됨

        audioSourceSFX.clip = Resources.Load("Audio/BombCharge") as AudioClip;
        // 리소스 로드 시 경로가 정해져 있다면 폴더명/파일명으로 작성
        // 리소스 로드 시 작성하는 이름에는 확장자명(.json, .avi 등)을 작성하지 않음 >> 오브젝트를 반환 >> as 사용

        // UnityWebRequest의 GetAudioClip 기능 활용
        StartCoroutine("GetAudioClip");

        audioSourceBGM.Play();
        //audioSourceBGM.Pause();
        //audioSourceBGM.PlayOneShot(bgm);
        //audioSourceBGM.Stop();
        //audioSourceBGM.UnPause();
        //audioSourceBGM.PlayDelayed(1.0f); // 1초뒤 재생 
    }

    private IEnumerator GetAudioClip()
    {
        UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip("file:///" + Application.dataPath + "/Audio/Explosion.wav", AudioType.WAV);
        yield return uwr.Send();

        var newClip = DownloadHandlerAudioClip.GetContent(uwr);
        // 받은 경로를 기반으로 다운로드 진행

        audioSourceBGM.clip = newClip;
        audioSourceBGM.Play();
    }

}
