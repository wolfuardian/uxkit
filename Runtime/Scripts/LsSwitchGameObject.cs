using System.Collections.Generic;
using UnityEngine;

namespace Eos.UxKit
{
    public class LsSwitchGameObject : MonoBehaviour
    {
        [SerializeField] private Settings _settings = new Settings();

        public Settings settings
        {
            get
            {
                return _settings;
            }
        }

        public void Switch(int index)
        {
            settings.gameObjects.ForEach(go => go.SetActive(false));
            if (index >= 0 && index < settings.gameObjects.Count)
            {
                settings.gameObjects[index].SetActive(true);
            }
            else
            {
                Debug.LogWarning("Index out of range: " + index);
            }
        }

        [System.Serializable]
        public class Settings
        {
            public List<GameObject> gameObjects = new List<GameObject>();
        }
    }
}
