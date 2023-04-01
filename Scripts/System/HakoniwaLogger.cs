using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HakoniwaCity
{
    namespace Log
    {
        public class HakoniwaLogger :MonoBehaviour
        {
            private static string _message = "";

            public static void Log(string message)
            {
                _message += message + "\n";
            }

            private static void print()
            {
                if (_message.Length == 0) return;

                Debug.Log(_message);
                _message = "";
            }

            public void Update()
            {
                HakoniwaLogger.print();
            }
        }
    }
}
