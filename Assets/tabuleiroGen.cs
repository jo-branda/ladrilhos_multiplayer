using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabuleiroGen : MonoBehaviour
{
    public Transform tilePrefab;
    public Vector2 tab_size;
    [Range(0,1)]
    public float outline;
    private void Start()
    {
        GenTabuleiro();
    }
    public void GenTabuleiro()
    {
        for (int x = 0; x < tab_size.x; x++){
            for (int y = 0; y < tab_size.y; y++)
            {
                Vector3 tilePos = new Vector3(x + 0.5f - 5f, 0, y + 0.5f - 5f);
                Transform newTile = Instantiate(tilePrefab, tilePos, Quaternion.Euler(Vector3.right * 90)) as Transform;
                newTile.localScale = Vector3.one * (1 - outline);
            }
        }
    }
}
