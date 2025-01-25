using Kevin;
using UnityEngine;


public class PlayerCamera : MonoBehaviour
{
    public static PlayerCamera instance;

    public Camera CameraObject;
    public PlayerManager player;

    [Header("CameraSettings")]
    private Vector3 cameraVelocity;
    private float cameraSmoothSpeed = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void HandAllCameraActions()
    {
        if (player != null)
        {
            // Follow the Player
            FollowTarget();
            // Rotate around the Player
            // Collide with Objects
        }

    }

    private void FollowTarget()
    {
        Vector3 targetCameraPostion = Vector3.SmoothDamp(transform.position, player.transform.position, ref cameraVelocity, cameraSmoothSpeed * Time.deltaTime);
        transform.position = targetCameraPostion;
    }
}


