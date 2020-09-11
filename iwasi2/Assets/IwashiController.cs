using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IwashiController : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 moveDirection;
    public float rotateAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 左に移動
        if (Input.GetKey(KeyCode.LeftArrow))
        {
    
      
            this.transform.localPosition += new Vector3(-1*moveSpeed, 0, 0);
            this.transform.localRotation = new Quaternion(0, -1*rotateAngle, 0, 1);
        }
        // 右に移動
        else if (Input.GetKey(KeyCode.RightArrow))
        {
    
            
            this.transform.localPosition += new Vector3(moveSpeed, 0, 0);
            this.transform.localRotation = new Quaternion(0, rotateAngle, 0, 1);
        }
        else
        {
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
