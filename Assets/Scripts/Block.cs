using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    private Level m_Level;

    private void Start()
    {
        m_Level = FindObjectOfType<Level>();
        m_Level.CountBreakableBlock();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (breakSound !=null)
        {
            if (Camera.main is { }) AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        }
        Destroy(gameObject);
        m_Level.BlockDestroyed();
    }
}
