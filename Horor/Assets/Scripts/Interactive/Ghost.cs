using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _lifeTime = 3;

    private void Start()
    {
        Destroy(this.gameObject,_lifeTime);
    }

    void Update()
    {
        transform.position += Vector3.forward * _speed * Time.deltaTime;
    }
}
