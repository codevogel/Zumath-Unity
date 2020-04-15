using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Dataset
{
    class MissionData
    {
        public int misionId;
        public int id;
        public string questionType;
        public string question;
        public string didYouKnow;
        public string difficulty;
        public string displayType;
        public string verification;
        public string comments;
        public List<string> answers= new List<string>();


        public MissionData(ref string[] values, ref int i, ref string veld1, ref int indexModifier0, ref int indexModifier1, out bool addToList)
        {
            for (; i < values.Length; i++)
            {
                switch ((i+indexModifier0-indexModifier1) % 10) // needed to properly read the csv file
                {
                    case 0:
                        try
                        {
                            misionId = i >= 9 ? int.Parse(veld1) : 0; 
                        } catch (Exception e)
                        {
                            addToList = false; //sometimes a csv file contains null here and then we don't want to add it to a list.
                        }
                        break;
                    case 1:
                        id = i>9 ? int.Parse(values[i]) : 0;
                        break;
                    case 2:
                        questionType = values[i];
                        break;
                    case 3:
                        question = values[i];
                        break;
                    case 4:
                        didYouKnow = values[i];
                        break;
                    case 5:
                        difficulty = values[i];
                        break;
                    case 6:
                        displayType = values[i];
                        break;
                    case 7:
                        verification = values[i];
                        break;
                    case 8:
                        comments = values[i];
                        break;
                    default:
                        var temp0 = values[i];
                        var temp1 = temp0.Split('\n'); //for when a question has multiple answers.
                        answers.Add(temp1[0].Trim());
                        if (temp1.Length == 2)
                        {
                            veld1 = temp1[1];
                            ++indexModifier0;
                            addToList = true;
                            return;
                        }
                        ++indexModifier1;
                        break;
                }
            }
            addToList = false;
        }
        
    }
    
}

