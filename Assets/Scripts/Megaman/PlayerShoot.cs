using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public GameObject bulletRightPrefab;
    public GameObject bulletSuperRightPrefab;
    public GameObject bulletUltraRightPrefab;
    public GameObject bulletLeftPrefab;
    public GameObject bulletSuperLeftPrefab;
    public GameObject bulletUltraLeftPrefab;
    public Transform launchSpawnPointRight;
    public Transform launchSpawnPointLeft;
    public float timeChargeWeapon = 0;
    private float timeWaitChargeWeapon = 2;
    private float timeWaitLevelUpChargeWeapon = 6;
    public bool isChargeWeapon = false;
    public Animator animator;

    private void Start()
    {
        timeChargeWeapon = 0;
    }

    private void Update()
    {
        if (isChargeWeapon)
        {
            timeChargeWeapon += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !PlayerMovement.down)
        {
            isChargeWeapon = true;
            if (spriteRenderer.flipX)
            {
                LaunchBulletLeft();
            }
            else
            {
                LaunchBulletRight();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Shoot", true);
            if (spriteRenderer.flipX)
            {
                if (BlinckEffect.isChargeLevelUp)
                {
                    LaunchUltraBulletLeft();
                }
                else if (BlinckEffect.isCharge)
                {
                    LaunchSuperBulletLeft();
                }
                else
                {
                    LaunchBulletLeft();
                }
            }
            else
            {
                if (BlinckEffect.isChargeLevelUp)
                {
                    LaunchUltraBulletRight();
                }
                else if (BlinckEffect.isCharge)
                {
                    LaunchSuperBulletRight();
                }
                else
                {
                    LaunchBulletRight();
                }
            }
            isChargeWeapon = false;
            BlinckEffect.isCharge = false;
            BlinckEffect.isChargeLevelUp = false;
            timeChargeWeapon = 0;
        }
        if (timeChargeWeapon >= timeWaitChargeWeapon)
        {
            BlinckEffect.isCharge = true;
        }
        if (timeChargeWeapon >= timeWaitLevelUpChargeWeapon)
        {
            BlinckEffect.isChargeLevelUp = true;
        }
    }
    public void LaunchBulletRight()
    {
        Instantiate(bulletRightPrefab, launchSpawnPointRight.position, launchSpawnPointRight.rotation);
    }
    public void LaunchSuperBulletRight()
    {
        Instantiate(bulletSuperRightPrefab, launchSpawnPointRight.position, launchSpawnPointRight.rotation);
    }
    public void LaunchUltraBulletRight()
    {
        Instantiate(bulletUltraRightPrefab, launchSpawnPointRight.position, launchSpawnPointRight.rotation);
    }
    public void LaunchBulletLeft()
    {
        Instantiate(bulletLeftPrefab, launchSpawnPointLeft.position, launchSpawnPointLeft.rotation);
    }
    public void LaunchSuperBulletLeft()
    {
        Instantiate(bulletSuperLeftPrefab, launchSpawnPointLeft.position, launchSpawnPointLeft.rotation);
    }
    public void LaunchUltraBulletLeft()
    {
        Instantiate(bulletUltraLeftPrefab, launchSpawnPointLeft.position, launchSpawnPointLeft.rotation);
    }
}
