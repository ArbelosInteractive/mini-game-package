using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Arbelos
{
    [CustomEditor(typeof(MiniGameDataHolder))]
    public class MiniGameDataHolderInspector : Editor
    {
        public VisualTreeAsset m_InspectorXML;

        public override VisualElement CreateInspectorGUI()
        {
            // Create a new VisualElement to be the root of our inspector UI
            VisualElement myInspector = new VisualElement();

            //Load and clone a visual tree from UXML
            m_InspectorXML.CloneTree(myInspector);

            EnumField dataMode = myInspector.Q<EnumField>("dataMode");

            //get the current data holder and display the initial inspector
            MiniGameDataHolder miniGameDataHolder = target as MiniGameDataHolder;
            EvaluateDataMode(miniGameDataHolder.dataMode, myInspector);

            dataMode.RegisterCallback<ChangeEvent<System.Enum>>((evt =>
            {
                EvaluateDataMode(evt.newValue, myInspector);
            }));

            // Return the finished inspector UI
            return myInspector;
        }

        public void ToggleLearningJourneyInspector(VisualElement myInspector, DisplayStyle style)
        {
            myInspector.Q("learningJourneyClassID").style.display = style;
            myInspector.Q("learningJourneyLessonID").style.display = style;
            myInspector.Q("learningJourneyMilestoneIndex").style.display = style;
            myInspector.Q("learningJourneyCollectionID").style.display = style;
            myInspector.Q("learningJourneyQuestionID").style.display = style;
        }

        public void ToggleQuestInspector(VisualElement myInspector, DisplayStyle style)
        {
            myInspector.Q("questID").style.display = style;
            myInspector.Q("questObjectiveID").style.display = style;
            myInspector.Q("questQuestionID").style.display = style;
        }

        public void EvaluateDataMode(System.Enum newValue, VisualElement myInspector)
        {
            switch (newValue)
            {
                case MiniGameDataHolder.MiniGameDataMode.LearningJourney:
                    {
                        //hide quest fields
                        ToggleQuestInspector(myInspector, DisplayStyle.None);

                        //show learning journey fields
                        ToggleLearningJourneyInspector(myInspector, DisplayStyle.Flex);

                        break;
                    }
                case MiniGameDataHolder.MiniGameDataMode.Quest:
                    {
                        //hide learning journey fields
                        ToggleLearningJourneyInspector(myInspector, DisplayStyle.None);


                        //show quest fields
                        ToggleQuestInspector(myInspector, DisplayStyle.Flex);

                        break;
                    }
                case MiniGameDataHolder.MiniGameDataMode.Persistent:
                    {
                        //hide learning journey fields
                        ToggleLearningJourneyInspector(myInspector, DisplayStyle.None);
                        //hide quest fields
                        ToggleQuestInspector(myInspector, DisplayStyle.None);

                        break;
                    }
            }
        }

    }
}