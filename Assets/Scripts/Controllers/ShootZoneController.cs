using UnityEngine;
using Unity.FPS.Game;

public class ShootingSpotTrigger : MonoBehaviour
{
    private WeaponController weaponController;
    void OnTriggerEnter(Collider other)
    {
        if (weaponController == null) weaponController = GameObject.FindObjectOfType<WeaponController>();
        if (other.CompareTag("Player"))
        {
            // weaponController.m_CarriedPhysicalBullets = 20;
            weaponController.m_CurrentAmmo = weaponController.MaxAmmo;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (weaponController == null) weaponController = GameObject.FindObjectOfType<WeaponController>();
        if (other.CompareTag("Player"))
        {
            // weaponController.m_CarriedPhysicalBullets = 0;
            weaponController.m_CurrentAmmo = 0;
        }
    }
}