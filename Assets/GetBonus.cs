using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBonus : MonoBehaviour
{
    public Transform CubeStack;
    private int nbCube = 0;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        other.gameObject.transform.parent = gameObject.transform;
        other.gameObject.transform.localPosition = CubeStack.localPosition;

        float Z = other.gameObject.transform.localScale.z;
        other.gameObject.transform.Translate(0, Z / 2 + nbCube++ * Z, 0, Space.Self);
    }
}
