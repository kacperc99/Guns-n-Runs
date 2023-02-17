using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{
    public GameObject Player;
    public GameObject pfBullet;
    public Transform gunPoint;

    public float bulletSpeed = 50f;
    

    private Rigidbody2D rbPlayer;

    [SerializeField]
    private bool isShotgun;

    [SerializeField]
    private int numberOfBullets = 5;

    [SerializeField]
    private float projectileSpread = 80f;

    [SerializeField]
    private float playerKnockback = 1f;


    [SerializeField]
    private bool isBurst = false;
    [SerializeField]
    private int burstLimit = 3;

    [SerializeField]
    private float burstTimer = 0.4f;

    private float fireRate;

    private float lastShot = 0;

    private float maxAmmoCount;

    private float ammoCount;

    public float getAmmo(){
        return ammoCount;
    }

    private void Start()
    {
        Player = GameObject.Find("Player");
        rbPlayer = Player.GetComponent<Rigidbody2D>();
        fireRate = GunInformation.fireRate;
        maxAmmoCount = GunInformation.magazineSize;
        ammoCount = maxAmmoCount;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Debug.Log("Reloading");

            ammoCount = maxAmmoCount;
        }

        if (Input.GetMouseButton(0) && ammoCount > 0)
        {
            if (Time.time > 1 / fireRate + lastShot)
            {
                //  Debug.Log("Shooting");
                Shoot();
                lastShot = Time.time;
                ammoCount--;
            }
        }
    }

    void Shoot()
    {

        //Knockback on the player
        rbPlayer.AddForce(AimControl.lookDir * -playerKnockback);

        if (isBurst)
        {
            int limit = 0;
            StartCoroutine(ShootInBurst(limit));
        }
        else if (isShotgun)
        {
            SpawnMultipleBullets();
        }
        else
        {
            SpawnBullet();
            
        }
    }

    IEnumerator ShootInBurst(int limit)
    {

        if (limit >= burstLimit)
        {
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(burstTimer);

            SpawnBullet();

            limit++;
            StartCoroutine(ShootInBurst(limit));
        }
    }


    //Spawning bullet and adding force to it
    void SpawnBullet()
    {

        GameObject bullet = Instantiate(pfBullet, gunPoint.position, gunPoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(gunPoint.right * bulletSpeed, ForceMode2D.Impulse);

    }

    void SpawnMultipleBullets()
    {
        float startRotation = AimControl.angle + projectileSpread /2f;
        float angleIncrease = projectileSpread / ((float)numberOfBullets -1f);

        for (int i = 0; i < numberOfBullets; i++)
        {

            float tempRot = startRotation - angleIncrease * i;
            GameObject bullet = Instantiate(pfBullet, gunPoint.position, Quaternion.Euler(0f, 0f, tempRot));

            if (bullet)
            {

                Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

                Vector2 shootDirection = new Vector2(Mathf.Cos(tempRot * Mathf.Deg2Rad), Mathf.Sin(tempRot * Mathf.Deg2Rad));

                Debug.Log(Mathf.Cos(tempRot * Mathf.Deg2Rad));

                //Debug.Log(Mathf.Cos(tempRot * Mathf.Deg2Rad));
               // Debug.Log(Mathf.Sin(tempRot * Mathf.Deg2Rad));


                rbBullet.AddForce(shootDirection * bulletSpeed, ForceMode2D.Impulse);
            }

            
        }
    }
}

