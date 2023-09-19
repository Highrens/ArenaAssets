using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Recoil))]
[RequireComponent(typeof(Scope))]
public class pistol_n : MonoBehaviour
{
    public bool lazerType = false;

    public GameObject projectile;
    public GameObject point;
    public GameObject Hit_ps;
    public GameObject PS_obj;
    public GameObject item;
    public Transform shot_dot;

    [Range(0, 100)]
    public float accuracy;
    public float time_to_shot;
    public int damage = 40;

    [Range(50, 100)]
    public int mobility = 100;

    public int shotAmount = 1;
    public bool IsGunAutomatic;
    public float reload_time;
    public float second_reload_time;
    public bool reload_by_one = false;

    float t = 5f;


    public bool zoom = false;
    public bool reloading = false;
    public int ammo;
    public int ammo_max;

    int fullAmmo;
    public string ammoType;
    public Text backpackAmmo_txt;
    public Text ammo_txt;
    public Sprite icon;

    public string type = "default";

    public AudioClip reloadAudio;
    Animator PT;
    AudioSource AS;
    InterFace Ui;
    AmmoScript AmmoScriptObj;
    
    //Делегат для отслеживания выстрела
    public delegate void ShotHandler();
    public event ShotHandler OnShot;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        PT = GetComponentInParent<Animator>();
        Ui = GetComponentInParent<InterFace>();
        AmmoScriptObj = GetComponentInParent<AmmoScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Ui.gameIsPaused) return;
        //Ui

        fullAmmo = 1; ;

        if (ammoType == "")
        {
            backpackAmmo_txt.gameObject.SetActive(false);
        }
        else
        {
            fullAmmo = (int)(typeof(AmmoScript).GetField(ammoType)).GetValue(AmmoScriptObj);
            backpackAmmo_txt.gameObject.SetActive(true);

            var ammoIcon = (Sprite)(typeof(AmmoScript).GetField(ammoType + "Icon")).GetValue(AmmoScriptObj);
            backpackAmmo_txt.GetComponentInChildren<Image>().sprite = ammoIcon;
        }
        ammo_txt.text = ammo.ToString();
        backpackAmmo_txt.text = fullAmmo.ToString();
        //Logic

        t += Time.deltaTime;

        if (!GetComponentInParent<Health>().isRunning)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Zoom();
            }

            if (Input.GetButton("Fire1") && IsGunAutomatic == true || Input.GetButtonDown("Fire1") && IsGunAutomatic == false)
            {
                if (reloading) return;
                if (ammo == 0 && (ammoType == "" || fullAmmo > 0))
                {
                    Reload();
                    return;
                }
                if (t >= time_to_shot && ammo > 0) Shot();
            }

        }




        if (Input.GetKeyDown(KeyCode.R) &&
            reloading == false &&
            ammo != ammo_max &&
            zoom == false &&
            !GetComponentInParent<Health>().isRunning
            && (ammoType == "" || fullAmmo > 0)) //&& GetComponentInParent<Pickups>().pistol_ammo >= ammo_max)
        {
            Reload();
        }


    }

    public void Shot()
    {
        OnShot?.Invoke();
        Instantiate(PS_obj, shot_dot.position, point.transform.rotation); //, gameObject.transform);
        PT.SetTrigger("Shot");
        ammo--;

        for (int i = 0; i < shotAmount; i++)
        {
            float spread = (-accuracy + 100) * 0.002f;
            Vector3 shotDir = point.transform.TransformDirection(Vector3.forward + new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0));

            if (!lazerType)
            {
                RaycastHit hit;
                if (Physics.Raycast(point.transform.position, shotDir, out hit, 300))
                {
                    if (hit.transform.gameObject.layer == 11 && hit.transform.gameObject.GetComponentInParent<Enemy_Health>() != null)
                    {
                        hit.transform.gameObject.GetComponentInParent<Enemy_Health>().Enemys_health -= damage;
                        hit.transform.gameObject.GetComponentInParent<Enemy_Health>().Player = transform.root.gameObject;
                    }
                    if (Hit_ps)
                    {
                        var NewHit = Instantiate(Hit_ps, hit.point, Quaternion.Euler(hit.normal * 90));
                        NewHit.transform.parent = hit.transform;
                    }
                }
            }
            else
            {
                var spawnedProj = projectile;
                Projectile_frend projectile_f = spawnedProj.GetComponentInChildren<Projectile_frend>();
                projectile_f.Damage = damage;
                projectile_f.dir = shotDir;
                projectile_f.Player = transform.root.gameObject;
                Instantiate(projectile, shot_dot.position, shot_dot.rotation);

            }
        }
        t = 0;
        StartCoroutine(GetComponent<Recoil>().Make_Recoil());


    }
    void Zoom()
    {
        zoom = !zoom;
        // PT.SetTrigger("zoom");

        // if (zoom == true)
        // {

        //     Spread /= 4;
        // }
        // else
        // {

        //     Spread *= 4;
        // }
    }

    void Reload()
    {
        reloading = true;
        if (reload_by_one == false)
        {
            StartCoroutine(Reload_normal());
        }
        else
        {
            StartCoroutine(Reload_by_one());
        }
    }
    public IEnumerator Reload_normal()
    {

        if (reloadAudio != null)
        {
            AS.clip = reloadAudio;
            AS.Play();
        }
        PT.SetTrigger("reload");
        yield return new WaitForSeconds(reload_time);
        reloading = false;

        //Получаем тип патронов


        if (ammoType != "")
        {
            var Type = typeof(AmmoScript).GetField(ammoType);
            if (Type != null)
            {
                int curretAmmo = (int)Type.GetValue(AmmoScriptObj);
                Type.SetValue(AmmoScriptObj, curretAmmo - 30);
            }

            int missingAmmo = ammo_max - ammo;
            Type.SetValue(AmmoScriptObj, fullAmmo - missingAmmo);
            fullAmmo = (int)(typeof(AmmoScript).GetField(ammoType)).GetValue(AmmoScriptObj);
            Debug.Log(fullAmmo);
            if (fullAmmo < 0)
            {
                ammo = ammo_max;
                ammo += fullAmmo;
                Type.SetValue(AmmoScriptObj, 0);
                //  fullAmmo = 0;
            }
            else
            {
                ammo = ammo_max;
            }
        }
        else
        {
            ammo = ammo_max;
        }

        //GetComponentInParent<Pickups>().pistol_ammo -= ammo_max;
    }

    public IEnumerator Reload_by_one()
    {

        PT.SetTrigger("reload");
        yield return new WaitForSeconds(reload_time);

        for (int i = ammo; i < ammo_max; i++)
        {
            var Type = typeof(AmmoScript).GetField(ammoType);
            if (fullAmmo > 0)
            {

                PT.SetTrigger("reload_again");
                yield return new WaitForSeconds(second_reload_time);
                Type.SetValue(AmmoScriptObj, fullAmmo - 1);
                ammo++;
            }
            else
            {
                break;
            }
        }
        PT.SetTrigger("reload");
        reloading = false;

        //GetComponentInParent<Pickups>().pistol_ammo -= ammo_max;
    }
}
