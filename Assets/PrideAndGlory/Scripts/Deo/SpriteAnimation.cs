using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{

    [SerializeField] private Sprite[] frameArray;
    private int currentFrame;
    private float timer;
    private float framerate = .1f;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer >= framerate)
        {
            timer -= framerate;
            currentFrame = (currentFrame +1 ) % frameArray.Length;
            spriteRenderer.sprite = frameArray[currentFrame];

        }
        
    }
}
