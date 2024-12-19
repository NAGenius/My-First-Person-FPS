using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    public float maxChargeTime = 0.5f;
    public bool isReadyToShoot = false;
    public AudioClip shootStartSound;
    public AudioClip shootEndSound;

    private float chargeTime;
    private bool isCharging = false;
    private ProjectileStandard projectile;
    private Animator animator;
    private AudioSource audioSource;
    private WeaponController weaponController;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        projectile = GetComponent<WeaponController>().ProjectilePrefab.GetComponent<ProjectileStandard>();

        if (audioSource == null)
        {
            gameObject.AddComponent<AudioSource>();
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {   
        //     chargeTime = Time.time;
        //     isCharging = true;
        //     animator.speed = 0;
        //     animator.SetBool("Fire", false);
        //     animator.SetBool("Fill", true);
        //     animator.speed = 0.5f;
        //     PlaySound(shootStartSound);
        // }

        // if (Input.GetMouseButtonUp(0))
        // {
        //     if (isCharging)
        //     {
        //         holdDuration = Time.time - chargeTime;
        //         isCharging = false;
        //     }
        //     holdDuration = Mathf.Clamp(holdDuration, 0, 0.5f);
        //     projectile.Speed = holdDuration * 100;
        //     animator.speed = 0;
        //     animator.SetBool("Fill", false);
        //     animator.SetBool("Fire", true);
        //     animator.speed = 1.2f;
        //     PlaySound(shootEndSound);
        // }
        if (weaponController == null) weaponController = GameObject.FindObjectOfType<WeaponController>();

        if (Input.GetKeyDown(KeyCode.R))
        {
            audioSource.Stop();
            isCharging = true;
            chargeTime = 0f;
            animator.speed = 0.5f;
            animator.SetBool("Fire", false);
            animator.SetBool("Fill", true);
            audioSource.PlayOneShot(shootStartSound);
        }

        if (isCharging)
        {
            if (Input.GetKey(KeyCode.R))
            {
                chargeTime += Time.deltaTime;
                chargeTime = Mathf.Clamp(chargeTime, 0f, maxChargeTime);
            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                isCharging = false;
                isReadyToShoot = true;
                weaponController.isReadyToShoot = isReadyToShoot;
                animator.speed = 0;
                audioSource.Stop();
            }
        }

        if (isReadyToShoot && Input.GetMouseButtonDown(0))
        {
            projectile.Speed = chargeTime * 100;
            animator.SetBool("Fill", false);
            animator.SetBool("Fire", true);
            animator.speed = 1.2f;
            audioSource.PlayOneShot(shootEndSound);
            isReadyToShoot = false;
            weaponController.isReadyToShoot = isReadyToShoot;
        }
    }
}