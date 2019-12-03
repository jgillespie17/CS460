using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using hw8.Models;

namespace hw8.Models.ViewModel
{
    public class TFViewModel
    {
        public TFViewModel(RaceResult raceResult, Athlete athlete, Meet meet)
        {
            RaceResultAthleteName = athlete.NAME;
            RaceResultAthleteGender = raceResult.Athlete.GENDER;

            RaceResultMeetDate = raceResult.Meet.DATE;
            RaceResultMeetLocation = raceResult.Meet.LOCATION;

            RaceResultEventName = raceResult.NAME;
            RaceResultTime = raceResult.TIME;

            RaceResultAthleteTeam = raceResult.Athlete.Team.NAME;

        }
        [Display(Name = "Athlete Name: ")]
        public string RaceResultAthleteName { get; set; }

        [Display(Name = "Athlete Team: ")]
        public string RaceResultAthleteTeam { get; set; }

        [Display(Name = "Meet Location: ")]
        public string RaceResultMeetLocation { get; set; }

        [Display(Name = "Event Name: ")]
        public string RaceResultEventName { get; set; }

        [Display(Name = "Result Time: ")]
        public float RaceResultTime { get; set; }

        [Display(Name = "Meet Date: ")]
        public string RaceResultMeetDate { get; set; }

        [Display(Name = "Event Gender: ")]
        public string RaceResultAthleteGender { get; set; }
    }
}