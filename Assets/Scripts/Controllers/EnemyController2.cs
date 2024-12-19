using System.Collections;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    public int scoreValue = 10;
    public float duration = 1f;
    public AudioClip hitSound;

    private float elapsedTime = 0f;
    private bool isHit = false;
    private Quaternion initialRotation;
    private Quaternion finalRotation;
    private AudioSource audioSource;
    private ScoreManager scoreManager;
    private Animator animator;

    void Start()
    {
        initialRotation = transform.rotation;
        finalRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(90, 0, 0));
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow") && !isHit)
        {
            audioSource.PlayOneShot(hitSound);
            scoreManager.AddScore(scoreValue);
            animator.speed = 0;
            scoreValue = 0;
            elapsedTime = 0f;
            isHit = true;
            StartCoroutine(RotateOverTime());
        }
    }

    private IEnumerator RotateOverTime()
    {
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            transform.rotation = Quaternion.Lerp(initialRotation, finalRotation, t);
            yield return null;
        }
        transform.rotation = finalRotation;
    }
}