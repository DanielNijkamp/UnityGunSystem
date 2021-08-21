using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public float damage = 35f;
    public float range = 100f;
    public float fireRate = 15f;
    public float ImpactForce = 100f;

    private float nextTimeToFire = 0f;

    public int MaxAmmo = 10;
    private int CurrentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera cam;
    public Color raycastcolor = Color.green;

    public ParticleSystem muzzleflash;
    public ParticleSystem impactEffect;

    public GameObject ImpactGO;

    public Animator animator;

    public TextMeshProUGUI AmmoText;
    public TextMeshProUGUI WeaponText;

    private void Start()
    {
        CurrentAmmo = MaxAmmo;
    }
    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        if (Input.GetKeyDown("r") && CurrentAmmo < MaxAmmo)
        {
            StartCoroutine(Reload());
        }

        if (isReloading)
        {
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            
            nextTimeToFire = Time.time + 1f / fireRate;
            shoot();
        }
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay (ray.origin, ray.direction * 50000000, Color.red);

        if (CurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
    
    }
    private void FixedUpdate()
    {
        AmmoText.text = CurrentAmmo + "/" + MaxAmmo;
        WeaponText.text = FindObjectOfType<WeaponSwitching>().Currentweapon;
    }
    void shoot()
    {
        CurrentAmmo--;

        muzzleflash.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }
        }
        

        GameObject ImpactGO = Instantiate(impactEffect.gameObject, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(ImpactGO, 1);
        

    }
    IEnumerator Reload()
    {
        animator.SetBool("Reloading", true);
        isReloading = true;
        Debug.Log("Reloading");

        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        CurrentAmmo = MaxAmmo;
        isReloading = false;

    }
}

