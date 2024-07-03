using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridchecker : MonoBehaviour
{
    public GameObject grid;

    // Update is called once per frame
    void Update()
    {
        if (onizlemeobje.gridacik)
        {
            grid.SetActive(true);
        }

        else
        {
            grid.SetActive(false);
        }
    }
}
