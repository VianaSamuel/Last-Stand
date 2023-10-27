using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;

    // Lista para armazenar as coordenadas dos objetos gerados aleatoriamente.
    public static List<Vector3> generatedObjectPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        spawnProps();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void spawnProps()
    {
        foreach (GameObject sp in propSpawnPoints)
        {
            int rand = Random.Range(0, propPrefabs.Count);
            GameObject prop = Instantiate(propPrefabs[rand], sp.transform.position, Quaternion.identity);
            prop.transform.parent = sp.transform;

            // Adicione a posição do objeto gerado à lista.
            generatedObjectPositions.Add(prop.transform.position);
        }
    }
}
