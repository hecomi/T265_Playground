using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    int width = 10;

    [SerializeField]
    int depth = 10;

    [SerializeField]
    int height = 4;

    void Start()
    {
        for (int x = -width / 2; x <= width / 2; ++x)
        {
            for (int y = -height / 2; y <= height / 2; ++y)
            {
                for (int z = -depth / 2; z <= depth / 2; ++z)
                {
                    var pos = new Vector3(x, y, z);
                    Instantiate(prefab, pos, Quaternion.identity, transform);
                }
            }
        }
    }
}
