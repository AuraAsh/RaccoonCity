using UnityEngine.Audio;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    internal Vector3 moveVector;
    internal CharacterController controller;
    internal float speed = 10f;
    internal float verticalVelocity = 0f;
    internal float gravity = 12f;
    internal float animationDuration = 3f;
    internal float startTime;
    internal bool isDead = false;

    [Header ("Sound Fish")]
    [SerializeField] private AudioSource audioFish;
    [SerializeField] private AudioClip audioClipFish;

    void Start()
    {
        audioFish = GetComponent<AudioSource>();
        audioFish.clip = audioClipFish;

        controller = GetComponent<CharacterController>();
        startTime = Time.time;
    }

    void Update()
    {
        if (isDead)
            return;

        if (Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }

    public void SetSpeed(float modifier)
    {
        speed = 10f + modifier;
    }

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.point.z > transform.position.z + 0.1f && hit.transform.tag == "Enemy")
    //        Death();
    //}

    public void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
    #region Controller Sound

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Death();
        }

        if (other.CompareTag("Fish"))
        {
            audioFish.PlayOneShot(audioClipFish);
            Score.numberOfFish += 1;
            Destroy(other.gameObject);
        }
    }

    #endregion

}
