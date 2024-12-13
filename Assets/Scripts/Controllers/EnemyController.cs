using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioClip hitSound;
    public int scoreValue = 10;

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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Arrow"))
        {
            audioSource.PlayOneShot(hitSound);
            scoreManager.AddScore(scoreValue);
        }
    }
}