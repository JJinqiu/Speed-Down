using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Vector3 _movement;
    public float speed;
    private GameObject _topLine;

    // Start is called before the first frame update
    private void Start()
    {
        _movement.y = speed;
        _topLine = GameObject.Find("TopLine");
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        transform.position += _movement * Time.deltaTime;
        if (transform.position.y >= _topLine.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}