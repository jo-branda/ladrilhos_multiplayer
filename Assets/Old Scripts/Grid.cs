using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private float size = 1f;


    public Vector3 Cubo_in_place(Vector3 position)
    {


        position -= transform.position;

        int xcount = Mathf.RoundToInt(position.x / size);
        //int ycount = Mathf.RoundToInt(position.y / size);
        int zcount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3(
            (float)xcount * size + .5f,
            (float).25f,
            (float)zcount * size + .5f);

        result += transform.position;
        return result;
    }
}
