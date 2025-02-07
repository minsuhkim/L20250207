using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AudioSourceSample : MonoBehaviour
{
    // 0) �ν����Ϳ��� ���� �����ϴ� ���
    public AudioSource audioSourceBGM;

    // 1) AudioSourceSample ��ü�� ��ü������ �ҽ��� ������ �ִ� ���
    //private AudioSource ownAudioSource;

    // 2) ������ ã�Ƽ� �����ϴ� ���
    // 3) Resources.Load() ����� �̿��� ���ҽ� ������ �ִ� ����� �ҽ��� Ŭ���� �޾ƿ��� ���
    [SerializeField]
    private AudioSource audioSourceSFX;

    public AudioClip bgm; // ����� Ŭ�� ����

    private void Start()
    {
        // 1)�� ��� GetComponent�� ���

        // 2)�� ��� GameObject.Find()�� ���
        audioSourceSFX = GameObject.Find("SFX").GetComponent<AudioSource>();

        //audioSourceBGM.clip = bgm;

        //audioSourceSFX.clip = Resources.Load("Explosion") as AudioClip;
        // Resources.Load()�� ���ҽ� �������� ������Ʈ�� ã�� �ε��ϴ� ���
        // �̶� �޾ƿ��� ���� ���� Object�̹Ƿ�, as Ŭ�������� ���� �ش� �����Ͱ� � �������� ǥ�����ָ�
        // �� ���·� �޾ƿ��� ��

        audioSourceSFX.clip = Resources.Load("Audio/BombCharge") as AudioClip;
        // ���ҽ� �ε� �� ��ΰ� ������ �ִٸ� ������/���ϸ����� �ۼ�
        // ���ҽ� �ε� �� �ۼ��ϴ� �̸����� Ȯ���ڸ�(.json, .avi ��)�� �ۼ����� ���� >> ������Ʈ�� ��ȯ >> as ���

        // UnityWebRequest�� GetAudioClip ��� Ȱ��
        StartCoroutine("GetAudioClip");

        audioSourceBGM.Play();
        //audioSourceBGM.Pause();
        //audioSourceBGM.PlayOneShot(bgm);
        //audioSourceBGM.Stop();
        //audioSourceBGM.UnPause();
        //audioSourceBGM.PlayDelayed(1.0f); // 1�ʵ� ��� 
    }

    private IEnumerator GetAudioClip()
    {
        UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip("file:///" + Application.dataPath + "/Audio/Explosion.wav", AudioType.WAV);
        yield return uwr.Send();

        var newClip = DownloadHandlerAudioClip.GetContent(uwr);
        // ���� ��θ� ������� �ٿ�ε� ����

        audioSourceBGM.clip = newClip;
        audioSourceBGM.Play();
    }

}
