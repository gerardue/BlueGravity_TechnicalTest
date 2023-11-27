using UnityEngine;

namespace HobittonJourney.Systems.DayNightCycleSystem.Data
{
    /// <summary>
    /// This class is responsible to hold the settings for the Day & Night Cycle System
    /// </summary>
    [CreateAssetMenu(fileName = "DayNightCycleSettings", menuName = "Hobbiton Journey/Settings/Day Night Cycle Settings")]
    public class DayNightCycleSettings : ScriptableObject
    {
        [SerializeField, Tooltip("Day Cycle Duration in seconds")]
        private float dayCycleDuration = 420f;
        public float DayCycleDuration => dayCycleDuration;

        [SerializeField]
        private float dayStartTime; 
        public float DayStartTime => dayStartTime * HourDurationInSeconds;
        
        [SerializeField]
        private float nightStartTime;
        public float NightStartTime => nightStartTime * HourDurationInSeconds;

        [SerializeField, Tooltip("Initial hour to start the day")]
        private float initialHourDay;
        public float InitialHourDay => initialHourDay;

        [SerializeField]
        private AnimationCurve cycleCurve;
        public AnimationCurve CycleCurve => cycleCurve;
        
        [SerializeField]
        private Gradient gradientCycle; 
        public Gradient GradientCycle => gradientCycle;
        
        public float HourDurationInSeconds => dayCycleDuration / 24;
        public float MinuteDurationInMilliseconds => HourDurationInSeconds / 60;
    }
}