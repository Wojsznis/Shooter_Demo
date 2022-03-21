using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 3f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private GameObject muzzleflash;
    [SerializeField] private GameObject hitMarkerPrefab;
    [SerializeField] private AudioSource weaponAudio;
    [SerializeField] private int currentAmmo;
    [SerializeField] private int maxAmmo = 50;
    [SerializeField] private GameObject weapon;

    private CharacterController controller;
    private UIManager uIManager;

    private bool isReloading = false;
    public bool hasCoin = false;
    private bool hasWeapon = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;   

        currentAmmo = maxAmmo;
    }

    void Update()
    {
        LeftMouseButtonPressed();
        CalculateMovement();
        uIManager.UpdateAmmo(currentAmmo);
    }

    void CalculateMovement()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 velocity = direction * speed;

        velocity.y -= gravity;
        velocity = transform.TransformDirection(velocity);

        controller.Move(velocity * Time.deltaTime); 
    }

    void LeftMouseButtonPressed()
    {
        if(hasWeapon == true )
        {

        

            if(Input.GetMouseButton(0) && currentAmmo > 0)
            {                      
                Shoot();    
            }
            else
            {
                muzzleflash.SetActive(false);
                weaponAudio.Stop();
            }

            if(Input.GetKeyDown(KeyCode.R) && isReloading == false)
            {
                isReloading = true;
                StartCoroutine(Reload());
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    void Shoot()
    {
        muzzleflash.SetActive(true);

            currentAmmo--;
            uIManager.UpdateAmmo(currentAmmo);

            if(weaponAudio.isPlaying == false)
            {
                weaponAudio.Play();
            }
            
            Ray ray = Camera.main.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0f));
            
            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.transform.name);

                GameObject hitMarker = Instantiate(hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(hitMarker, 2f);

                Crate crate = hitInfo.transform.GetComponent<Crate>();

                if(crate != null)
                {
                    crate.DestroyCrate();
                }
            }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    public void EnableWeapons()
    {
        weapon.SetActive(true);
        hasWeapon = true;
    }
}
