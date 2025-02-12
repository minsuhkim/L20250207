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
