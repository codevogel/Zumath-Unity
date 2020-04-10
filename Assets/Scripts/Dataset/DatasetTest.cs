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
        public List<string> listAll = new List<string>();
        public List<string> listMisionId = new List<string>();
        public List<string> listId = new List<string>();
        public List<string> listQuestionType = new List<string>();
        public List<string> listQuestion = new List<string>();
        public List<string> listDidYouKnow = new List<string>();
        public List<string> listDifficulty = new List<string>();
        public List<string> listVerification = new List<string>();
        public List<string> listComments = new List<string>();
        public List<string> listAnswer = new List<string>();
        public string text;

        private void Start()
        {


            using (var reader = new StreamReader(@"missions_plussommen_tot_100_export.csv"))
            {

                while (!reader.EndOfStream)
                {
                    text = reader.ReadToEnd();
                    var values = text.Split(';');

                    int type = 0;



                    for (int i = 0; i < values.Length; i++)
                    {
                        if (values[i].Length != 0)
                        {
                            switch (type++)
                            {
                                case 0:
                                    listMisionId.Add(values[i]);
                                    break;
                                case 1:
                                    listId.Add(values[i]);
                                    break;
                                case 2:
                                    listQuestionType.Add(values[i]);
                                    break;
                                case 3:
                                    listQuestion.Add(values[i]);
                                    break;
                                case 4:
                                    listDidYouKnow.Add(values[i]);
                                    break;
                                case 5:
                                    listDifficulty.Add(values[i]);
                                    break;
                                case 6:
                                    listVerification.Add(values[i]);
                                    break;
                                case 7:
                                    listComments.Add(values[i]);
                                    break;
                                case 8:
                                    listAnswer.Add(values[i]);
                                    type = 0;
                                    break;
                            }
                        }
                    }

                    foreach (string value in values)
                    {
                        listAll.Add(value);
                    }

                }
            }
            //Read(listQuestions);
            //Read(listAll);
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