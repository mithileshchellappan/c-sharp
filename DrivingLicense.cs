using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_3_Proj
{
    internal class DrivingLicense
    {
        public int GetLicenseProcessingTime(string applicantName, int numOfAgents, string listOfNames)
        {
            listOfNames += " " + applicantName;
            string[] nameArray = listOfNames.Split(' ');
            Array.Sort(nameArray);
            int applicantIndex = Array.IndexOf(nameArray, applicantName);
            int priorProcessingTime = (applicantIndex / numOfAgents) * 20;
            int totalProcessingTime = priorProcessingTime + 20;

            return totalProcessingTime;
        }
    }
}