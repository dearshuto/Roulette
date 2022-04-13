using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRouLette : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private GameObject _sphere;

    public void Run()
    {
        if (_rigidBody != null)
        {
            _rigidBody.angularVelocity = new Vector3(0.0f, 0.0f, 10.0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {        
        var bottle = GameObject.Find("Bottle");
        if (!bottle.TryGetComponent<Rigidbody>(out var rigidBody)) { throw new System.Exception(); }
        _rigidBody = rigidBody;
    }

    // Update is called once per frame
    void Update()
    {
        if (_rigidBody is null) { return; }
        if (_sphere is null) { return; }

        var eulerAngles = _rigidBody.rotation.eulerAngles;
        if (0 <= eulerAngles.z && eulerAngles.z < 90)
        {
            _sphere.transform.position = new Vector3(164, 340, _sphere.transform.position.z);
        }
        else if (90 <= eulerAngles.z && eulerAngles.z <= 180)
        {
            _sphere.transform.position = new Vector3(164, 160, _sphere.transform.position.z);
        }
        else if (180 <= eulerAngles.z && eulerAngles.z < 270)
        {
            _sphere.transform.position = new Vector3(380, 160, _sphere.transform.position.z);
        }
        else
        {
            _sphere.transform.position = new Vector3(380, 340, _sphere.transform.position.z);
        }
    }
}
