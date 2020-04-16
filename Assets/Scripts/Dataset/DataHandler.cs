using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Dataset
{
    class DataHandler : MonoBehaviour
    {
        public DataReader dataReader;

        public string display;

        private void Start()
        {
            dataReader = new DataReader();
        }

        private void Update()
        {
            display = DataHolder.GetRandomMission().questionType; //for testing purposes
        }
    }
}
