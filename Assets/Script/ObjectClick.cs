using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    public static bool  panelopen; // Inspector üzerinden atayacağınız panel

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol mouse tıklandığında
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Tıklanan objenin bu scripte sahip olup olmadığını kontrol et
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