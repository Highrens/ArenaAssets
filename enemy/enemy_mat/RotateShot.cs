using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShot : MonoBehaviour
{

    public GameObject projectile;
    float t = 0;
    public float delay_between_shot;
    public float time_to_shot;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t >= time_to_shot)
        {
            StartCoroutine(Shot());
            t = 0;

        }
    }
    public IEnumerator Shot()
    {
        for (int i = 0; i < 3; i++)
        {

            Instantiate(projectile, transform.position + new Vector3(0, 0, 0), transform.rotation);
            if (GetComponent<AudioSource>()) GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(delay_between_shot);

        }
    }
}
