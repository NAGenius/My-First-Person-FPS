using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    private Animator animator;

    private AudioSource audioSource;

    public AudioClip shootStartSound;
    public AudioClip shootEndSound;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            gameObject.AddComponent<AudioSource>();
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Holding", false);
            animator.SetBool("Fire", true);
            PlaySound(shootStartSound);
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Holding", true);
            animator.SetBool("Fire", false);
            PlaySound(shootEndSound);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}