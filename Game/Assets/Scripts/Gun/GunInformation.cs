using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInformation: MonoBehaviour
{

    public Gun gunSO;

    public static float fireRate;
    public static float accuracy;
    public static float damage;
    public static float magazineSize;

    void Awake()
    {
        fireRate = gunSO.muzzle.fireRate;
        accuracy = gunSO.stock.accuracy;
        damage = gunSO.ammo.damage;
        magazineSize = gunSO.magazine.magazineSize;

    }

}
