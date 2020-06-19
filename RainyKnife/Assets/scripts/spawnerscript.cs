﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerscript : MonoBehaviour
{
    public GameObject knife;

    private float min_X = -2.7f;
    private float max_X = 2.7f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startSpawning());
    }

    IEnumerator startSpawning()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        GameObject k = Instantiate(knife);
        float x = Random.Range(min_X, max_X);

        k.transform.position = new Vector2(x, transform.position.y);

        StartCoroutine(startSpawning());
    }

}