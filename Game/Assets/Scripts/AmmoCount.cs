using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public ShootControl ammunition;

    [SerializeField]
    private Text _ammoText;

    // Start is called before the first frame update
    void Start()
    {
        _ammoText.text =""+ ammunition.getAmmo();
    }

    public void updateAmmoCount()
    {
        _ammoText.text = "" + ammunition.getAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        updateAmmoCount();
    }
}
