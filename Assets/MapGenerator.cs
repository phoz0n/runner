using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject roadSegment;
    public int SegmentQuantity = 5;
    public float Speed = 5f;
    public GameObject bonus;
    private List<GameObject> InstantiatedRoads;
    public int chance = 50;
    // Start is called before the first frame update
    void Start()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;
        InstantiatedRoads = new List<GameObject>();

        for (int i = 0; i < SegmentQuantity; i++)
        {
            SpawnRoad(i * 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> Roads2delete = new List<GameObject>();

        foreach (GameObject road in InstantiatedRoads)
        {
            road.transform.Translate(0, 0, -Speed * Time.deltaTime);

            if (road.transform.position.z <= -10)
            {
                Roads2delete.Add(road);
            }

        }

        foreach (GameObject road in Roads2delete)
        {
            InstantiatedRoads.Remove(road);
            Destroy(road);

            GameObject lastRoad = InstantiatedRoads[InstantiatedRoads.Count - 1];
            float LastZroadPosition = lastRoad.transform.position.z;

            SpawnRoad(LastZroadPosition + 10);
        }

    }
    void SpawnRoad(float zPosition)
    {
        GameObject go = Instantiate(roadSegment, new Vector3(0, 0, zPosition), Quaternion.identity);
        InstantiatedRoads.Add(go);
        int random = Random.Range(0, 100);
        if (random <= chance)
        {
            int randomGrid = Random.Range(0, 5);
            float gridPosition = 0.8f * randomGrid - 1.6f;

            GameObject bo = Instantiate(bonus, go.transform, false);
            bo.transform.localPosition = new Vector3(gridPosition, bonus.transform.localScale.y / 2, 0);
        }
    }
}
