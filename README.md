# L20250207
2025.02.07 Study Unity Sound&Record

```CS
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioSource audioBGM;

    [SerializeField]
    private bool isPlaying = false;

    private void Start()
    {
        audioBGM.clip = Resources.Load("BGM") as AudioClip;
    }

    public void OnPlayButtonClick()
    {
        if(isPlaying)
        {
            audioBGM.UnPause();
        }
        else
        {
            audioBGM.Play();
            isPlaying = true;
        }
        
    }

    public void OnPauseButtonClick()
    {
        audioBGM.Pause();
    }

    public void OnStopButtonClick()
    {
        audioBGM.Stop();
        isPlaying = false;
    }
}

```

~취소선~
**Bold**
> 1
>> 2
>>> 3


+ 2025-02-07
  + 유니티 사운드
    + 유니티 오디오 소스

- 2025-02-07
  - 유니티 사운드
    - 유니티 오디오 소스


<Hr></Hr>

안녕하세요. 반갑습니다. 감사합니다.
-----------------------------------


|제목|내용|설명|
|:------------|--------:|:--------:|
|왼쪽 정렬|오른쪽 정렬|중앙 정렬|
|Sample1|Content1|Description1|
|Sample2|Content2|Description2|
|Sample3|Content3|Description3|

