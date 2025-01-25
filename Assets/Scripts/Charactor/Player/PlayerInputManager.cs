using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Kevin
{
    public class PlayerInputManager : MonoBehaviour
    {
        public static PlayerInputManager Instance;

        PlayerControls playControls;

        [SerializeField] Vector2 movement;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
           
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            SceneManager.activeSceneChanged += OnSceneChange;

            Instance.enabled = false;

        }

        private void OnEnable()
        {
            if (playControls == null)
            {
                playControls = new PlayerControls();

                playControls.PlayerMovement.Movement.performed += i => movement = i.ReadValue<Vector2>();
            }

            playControls.Enable();
        }

        private void OnDestroy()
        {
            SceneManager.activeSceneChanged -= OnSceneChange;
        }


        private void OnSceneChange(Scene oldScene, Scene newScene)
        {
            if (newScene.buildIndex == WorldSaveGameManager.instance.GetWorldSceneIndex())
            {
                Instance.enabled = true;
            }
            else
            {
                Instance.enabled = false;
            }
        }
    }

}
