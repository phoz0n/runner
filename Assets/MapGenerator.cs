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
    private List<GameObject> InstantiatedRoads;
    // Start is called before the first frame update
    void Start()
    {
        InstantiatedRoads = new List<GameObject>();

        for (int i = 0; i < SegmentQuantity; i++)
        {
            InstantiatedRoads.Add(Instantiate(roadSegment, new Vector3(0, 0, i * 10), Quaternion.identity));
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

            InstantiatedRoads.Add(Instantiate(roadSegment, new Vector3(0, 0, LastZroadPosition + 10), Quaternion.identity));
        }

    }
}
