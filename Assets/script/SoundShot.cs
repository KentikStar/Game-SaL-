using System.Collections;
using UnityEngine;

public class SoundShot : MonoBehaviour
{

    private float volumeSound;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {       
        SetVolume();
    }
    


    public void PlaySound()
    {
        StartCoroutine(SoundCoroutine());
    }

    private void SetVolume(){
        volumeSound = this.GetComponentInParent<ParentSoundShot>().VolumeSound;

        audioSource.volume = volumeSound;
    }


    IEnumerator SoundCoroutine()
    {
        audioSource.Play();

        yield return new WaitForSeconds(1f);

        this.gameObject.SetActive(false);
    }
}
