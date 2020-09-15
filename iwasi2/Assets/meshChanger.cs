using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshChanger : MonoBehaviour
{
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
        Vector3[] vertices = meshFilter.mesh.vertices;
        Debug.Log(vertices.Length);
        float center;
        var (minV,maxV) = returnMinMax(vertices);
        center = (maxV.x-minV.x)/2;


        for(int i = 0; i < vertices.Length; i++)
        {
            if(Mathf.Abs(vertices[i].x-center)<=radius){
                float cos = Mathf.Abs(vertices[i].x-center)/radius;
                float sin = Mathf.Sqrt(1-Mathf.Pow(cos,2));
                //知りたいのはsinθ
                vertices[i].y -= sin*radius;
            }
        }
        for(int i=0;i<vertices.Length;i++){
            vertices[i].y += Random.value*0.5f-0.25f;
        }

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateBounds();
        meshFilter.mesh.RecalculateNormals();



        MeshCollider meshcollider = this.gameObject.GetComponent<MeshCollider>();
        if(!meshcollider) meshcollider = this.gameObject.AddComponent<MeshCollider>();
    }

    (Vector3,Vector3) returnMinMax(Vector3[] vec)
    {
        float mx, my, mz, Mx, My, Mz;
        mx = 0;
        my = 0;
        mz = 0;
        Mx = 0;
        My = 0;
        Mz = 0;
        foreach(Vector3 ve in vec)
        {
            mx = Mathf.Min(mx, ve.x);
            my = Mathf.Min(my, ve.y);
            mx = Mathf.Min(mz, ve.z);
            Mx = Mathf.Min(Mx, ve.x);
            My = Mathf.Min(My, ve.y);
            Mz = Mathf.Min(Mz, ve.z);
        }
        Vector3 minV = new Vector3(mx,my,mz);
        Vector3 maxV = new Vector3(Mx,My,Mz);
        return (minV,maxV);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
