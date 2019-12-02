using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hw8.Models.ViewModel
{
    public class TFViewModel
    {
        public TFViewModel(RaceResult raceResult)
        {
            RaceResultAthleteName = raceResult.Athlete.NAME;
            RaceResultAthleteGender = raceResult.Athlete.GENDER;

            RaceResultMeetDate = raceResult.Meet.DATE;
            RaceResultMeetLocation = raceResult.Meet.LOCATION;

            RaceResultEventName = raceResult.NAME;
            RaceResultTime = raceResult.TIME;

            RaceResultAthleteTeam = raceResult.Athlete.Team.NAME;

        }

        public string RaceResultAthleteName { get; set; }

        public string RaceResultAthleteTeam { get; set; }

        public string RaceResultMeetLocation { get; set; }

        public string RaceResultEventName { get; set; }

        public float RaceResultTime { get; set; }

        public string RaceResultMeetDate { get; set; }

        public string RaceResultAthleteGender { get; set; }






    }
}