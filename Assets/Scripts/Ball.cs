using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle1;

    private Vector2 m_PaddleToBallVector;

    private Rigidbody2D m_Rigidbody2D;
    private bool m_HasStarted = false;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] ballSounds;

    private AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_PaddleToBallVector = transform.position - paddle1.transform.position;
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_HasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();  
            
        }

    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_HasStarted = true;
            m_Rigidbody2D.velocity = new Vector2(xPush ,yPush);
        }
    }

    private void LockBallToPaddle(){
        var position = paddle1.transform.position;
        Vector2 paddlePos = new Vector2(position.x, position.y);
        transform.position = paddlePos + m_PaddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log(m_HasStarted.ToString());
        if (m_HasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            m_AudioSource.PlayOneShot(clip);  
        }
        
    }
}
