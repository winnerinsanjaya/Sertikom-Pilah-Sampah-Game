using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampahSpawnerScript : MonoBehaviour
{
    public float jedaSampah = 1f;
    float timer;

    //make an list sampah to spawn
    public GameObject[] objSampah;
    
    void Update()
    {

        //add a single second in every second
        timer += Time.deltaTime;

        //add jeda functuin to spawn
        if (timer > jedaSampah)
        {
            //randomize sampah spawn
            int random = Random.Range(0, objSampah.Length);

            //spawn sampah
            Instantiate(objSampah[random], transform.position, transform.rotation);
            timer = 0;
        }
    }
}
