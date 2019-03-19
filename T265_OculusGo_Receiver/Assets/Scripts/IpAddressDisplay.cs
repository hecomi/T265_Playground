using UnityEngine;

public class IpAddressDisplay : MonoBehaviour
{
    [SerializeField]
    TextMesh textMesh;

    void Start()
    {
        var hostName = System.Net.Dns.GetHostName();
        foreach (var address in System.Net.Dns.GetHostAddresses(hostName))
        {
            var ip = address.ToString();
            if (ip.StartsWith("192"))
            {
                textMesh.text = ip;
                break;
            }
        }
    }
}
