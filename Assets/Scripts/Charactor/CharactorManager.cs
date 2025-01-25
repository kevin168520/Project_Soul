using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Kevin
{
    public class CharactorManager : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}

