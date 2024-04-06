using UnityEngine;
using System.Collections;

public class CoroutineHandler : MonoBehaviour
{
    private static CoroutineHandler _instance;
    public static CoroutineHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CoroutineHandler>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    _instance = obj.AddComponent<CoroutineHandler>();
                }
            }
            return _instance;
        }
    }

    // This method is used to start a coroutine from anywhere in the code.
    public void StartRoutine(IEnumerator routine)
    {
        StartCoroutine(routine);
    }
}
