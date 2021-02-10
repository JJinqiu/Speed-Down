using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBackground : MonoBehaviour
{
    private Material _material;
    private Vector2 _movement;

    public Vector2 speed;

    // Start is called before the first frame update
    private void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    private void Update()
    {
        _movement += speed * Time.deltaTime;
        _material.mainTextureOffset = _movement;
    }
}