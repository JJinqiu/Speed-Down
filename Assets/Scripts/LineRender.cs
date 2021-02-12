using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    private LineRenderer _line;
    public Transform startPoint;
    public Transform endPoint;

    // Start is called before the first frame update
    private void Start()
    {
        _line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        _line.SetPosition(0, startPoint.position);
        _line.SetPosition(1, endPoint.position);
    }
}