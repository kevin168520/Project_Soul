using UnityEngine;


namespace Kevin
{
    public class PlayerManager : CharactorManager
    {
        PlayerLocomotionManager playerLocomotionManager;

        protected override void Awake()
        {
            base.Awake();

            // Do more stuff only for the Player

            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        }

        protected override void Update()
        {
            base.Update();

            // If do not own this gameobject, do not ctrl or edit it
            if (!IsOwner)
                return;
            

            // handle Movement
            playerLocomotionManager.HandleAllMovement();
        }
    }

}
