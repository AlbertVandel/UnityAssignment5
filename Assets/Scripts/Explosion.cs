﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
