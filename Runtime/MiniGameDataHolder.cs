using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Arbelos
{
    public class MiniGameDataHolder : MonoBehaviour
    {
        public enum MiniGameDataMode
        {
            LearningJourney,
            Quest,
            Persistent
        }

        [Tooltip("Use this to set where the data comes from")]
        public MiniGameDataMode dataMode;

        [Header("Learning journey Data")] 
        public string learningJourneyClassID;
        public string learningJourneyLessonID;
        public int learningJourneyMilestoneIndex;
        public string learningJourneyCollectionID;
        public string learningJourneyQuestionId;
        [Range(1,10)] public int learningJourneyMiniGameDifficulty;

        [Header("Quest Data")] 
        public int questID;
        public int questObjectiveID;
        public string questQuestionId;
        [Range(1,10)] public int questMiniGameDifficulty;
    }
}