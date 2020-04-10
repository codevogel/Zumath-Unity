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
                
                int i = 0;
                while (i < values.Length)
                {
                    Data data = new Data();
                    if (data.Method1(ref values, ref i))
                        questions.Add(data);
                }
            }
        }



        private void Update()
        {
            //Read(listAll);
        }

        public void Read(List<string> list)
        {
            foreach (string value in list)
            {
                print(value);
            }
        }


    }
}