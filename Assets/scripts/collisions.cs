using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collisions : MonoBehaviour
{
    public GameObject victoria;
    public GameObject comienzo;
    public GameObject score;
    public AudioClip ganar;
    public AudioClip morir;
    AudioSource fuenteAudio;
    Vector3 spawn;
    float Timervictoria = 5;
    // Start is called before the first frame update
    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
        spawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Timervictoria < 5)
        {
            Timervictoria -= Time.deltaTime;
        }
        if (Timervictoria < 0)
        {
            victoria.SetActive(false);
            Timervictoria = 5;
        }
        while (transform.position != spawn)
        {
            comienzo.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision col)
    {
     
        if (col.gameObject.name == "victoria")
        {
            victoria.SetActive(true);
            Timervictoria -= Time.deltaTime;
            fuenteAudio.clip = ganar;
            fuenteAudio.Play();
            transform.position = spawn;
            
        }
        if (col.gameObject.tag == "ball")
        {
            transform.position = spawn;
            fuenteAudio.clip = morir;
            fuenteAudio.Play();
        }
    }
}
