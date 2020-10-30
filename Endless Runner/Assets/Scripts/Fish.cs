using UnityEngine.Audio;
using UnityEngine;

public class Fish : MonoBehaviour
{
    //[SerializeField] private AudioSource audioFish;
    //[SerializeField] private AudioClip audioClipFish;

    //private void Start()
    //{
    //    audioFish = GetComponent<AudioSource>();
    //    audioFish.clip = audioClipFish;
    //}
    void Update()
    {
        transform.Rotate(20 * Time.deltaTime, 0, 0);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Player"))
    //    {
    //        audioFish.PlayOneShot(audioClipFish);
    //        Score.numberOfFish += 1;
    //        Destroy(gameObject);
    //    }
    //}
}
