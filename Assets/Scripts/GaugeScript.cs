using UnityEngine;
using UnityEngine.UI;

public class GaugeScript : MonoBehaviour
{
    private Rigidbody _bottleRigidBody;
    private int _count;

    // Start is called before the first frame update
    void Start()
    {
        var bottle = GameObject.Find("Bottle");
        _bottleRigidBody = bottle != null && bottle.TryGetComponent<Rigidbody>(out var rigidbody) ? rigidbody : null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetComponent<Image>(out var image)) { return; }

        ++_count;
        if (360 < _count)
        {
            _count = 0;
        }
        _count = 40;

        var angularSpeed =_bottleRigidBody.angularVelocity.magnitude / 2.0f;
        image.fillAmount = 0.25f + Mathf.Clamp((float)angularSpeed, 0.0f, 0.15f);//Mathf.Sin(Mathf.Deg2Rad * (float)_count);

        if (_bottleRigidBody is null) { throw new System.Exception(); }
        var currentRotation = image.rectTransform.rotation.eulerAngles;
        
        var angle = ((int)_bottleRigidBody.transform.rotation.eulerAngles.z) / 90 * 90;
        var nextRotatiuon = new Vector3(currentRotation.x, currentRotation.y, -90.0f + angle);
        image.rectTransform.rotation = Quaternion.Euler(nextRotatiuon);
    }
}
