﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD47.Core
{
    public class OldSceneLoader : MonoBehaviour
    {
        [SerializeField] [Range(0, 10)] float levelRestartDelay = 3f;

        public void LoadLevel(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void LoadLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextScene = ++currentSceneIndex % SceneManager.sceneCountInBuildSettings;

            SceneManager.LoadScene(nextScene);
        }
        void ReloadScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(currentSceneIndex);
        }

        public void ReloadLevel()
        {
            Invoke("ReloadScene", levelRestartDelay);
        }
    }

}