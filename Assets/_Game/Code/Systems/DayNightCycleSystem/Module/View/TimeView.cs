using System;
using Game.Systems.DayNightCycleSystem.Controllers;
using TMPro;
using UnityEngine;

namespace Game.Systems.DayNightCycleSystem.View
{
    public class TimeView : MonoBehaviour
    {
        [SerializeField]
        private DayNightCycleHandler dayNightCycle;

        [SerializeField]
        private TextMeshProUGUI timeText;

        #region Unity Methods

        private void Update()
        {
            timeText.text = dayNightCycle.GetCurrentTime(); 
        }

        #endregion
    }
}