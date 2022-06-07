using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Vector3 angles = transform.localEulerAngles;
        angles.y = Random.Range(0f, 360f);
        transform.localEulerAngles = angles;
    }
}
