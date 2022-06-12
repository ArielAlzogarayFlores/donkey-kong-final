using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    float movementSpeed = 0.1f;
    float rotationSpeed = 2;
    int hasjump;
    Rigidbody rb;
    public float JumpForce;
    public AudioClip salto;
    AudioSource fuenteAudio;

    // Start is called before the first frame update
    void Start()
    {
        hasjump = 2;
        fuenteAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) && hasjump > 1)
        {
            transform.Rotate(0, rotationSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A) && hasjump > 1)
        {
            transform.Rotate(0, -rotationSpeed, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && hasjump > 0)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            fuenteAudio.clip = salto;
            fuenteAudio.Play();
            hasjump --;
        }
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "ground")
        {
            hasjump = 2;
        }
    }
}
