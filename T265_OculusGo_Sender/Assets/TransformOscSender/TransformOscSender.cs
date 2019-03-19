using UnityEngine;

public class TransformOscSender : MonoBehaviour
{
    [SerializeField]
    uOSC.uOscClient oscClient;

    [SerializeField]
    Transform target;

    [SerializeField]
    Vector3 offset = Vector3.zero;

    bool isStarted = false;
    string ip = "192.168.0.1";
    string port = "3333";

    void OnGUI()
    {
        var labelStyle = new GUIStyle(GUI.skin.label);
        var fieldStyle = new GUIStyle(GUI.skin.textField);
        var buttonStyle = new GUIStyle(GUI.skin.button);
        labelStyle.fontSize = fieldStyle.fontSize = buttonStyle.fontSize = 24;

        GUI.Label(new Rect(10, 10, 80, 36), "IP", labelStyle);
        ip = GUI.TextField(new Rect(100, 10, 240, 36), ip, fieldStyle);

        GUI.Label(new Rect(10, 50, 80, 36), "PORT", labelStyle);
        port = GUI.TextField(new Rect(100, 50, 240, 36), port, fieldStyle);

        if (GUI.Button(new Rect(10, 90, 100, 36), "START", buttonStyle))
        {
            Debug.Log("Start");
            oscClient.address = ip;
            oscClient.port = int.Parse(port);
            oscClient.enabled = true;
            isStarted = true;
        }
    }

    void Update()
    {
        if (!isStarted) return;

        var p = target.position;
        oscClient.Send("/Position", p.x, p.y, p.z);
    }
}
