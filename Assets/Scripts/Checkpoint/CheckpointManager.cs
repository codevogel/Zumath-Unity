using Assets.Scripts.Dataset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Checkpoint
{
    static class CheckpointManager

    {
        private static MissionData currentQuestion;
        private static string answer = "";

        public static void Start()
        {
                currentQuestion = DataHolder.GetRandomMission();
        }

        public static MissionData GetCurrentQuestion()
        {
            return currentQuestion;
        }

        public static bool CheckAnswer()
        {
            return answer.Equals(currentQuestion.answers[0]);
        }

        public static void SetAnswer(String answer)
        {
            CheckpointManager.answer = answer;
        }

        
    }
}
