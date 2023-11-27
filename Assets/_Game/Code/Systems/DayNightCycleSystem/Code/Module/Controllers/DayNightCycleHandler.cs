using System;
using System.Text;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using HobittonJourney.Systems.DayNightCycleSystem.Data;
using UnityEngine.Serialization;

namespace HobittonJourney.Systems.DayNightCycleSystem.Controllers
{
    /// <summary>
    /// This class is responsible to handle the Day & Night Cycle System
    /// </summary>
    public class DayNightCycleHandler : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        private DayNightCycleSettings settings;

        [Header("Light")]
        [SerializeField]
        private Light2D light2D;
        
        // Systems
        private WorldTimeConvertorSystem timeConvertor; 
        
        // Runtime Data
        private DayNightRuntimeData runtimeData;
        private float currentRateTime; // 0 to 1
        private float elapsedTime; 
        private bool isDay;
        private bool isNight; 
        
        // Events
        private Action onDayStart;
        private Action onDayEnd;
        private Action onNightStart;
        private Action onNightEnd;

        private bool isInit; 
        
        #region Unity Methods

        private void Update()
        {
            if(!isInit)
                return;
            
            elapsedTime += Time.deltaTime; 
            runtimeData.currentTime = Mathf.Repeat(elapsedTime, settings.DayCycleDuration);
            currentRateTime = Mathf.Clamp01(runtimeData.currentTime / settings.DayCycleDuration);
            runtimeData.currentCycleTime = settings.CycleCurve.Evaluate(currentRateTime / 2);
            
            light2D.color = settings.GradientCycle.Evaluate(runtimeData.currentCycleTime);
            
            InvokeEvents();
        }

        #endregion

        #region Public Methods

        public void Initialize(Action aOnDayStart, Action aOnDayEnd, Action aOnNightStart, Action aOnNightEnd)
        {
            onDayStart = aOnDayStart;
            onDayEnd = aOnDayEnd;
            onNightStart = aOnNightStart;
            onNightEnd = aOnNightEnd;
            
            timeConvertor = new WorldTimeConvertorSystem(settings.HourDurationInSeconds, settings.MinuteDurationInMilliseconds);
            runtimeData = new DayNightRuntimeData();
            runtimeData.currentTime = settings.InitialHourDay;

            isInit = true; 
        }

        public string GetCurrentTime()
        {
            return timeConvertor.GetCurrentTime(runtimeData.currentTime); 
        }

        #endregion

        #region Private Methods

        private void InvokeEvents()
        {
            if (runtimeData.currentTime > settings.DayStartTime && runtimeData.currentTime < settings.NightStartTime && !isDay)
            {
                onNightEnd?.Invoke();
                onDayStart?.Invoke();
                isDay = true;
                isNight = false; 
            }
            else if(runtimeData.currentTime > settings.NightStartTime && !isNight)
            {
                onDayEnd?.Invoke();
                onNightStart?.Invoke();
                isDay = false;
                isNight = true; 
            }
        }

        #endregion
    }
}