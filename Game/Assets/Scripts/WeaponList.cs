using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{


    public int currentGunIndex = 0;

    public GameObject[] guns;
    public GameObject activeGun;
    
    private int _totalGuns = 1;


    // Start is called before the first frame update
    void Start()
    {
        _totalGuns = transform.childCount;
        guns = new GameObject[_totalGuns];

        SelectGun();

        guns[0].SetActive(true);
        activeGun = guns[0];
        currentGunIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int previousGunIndex = currentGunIndex;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f){
            if(currentGunIndex >= _totalGuns -1)
            {
                currentGunIndex = 0;
            }
            else
            {
                currentGunIndex++;
            }

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentGunIndex <= 0)
            {
                currentGunIndex = _totalGuns - 1;
            }
            else
            {
                currentGunIndex--;
            }

        }

        if(previousGunIndex != currentGunIndex)
        {
            SelectGun();
        }
    }


    private void SelectGun()
    {
        for (int i = 0; i < _totalGuns; i++)
        {
            if (i == currentGunIndex)
            {
                guns[i] = transform.GetChild(i).gameObject;
                guns[i].SetActive(true);
            }
            else
            {
                guns[i] = transform.GetChild(i).gameObject;
                guns[i].SetActive(false);

            }
        }

    }


}
