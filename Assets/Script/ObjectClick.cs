using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    public static bool  panelopen; // Inspector üzerinden atayacaðýnýz panel

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol mouse týklandýðýnda
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Týklanan objenin bu scripte sahip olup olmadýðýný kontrol et
                if (hit.transform == this.transform)
                {
                    Debug.Log("test");
                    // Paneli aktif et
                    panelopen = false;
                }
            }
        }
    }
}