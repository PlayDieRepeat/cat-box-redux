using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD47.Core
{
    public class EventHandler : MonoBehaviour
    {
        OldSceneLoader _objOldSceneLoader;

        // Start is called before the first frame update
        void Start()
        {
            _objOldSceneLoader = FindObjectOfType<OldSceneLoader>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void callReloadLevel()
        {
            _objOldSceneLoader.ReloadLevel();
        }
    }
}
