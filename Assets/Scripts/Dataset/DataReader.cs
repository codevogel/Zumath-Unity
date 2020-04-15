using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Dataset
{
    class DataReader
    {
        public DataReader()
        {
            Init();
        }

        public void Init()
        {
            DataHolder.Init(Read());
        }

        private List<MissionData> Read()
        {
            List<MissionData> missionDatas= new List<MissionData>();
            using (StreamReader reader = new StreamReader(@"missions_plussommen_tot_100_export.csv"))
            {
                string text = reader.ReadToEnd();
                var values = text.Split(';');
                string missionId = "";
                int indexModifier0 = 0;
                //the i needs this modifier because the because not all lines are sepperated properly in the csv
                //so this makes sure the switch in the constructor keeps putting all the data into the right properties.
                int indexModifier1 = 0; 
                //the i needs this modifier because of the the possibility for mulltiple answers
                int i = 0;
                while (i < values.Length)
                {
                    bool addToList;
                    MissionData data = new MissionData(ref values, ref i, ref missionId, ref indexModifier0, ref indexModifier1, out addToList);
                    //ref allows the program to store the changes to the variable
                    if (addToList && (i > 9))
                    {
                        missionDatas.Add(data);
                    }
                }
            }
            return missionDatas;
        }


    }
}