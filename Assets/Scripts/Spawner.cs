using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();

    public float spawnTime;
    private float _countTime;
    private Vector3 _spawnPosition;
    
    // Update is called once per frame
    private void Update()
    {
        SpawnPlatform();
    }

    private void SpawnPlatform()
    {
        _countTime += Time.deltaTime;
        _spawnPosition = transform.position;
        _spawnPosition.x = Random.Range(-3.5f, 3.5f);

        if (_countTime >= spawnTime)
        {
            CreatePlatform();
            _countTime = 0;
        }
    }

    private void CreatePlatform()
    {
        var index = Random.Range(0, platforms.Count);
        var newPlatform = Instantiate(platforms[index], _spawnPosition, Quaternion.identity);
        newPlatform.transform.SetParent(gameObject.transform);
    }
}