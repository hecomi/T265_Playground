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
        oscClient.Send("/Pos", p.x, p.y, p.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var r = target.rotation;
            oscClient.Send("/Reset", r.x, r.y, r.z, r.w);
        }
    }
}
