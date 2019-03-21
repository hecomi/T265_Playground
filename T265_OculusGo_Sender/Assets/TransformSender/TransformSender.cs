using UnityEngine;

public class TransformSender : MonoBehaviour
{
    [SerializeField]
    uOSC.uOscClient oscClient;

    [SerializeField]
    Transform target;

    void Update()
    {
        var p = target.position;
        var r = target.rotation;
        oscClient.Send("/Pos", p.x, p.y, p.z);
        oscClient.Send("/Rot", r.x, r.y, r.z, r.w);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            oscClient.Send("/Reset");
        }
    }
}
