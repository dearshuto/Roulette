using UnityEngine;

public class PointerObject : MonoBehaviour
{
    private Rigidbody _rigidBody;

    public void Run()
    {
    }

    // Start is called before the first frame update
    void Start()
    {        
        if (!TryGetComponent<Rigidbody>(out var rigidBody)) { throw new System.Exception(); }
        _rigidBody = rigidBody;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
