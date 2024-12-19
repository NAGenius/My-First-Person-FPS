using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int scoreValue = 10;
    public AudioClip hitSound;

    private AudioSource audioSource;
    private ScoreManager scoreManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            audioSource.PlayOneShot(hitSound);
            scoreManager.AddScore(scoreValue);
        }
    }
}