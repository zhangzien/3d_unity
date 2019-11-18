using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AreaCollide : MonoBehaviour
{
    public int sign;
    public delegate void CanFollow(int state,bool isEnter);
    public static event CanFollow canFollow;
    public delegate void AddScore();
    public static event AddScore addScore ;
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("enter the position:" + sign);
        Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.tag == "Player")
        {
            canFollow(sign,true);
            Debug.Log("enter");
        }
        else
        {
            Debug.Log("false");
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("exit the position:" + sign);
        if (collider.gameObject.tag == "Player")
        {
            canFollow(sign,false);
            addScore();
        }
        else
        {
            Debug.Log("false");
        }
    }
}