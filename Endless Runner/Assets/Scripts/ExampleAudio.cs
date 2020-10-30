using UnityEngine;
using UnityEngine.Audio;
public class ExampleAudio : MonoBehaviour
{
    [SerializeField] internal AudioSource audioSourceFish;
    [SerializeField] internal AudioClip audioClipFish;

    void Start()
    {
        audioSourceFish = GetComponent<AudioSource>();
        audioSourceFish.clip = audioClipFish;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioSourceFish.PlayOneShot(audioClipFish);
        }
    }
}
