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

        image.fillAmount = 0.25f;//Mathf.Sin(Mathf.Deg2Rad * (float)_count);

        if (_bottleRigidBody is null) { throw new System.Exception(); }
        var currentRotation = image.rectTransform.rotation.eulerAngles;
        var nextRotatiuon = new Vector3(currentRotation.x, currentRotation.y, 220.0f + _bottleRigidBody.transform.rotation.eulerAngles.z);
        image.rectTransform.rotation = Quaternion.Euler(nextRotatiuon);
    }
}
