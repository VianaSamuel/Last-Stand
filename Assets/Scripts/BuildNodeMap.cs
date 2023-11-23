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

    private int[] width = { 17, 160 };
    private int[] height = { 1, 119 };

    public IDictionary<Vector3, bool> walkablePositions = new Dictionary<Vector3, bool>();
    public IDictionary<Vector3, GameObject> nodeReference = new Dictionary<Vector3, GameObject>();
    public Dictionary<Vector3, string> obstacles = new Dictionary<Vector3, string>();

    // Start is called before the first frame update
    void Start()
    {
        InitializeNodeNetwork();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void InitializeNodeNetwork()
    {
        obstacles = getObstacles();

        for (int i = width[0]; i < width[1]; i++)
        {
            for (int j = height[0]; j < height[1]; j++)
            {
                Vector3 newPosition = new Vector3(i + 0.5f, j + 0.5f);

                if (obstacles.TryGetValue(newPosition, out _))
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
    Dictionary<Vector3, string> getObstacles()
    {
        Dictionary<Vector3, string> res = new Dictionary<Vector3, string>
        {
            //Fences
            { new Vector3(56.5f, 32.5f), null },
            { new Vector3(56.5f, 31.5f), null },
            { new Vector3(56.5f, 30.5f), null },
            { new Vector3(56.5f, 29.5f), null },
            { new Vector3(56.5f, 28.5f), null },
            { new Vector3(57.5f, 32.5f), null },
            { new Vector3(58.5f, 34.5f), null },
            { new Vector3(59.5f, 34.5f), null },
            { new Vector3(60.5f, 33.5f), null },
            { new Vector3(60.5f, 32.5f), null },
            { new Vector3(60.5f, 31.5f), null },
            { new Vector3(60.5f, 30.5f), null },
            { new Vector3(68.5f, 29.5f), null },
            { new Vector3(68.5f, 28.5f), null },
            { new Vector3(68.5f, 27.5f), null },
            { new Vector3(68.5f, 26.5f), null },
            { new Vector3(68.5f, 25.5f), null },

    

            // BENCHES

            { new Vector3(-9.5f, 3.5f), null },
            { new Vector3(-9.5f, 2.5f), null },
            { new Vector3(-9.5f, 1.5f), null },

            { new Vector3(-6.5f, 3.5f), null },
            { new Vector3(-6.5f, 2.5f), null },
            { new Vector3(-6.5f, 1.5f), null },

            { new Vector3(-12.5f, -0.5f), null },
            { new Vector3(-12.5f, -1.5f), null },
            { new Vector3(-12.5f, -2.5f), null },

            { new Vector3(-9.5f, -0.5f), null },
            { new Vector3(-9.5f, -1.5f), null },
            { new Vector3(-9.5f, -2.5f), null },

            { new Vector3(-6.5f, -0.5f), null },
            { new Vector3(-6.5f, -1.5f), null },
            { new Vector3(-6.5f, -2.5f), null },

            { new Vector3(-9.5f, -4.5f), null },
            { new Vector3(-9.5f, -5.5f), null },
            { new Vector3(-9.5f, -6.5f), null },

            { new Vector3(-6.5f, -4.5f), null },
            { new Vector3(-6.5f, -5.5f), null },
            { new Vector3(-6.5f, -6.5f), null },
        
            // BROKEN FOUNTAIN IN THE MIDDLE

            { new Vector3(-1.5f, -8.5f), null },
            { new Vector3(-0.5f, -8.5f), null },
            { new Vector3(0.5f, -8.5f), null },
            { new Vector3(-1.5f, -7.5f), null },
            { new Vector3(-0.5f, -7.5f), null },
            { new Vector3(0.5f, -7.5f), null },

            // BARRIER BLOCKING GRAVEYARD

            { new Vector3(6.5f, -4.5f), null },
            { new Vector3(6.5f, -3.5f), null },
            { new Vector3(6.5f, -2.5f), null },
            { new Vector3(6.5f, -1.5f), null },
            { new Vector3(6.5f, -0.5f), null },
            { new Vector3(6.5f, 1.5f), null },
            { new Vector3(6.5f, 2.5f), null },
            { new Vector3(6.5f, 3.5f), null },
            { new Vector3(6.5f, 4.5f), null },
            { new Vector3(6.5f, 5.5f), null },
            { new Vector3(6.5f, 6.5f), null },

            { new Vector3(7.5f, -4.5f), null },
            { new Vector3(7.5f, -3.5f), null },
            { new Vector3(7.5f, -2.5f), null },
            { new Vector3(7.5f, -1.5f), null },
            { new Vector3(7.5f, -0.5f), null },
            { new Vector3(7.5f, 1.5f), null },
            { new Vector3(7.5f, 2.5f), null },
            { new Vector3(7.5f, 3.5f), null },
            { new Vector3(7.5f, 4.5f), null },
            { new Vector3(7.5f, 5.5f), null },
            { new Vector3(7.5f, 6.5f), null },

            // TOMBSTONES AND ROCKS

            { new Vector3(9.5f, 2.5f), null },
            { new Vector3(9.5f, 3.5f), null },

            { new Vector3(11.5f, 1.5f), null },
            { new Vector3(12.5f, 1.5f), null },

            { new Vector3(11.5f, 2.5f), null },
            { new Vector3(12.5f, 2.5f), null },

            { new Vector3(9.5f, -0.5f), null },
            { new Vector3(9.5f, 0.5f), null },

            { new Vector3(12.5f, -0.5f), null },
            { new Vector3(12.5f, 0.5f), null },

            { new Vector3(15.5f, -0.5f), null },
            { new Vector3(15.5f, 0.5f), null },

            // MONUMENTS

            { new Vector3(9.5f, -4.5f), null },
            { new Vector3(9.5f, -3.5f), null },
            { new Vector3(9.5f, -2.5f), null },

            { new Vector3(12.5f, -4.5f), null },
            { new Vector3(12.5f, -3.5f), null },
            { new Vector3(12.5f, -2.5f), null },

            { new Vector3(15.5f, -4.5f), null },
            { new Vector3(15.5f, -3.5f), null },
            { new Vector3(15.5f, -2.5f), null },

        };

        return res;
    }
}