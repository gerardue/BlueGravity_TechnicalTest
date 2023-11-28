using System;
using Game.Systems.DayNightCycleSystem.Controllers;
using UnityEngine;

namespace Game.Systems.DayNightCycleSystem
{
    /// <summary>
    /// This class is responsible to communicate with the Day & Night Cycle System and expose it to other systems.
    /// </summary>
    public class DayNightCycleDirector : MonoBehaviour
    {
        [SerializeField]
        private DayNightCycleHandler dayNightCycleHandler;

        #region Public Methods

        public void Initialize(Action aOnDayStart, Action aOnDayEnd, Action aOnNightStart, Action aOnNightEnd)
        {
            dayNightCycleHandler.Initialize(aOnDayStart, aOnDayEnd, aOnNightStart, aOnNightEnd);
        }
        
        public string GetCurrentTime() => dayNightCycleHandler.GetCurrentTime();

        #endregion
    }
}
