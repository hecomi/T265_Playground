using UnityEngine;

public class TransformReceiver : MonoBehaviour
{
    [SerializeField]
    uOSC.uOscServer oscServer;

    [SerializeField]
    Transform target;

    [SerializeField]
    Transform camera;

    Vector3 t265Pos = Vector3.zero;
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
            t265Pos = new Vector3((float)v[0], (float)v[1], (float)v[2]);
        }
        else if (message.address == "/Reset")
        {
            var t265Yaw = (float)message.values[0];
            var goYaw = camera.localEulerAngles.y;
            calibRot = Quaternion.Euler(0f, goYaw - t265Yaw, 0f);
        }

        UpdateTransform();
    }

    void UpdateTransform()
    {
        target.transform.position = calibRot * t265Pos;
    }
}
