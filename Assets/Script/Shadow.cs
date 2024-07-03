using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public GameObject shadowPlane;
    public Transform player;
    public LayerMask shadowlayer;
    public float shadowRadius = 10f;

    private float radiuscircle { get { return shadowRadius * shadowRadius; } }
    private Mesh mesh;
    private Vector3[] vectices;
    private Color[] colors;
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(transform.position, player.position - transform.position);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit, 1000, shadowlayer, QueryTriggerInteraction.Collide))
        {
            for (int i = 0; i < vectices.Length; i++)
            {
                Vector3 v = shadowPlane.transform.TransformPoint(vectices[i]);
                float mesafe = Vector3.SqrMagnitude(v - hit.point);
                if (mesafe > radiuscircle)
                {
                    float alpha = Mathf.Min(colors[i].a, mesafe / radiuscircle);
                    colors[i].a = alpha;
                }
            }
            UpdateColors();
        }
    }




    public void UpdateColors()
    {
        mesh.colors = colors;
    }
    private void Initialize()
    {
        mesh = shadowPlane.GetComponent<MeshFilter>().mesh;
        vectices = mesh.vertices;
        colors = new Color[vectices.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.black;
        }
        UpdateColors();
    }
}
