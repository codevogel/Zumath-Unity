using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Dataset
{
    static class DataHolder
    {
        private static MissionData[] dataArray;

        private static void Load(List<MissionData> missionDatas)
        {
            dataArray = new MissionData[missionDatas.Count];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataArray[i] = missionDatas.ElementAt(i); //fils the array with all of the information from the list.
            }
        }

        public static bool Init(List<MissionData> missionDatas)
        {
            Load(missionDatas);
            return true;
        }

        //returns a random mission from the array.
        public static MissionData GetRandomMission()
        {
            int lowerBound = 0;
            int upperBound = dataArray.Length;

            int index = UnityEngine.Random.Range(lowerBound, upperBound);

            //the select questiontype requires pictures that we don't have
            while (dataArray[index].questionType == "select")
            {
                index = UnityEngine.Random.Range(lowerBound, upperBound); //this sure a select is never returned from this method.
            }

            return dataArray[index];
        }
    }
}
