using UnityEngine;
using System.Collections;

public class WeaponSwitching : MonoBehaviour
{
    public int SelectedWeapon = 0;
    public string Currentweapon;
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentWeapon();
        int PrevSelectedWeapon = SelectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (SelectedWeapon >= transform.childCount - 1)
            {
                SelectedWeapon = 0;
            }
            else
            {
                SelectedWeapon++;
            }

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (SelectedWeapon <= 0)
            {
                SelectedWeapon = transform.childCount - 1;
            }
            else
            {
                SelectedWeapon--;
            }


        }
        if (FindObjectOfType<PauseScript>().GameIsPaused != true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectedWeapon = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            {
                SelectedWeapon = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
            {
                SelectedWeapon = 2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
            {
                SelectedWeapon = 3;
            }
        }
        


        if (PrevSelectedWeapon != SelectedWeapon)
        {
            SelectWeapon();
        }

    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == SelectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;
        }

    }
    void GetCurrentWeapon()
    {
        foreach (Transform weapon in transform)
        {
            if (weapon.gameObject.activeSelf == true)
            {
                Currentweapon = weapon.gameObject.name;
            }


        }

    }
}

