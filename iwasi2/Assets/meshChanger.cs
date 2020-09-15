using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
        Vector3[] vertices = meshFilter.mesh.vertices;
        float center;
        for(int i = 0; i < vertices.Length; i++)
        {
            
        }
        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateBounds();
        meshFilter.mesh.RecalculateNormals();
    }

    (Vector3,Vector3) returnMinMax(Vector3[] vec)
    {
        int mx, my, mz, Mx, My, Mz;
        foreach(Vector3 ve in vec)
        {
            mx = Mathf.Min(mx, ve.x);
            my = Mathf.Min(my, ve.y);
            mx = Mathf.Min(mz, ve.z);
            Mx = Mathf.Min(Mx, ve.x);
            My = Mathf.Min(My, ve.y);
            Mz = Mathf.Min(Mz, ve.z);
        }
        Vector
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
