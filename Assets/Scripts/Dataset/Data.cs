using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Dataset
{
    class Data
    {
        public string misionId;
        public string id;
        public string questionType;
        public string question;
        public string didYouKnow;
        public string difficulty;
        public string displayType;
        public string verification;
        public string comments;
        public List<string> answers= new List<string>();


        public bool Method1(ref string[] values, ref int i, ref string veld1, ref int indexModifier0, ref int indexModifier1)
        {
            for (; i < values.Length; i++)
            {
                switch ((i+indexModifier0-indexModifier1) % 10)
                {
                    case 0:
                        misionId = veld1;
                        break;
                    case 1:
                        id = values[i];
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
                        var temp1 = temp0.Split('\n');
                        answers.Add(temp1[0].Trim());
                        if (temp1.Length == 2)
                        {
                            veld1 = temp1[1];
                            ++indexModifier0;
                            return true;
                        }
                        ++indexModifier1;
                        break;
                }
            }
            return false;
        }
        
    }
    
}

