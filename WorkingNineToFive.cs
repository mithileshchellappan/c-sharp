using System;

namespace _24_3_Proj
{
    public class WorkingNineToFive
    {
        private float _startHour, _endHour, _hourlyRate, _overtimeMultiplier;

        public WorkingNineToFive(float startHour, float endHour, float hourlyRate, float overtimeMultiplier)
        {
            _startHour = startHour;
            _endHour = endHour;
            _hourlyRate = hourlyRate;
            _overtimeMultiplier = overtimeMultiplier;
        }

        public float StartHour => _startHour;

        public float EndHour => _endHour;

        public float HourlyRate => _hourlyRate;

        public float OvertimeMultiplier => _overtimeMultiplier;

        public float CalculatePay()
        {
            float pay = 0.0f;
            if (_endHour > 17.0f)
            {
                pay = ((17.0f - _startHour) * _hourlyRate) + ((_endHour - 17.0f) * _hourlyRate * _overtimeMultiplier);
            }
            else
            {
                pay = (_endHour - _startHour) * _hourlyRate;
            }

            return pay;
        }
    }
}
