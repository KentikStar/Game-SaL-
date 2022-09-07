using System.Collections;
using UnityEngine;

public class SoundShot : MonoBehaviour
{
    public void PlaySound()
    {
        StartCoroutine(SoundCoroutine());
    }


    IEnumerator SoundCoroutine()
    {
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(1f);

        this.gameObject.SetActive(false);
    }
}
