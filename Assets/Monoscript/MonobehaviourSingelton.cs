using UnityEngine;
public class MonobehaviourSingelton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindFirstObjectByType<T>();
            }
            return _instance;

        }
        private set
        {
            _instance = value;
        }
    }
    private static T _instance;
}