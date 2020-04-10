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
        public string verification;
        public string comments;
        public string answer;


        public bool Method1(ref string[] values, ref int i)
        {
            for (; i < values.Length; i++)
            {
                switch (i % 9)
                {
                    case 0:
                        misionId = values[i];
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
                        verification = values[i];
                        break;
                    case 7:
                        comments = values[i];
                        break;
                    case 8:
                        answer = values[i];
                        return true;
                }
            }
            return false;
        }
        
    }
    
}

