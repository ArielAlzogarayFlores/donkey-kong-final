﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collisions : MonoBehaviour
{
    public GameObject victoria;
    public GameObject comienzo;
    public GameObject cube_victoria;
    public Text score;
    public AudioClip ganar;
    public AudioClip morir;
    AudioSource fuenteAudio;
    Vector3 spawn;
    Vector3 rotation;
    float Timervictoria = 5;
    int valor = 0;
    // Start is called before the first frame update
    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
        spawn = transform.position;
        rotation = transform.eulerAngles;

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
        if (transform.position != spawn)
        {
            comienzo.SetActive(false);
        }
        if (transform.position.y < 0)
        {
            transform.eulerAngles = rotation;
            transform.position = spawn;
            fuenteAudio.clip = morir;
            fuenteAudio.Play();
            valor = Convert.ToInt32(score.text);
            valor = 0;
            score.text = valor.ToString();
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
            transform.eulerAngles = rotation;
            transform.position = spawn;
            valor = Convert.ToInt32(score.text);
            valor ++;
            score.text = valor.ToString();
            
            for (int i = 0; i < 75; i++)
            {
                GameObject clon_victoria = Instantiate(cube_victoria);
                Destroy(clon_victoria, 3.5f);
            }
        }
        if (col.gameObject.tag == "ball")
        {
            transform.eulerAngles = rotation;
            transform.position = spawn;
            fuenteAudio.clip = morir;
            fuenteAudio.Play();
            valor = Convert.ToInt32(score.text);
            valor = 0;
            score.text = valor.ToString();
        }
        if (col.contactCount == 0)
        {
            transform.position = spawn;
        }
    }

        
}
