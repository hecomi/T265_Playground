using UnityEngine;

public class TransformOscReceiver : MonoBehaviour
{
    [SerializeField]
    uOSC.uOscServer oscServer;

    [SerializeField]
    Transform target;

    void Start()
    {
        oscServer.onDataReceived.AddListener(OnDataReceived);
    }

    void OnDataReceived(uOSC.Message message)
    {
        if (message.address != "/Position") return;

        var x = (float)message.values[0];
        var y = (float)message.values[1];
        var z = (float)message.values[2];

        target.transform.position = new Vector3(x, y, z);
    }
}
