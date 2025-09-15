using UnityEngine;

public class Inputmanager : MonobehaviourSingelton<Inputmanager>
{
    void Start()
    {

    }
    void Update()
    {

    }
    public Vector2 GetmousePosition()
    {
        return Input.mousePosition;
    }
    public bool GetLeftMouseButton()
    {
        return Input.GetMouseButton(0);
    }
}
//