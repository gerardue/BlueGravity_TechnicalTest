using System;
using System.Text;
using UnityEngine;

namespace HobittonJourney.Systems.DayNightCycleSystem.Controllers
{
    /// <summary>
    /// This class is responsible to convert world time.
    /// </summary>
    public class WorldTimeConvertorSystem
    {
        private float hourDuration;
        private float minuteDuration; 
        private StringBuilder stringBuilder;

        #region Constructors

        public WorldTimeConvertorSystem(float aHourDuration, float aMinuteDuration)
        {
            Initialize(aHourDuration, aMinuteDuration);
        }

        #endregion
        
        #region Public Methods

        public void Initialize(float aHourDuration, float aMinuteDuration)
        {
            hourDuration = aHourDuration;
            minuteDuration = aMinuteDuration;
            stringBuilder = new StringBuilder(6); 
        }

        public string GetCurrentTime(float aTime)
        {
            return ConvertTimeToHour(aTime);
        }

        #endregion

        #region Private Methods

        private string ConvertTimeToHour(float aTime)
        {
            int hours = (int)(aTime / hourDuration);
            int minutes =  (int ) ((aTime % hourDuration) / minuteDuration);

            stringBuilder.Clear(); 
            stringBuilder.Append($"{hours:D2}:{minutes:D2}");

            return stringBuilder.ToString();
        }

        #endregion
    }
}