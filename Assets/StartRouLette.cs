using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRouLette : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private ParticleSystem[] _particleSystem = new ParticleSystem[3];
    private bool _isRunnning;

    public void Run()
    {
        if (_rigidBody != null)
        {
           var random = Random.value * 45.0f;
            _rigidBody.angularVelocity = new Vector3(0.0f, 0.0f, 51f + random);
            Debug.Log($"{random}");

            _isRunnning = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {        
        var bottle = GameObject.Find("Bottle");
        if (!bottle.TryGetComponent<Rigidbody>(out var rigidBody)) { throw new System.Exception(); }
        _rigidBody = rigidBody;

        var objects = new []{
            GameObject.Find("ConfettiBlastRainbow_0"),
            GameObject.Find("ConfettiBlastRainbow_1"),
            GameObject.Find("ConfettiBlastRainbow_2"),
        };
        _particleSystem[0] = objects[0].GetComponent<ParticleSystem>();
        _particleSystem[1] = objects[1].GetComponent<ParticleSystem>();
        _particleSystem[2] = objects[2].GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
         if (!_isRunnning) { return; }

        var angularSpeed =_rigidBody.angularVelocity.magnitude;
        if (angularSpeed  < 0.01f)
        {
            _particleSystem[0].Play();
            _particleSystem[1].Play();
            _particleSystem[2].Play();
            _isRunnning = false;
        }
    }
}
