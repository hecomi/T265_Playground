using UnityEngine;

public class TransformReceiver : MonoBehaviour
{
    [SerializeField]
    uOSC.uOscServer oscServer;

    [SerializeField]
    Transform target;

    [SerializeField]
    Transform camera;

    Vector3 latestT265Pos = Vector3.zero;
    Quaternion latestT265Rot = Quaternion.identity;
    Quaternion calibRot = Quaternion.identity;

    void Start()
    {
        oscServer.onDataReceived.AddListener(OnDataReceived);
    }

    void OnDataReceived(uOSC.Message message)
    {
        if (message.address == "/Pos")
        {
            var v = message.values;
            latestT265Pos = new Vector3((float)v[0], (float)v[1], (float)v[2]);
        }
        else if (message.address == "/Rot")
        {
            var v = message.values;
            latestT265Rot = new Quaternion((float)v[0], (float)v[1], (float)v[2], (float)v[3]);
        }
        else if (message.address == "/Reset")
        {
            var yawT265 = latestT265Rot.eulerAngles.y;
            var yawGo = camera.localEulerAngles.y;
            calibRot = Quaternion.Euler(0f, yawGo - yawT265, 0f);
        }

        UpdateTransform();
    }

    void UpdateTransform()
    {
        target.transform.position = calibRot * latestT265Pos;
    }
}
