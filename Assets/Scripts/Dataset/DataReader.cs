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
                int indexModifier1 = 0;
                int i = 0;
                while (i < values.Length)
                {
                    bool addToList;
                    MissionData data = new MissionData(ref values, ref i, ref missionId, ref indexModifier0, ref indexModifier1, out addToList);
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