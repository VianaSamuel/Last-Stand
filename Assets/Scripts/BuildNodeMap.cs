using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildNodeMap : MonoBehaviour
{
    // map dimentions
    // (-17, 7  )-(19, 7  )
    //     |         |
    // (-17, -12) (19, -12)

    // x = 36
    // y = 19

    private int[] width = { -17, 19 };
    private int[] height = { -12, 7 };

    public IDictionary<Vector3, bool> walkablePositions = new Dictionary<Vector3, bool>();
    public IDictionary<Vector3, GameObject> nodeReference = new Dictionary<Vector3, GameObject>();
    public Dictionary<Vector3, string> obstacles = new Dictionary<Vector3, string>();

    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> positions = PropRandomizer.generatedObjectPositions;
        InitializeNodeNetwork();
    }

    // Update is called once per frame
    void Update()
    {   

    }
    void InitializeNodeNetwork()
    {
        List<Vector3> obstaclePositions = PropRandomizer.generatedObjectPositions; // Use a lista de obstáculos gerada

        for (int i = width[0]; i < width[1]; i++)
        {
            for (int j = height[0]; j < height[1]; j++)
            {
                Vector3 newPosition = new Vector3(i + 0.5f, j + 0.5f);

                if (obstaclePositions.Contains(newPosition))
                {
                    walkablePositions.Add(new KeyValuePair<Vector3, bool>(newPosition, false));
                }
                else
                {
                    walkablePositions.Add(new KeyValuePair<Vector3, bool>(newPosition, true));
                }

                nodeReference.Add(newPosition, null);
            }
        }
    }

}