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
        public List<string> answers = new List<string>(); //if multiple answers exist the first one is correct


        public MissionData(ref string[] values, ref int i, ref string field1, ref int indexModifier0, ref int indexModifier1, out bool addToList)
        {
            for (; i < values.Length; i++)
            {
                switch ((i + indexModifier0 - indexModifier1) % 10)
                // the modifiers are needed to properly read the csv file because not all fields are properly divided
                {
                    case 0:
                        try
                        {
                            misionId = i >= 9 ? int.Parse(field1) : 0;
                            //converts the string to an integer except when it is the first object in the csv because that is the header.
                        }
                        catch (Exception e)
                        {
                            addToList = false; //sometimes a csv file contains null here and then we don't want to add it to a list.
                        }
                        break;
                    case 1:
                        id = i > 9 ? int.Parse(values[i]) : 0;
                        //converts the string to an integer except when it is the first object in the csv because that is the header.
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
                        //the answers field is sometimes filled with multiple answers when the question is multiple choice.
                        //the answers field always has the missionID of the next object stuck to it.
                        //this code checks if there are multiple answers and then puts all of them into an answers array
                        var temp0 = values[i];
                        var temp1 = temp0.Split('\n'); //for when a question has multiple answers.

                        //This question type has the correct answer hidden in the did you know and this puts the correct answer on the first spot in the answers list
                        if (questionType == "Fill in the blanks")
                        {
                            var temp2 = didYouKnow.Split('=');
                            temp2[0] += "=";
                            temp2[0] += temp2[1];
                            temp2[0] += "=";
                            answers.Add(new String (temp2[2].Where(c => char.IsDigit(c)).ToArray())); //makes sure the answer only contains numbers
                            didYouKnow = temp2[0];
                        }

                        answers.Add(temp1[0].Trim());
                        if (temp1.Length == 2) //temp1 only has a length of 2 when the last/only answer has been added to properties
                        {
                            field1 = temp1[1];
                            //the missionID of the next object is part of the answers field and this splits it so it can be entered there.
                            ++indexModifier0;
                            //the i needs this modifier because field1 so the switch keeps putting all the data into the right properties.
                            addToList = true; //this shows that all the data was read correctly and that it should be put into a list.
                            return;
                        }
                        ++indexModifier1; //the i needs this modifier because of the the possibility for mulltiple answers
                        break;
                }
            }
            addToList = false;//sometimes the csv file has data that should not be put into a list.
        }

    }

}

