using UnityEngine;

namespace UnityCore
{
    namespace Audio
    {
        public class AudioController : MonoBehaviour
        {
            public static AudioController Instance;

            public bool debug;

            private void Log(string msg)
            {
                if (!debug)
                {
                    return;
                }
                Debug.Log("Audio Controller: " + msg);
            }

            private void logWarning(string msg)
            {
                if (!debug)
                {
                    return;
                }
                Debug.LogWarning("Audio Controller: " + msg);
            }
        }
    }
}



