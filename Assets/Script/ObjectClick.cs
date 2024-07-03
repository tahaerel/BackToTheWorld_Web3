using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    public static bool  panelopen; // Inspector �zerinden atayaca��n�z panel

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol mouse t�kland���nda
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // T�klanan objenin bu scripte sahip olup olmad���n� kontrol et
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