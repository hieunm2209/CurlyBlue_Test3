using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private static FollowCamera _instance = null;

    public static FollowCamera Instance
    {
        get
        {
            return _instance;
        }
    }

    public Transform target = null;

    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }

    void Awake()
    {
        _instance = this;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position;
            var labelNames = Object.FindObjectsByType<PlayerNameLabel>(FindObjectsSortMode.None);
            Camera camera = Camera.main;
            foreach (var labelName in labelNames)
            {
                labelName.transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position);
            }
        }
    }
}
