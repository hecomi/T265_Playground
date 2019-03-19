using UnityEngine;

public class PositionSender : MonoBehaviour
{
    [SerializeField]
    uOSC.uOscClient oscClient;

    [SerializeField]
    Transform target;

    void Update()
    {
        var p = target.position;
        oscClient.Send("/Position", p.x, p.y, p.z);
    }
}
