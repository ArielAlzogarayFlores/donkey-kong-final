using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ball1, ball2, ball3, ball4;
    public float Timer = 0.1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            GameObject clon1 = Instantiate(ball1);
            GameObject clon2 = Instantiate(ball2);
            GameObject clon3 = Instantiate(ball3);
            GameObject clon4 = Instantiate(ball4);
            Timer = 3;

            Destroy(clon1, 8);
            Destroy(clon2, 8);
            Destroy(clon3, 5);
            Destroy(clon4, 5);
        }
    }
}
