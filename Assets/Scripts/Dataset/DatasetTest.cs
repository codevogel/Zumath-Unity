using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Dataset
{
    class DatasetTest : MonoBehaviour
    {
        public string text;

        public List<Data> questions = new List<Data>();


        private void Start()
        {

            using (StreamReader reader = new StreamReader(@"missions_plussommen_tot_100_export.csv"))
            {
                string text = reader.ReadToEnd();
                var values = text.Split(';');
                string missionId = "";
                int indexModifier0 = 0;
                int indexModifier1 = 0;
                int i = 0;
                while (i < values.Length)
                {
                    Data data = new Data();
                    if (data.Method1(ref values, ref i, ref missionId, ref indexModifier0, ref indexModifier1) && (i > 9))
                        questions.Add(data);
                }
            }
        }


    }
}