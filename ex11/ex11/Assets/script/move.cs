using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class move : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vb;
    enum direction {top, bottom, left,right};
    public GameObject pikaqiu;
    static int num = 0;
    Vector3 newPosition;
    void Start()
    {
        //注册事件处理器
        VirtualButtonBehaviour vbb = vb.GetComponent<VirtualButtonBehaviour>();
        //在虚拟按钮中注册TrackableBehaviour事件

        if (vbb)
        {
            Debug.Log("register OK!");
            vbb.RegisterEventHandler(this);
        }
    }


    public void  OnButtonPressed(VirtualButtonBehaviour vb)
    {

        Debug.Log("Pressed");
        pikaqiu.transform.localPosition += new Vector3(0f, 0.1f, 0f);
        num++;
        Debug.Log(num - 1);
    }

   public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("released");
    }

}
