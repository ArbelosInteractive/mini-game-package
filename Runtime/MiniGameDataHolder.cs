using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Arbelos
{
    public class MiniGameDataHolder : MonoBehaviour
    {
        [SerializeField] private bool isPersistent; //if the mini game will live in the world, mark this true.

        [Header("Gooru Data")] 
        [SerializeField] private string classID;
        [SerializeField] private string lessonID;
        [SerializeField] private int milestoneIndex;
        [SerializeField] private string collectionID;
        [SerializeField] private string questionId;
    }
}