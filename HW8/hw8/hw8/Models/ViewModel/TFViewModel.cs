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
        public TFViewModel(IEnumerable<RaceResult> raceResult)
        {
            RaceResultMeetDate = raceResult.Select(x => x.Meet.DATE);
            RaceResultMeetLocation = raceResult.Select(x => x.Meet.LOCATION);

            RaceResultEventName = raceResult.Select(x => x.NAME);
            RaceResultTime = raceResult.Select(x => x.TIME);

            RaceData data = new RaceData();
            List<RaceData> listData = new List<RaceData>();
            for(int i = 0; i < raceResult.Count(); i++)
            {
                data.Date = RaceResultMeetDate.ElementAt(i);
                data.Location = RaceResultMeetLocation.ElementAt(i);
                data.EventName = RaceResultEventName.ElementAt(i);
                data.Time = RaceResultTime.ElementAt(i);
                listData.Add(data);
            }
            AthleteResult = listData;

        }
        //[Display(Name = "Athlete Name: ")]
        //public string RaceResultAthleteName { get; set; }

        //[Display(Name = "Athlete Team: ")]
        //public string RaceResultAthleteTeam { get; set; }

        [Display(Name = "Meet Location: ")]
        public IEnumerable<string> RaceResultMeetLocation { get; set; }

        [Display(Name = "Event Name: ")]
        public IEnumerable<string> RaceResultEventName { get; set; }

        [Display(Name = "Result Time: ")]
        public IEnumerable<float> RaceResultTime { get; set; }

        [Display(Name = "Meet Date: ")]
        public IEnumerable<string> RaceResultMeetDate { get; set; }

        //[Display(Name = "Event Gender: ")]
        //public string RaceResultAthleteGender { get; set; }

        public IEnumerable<RaceData> AthleteResult { get; set; }

        public struct RaceData
        {
            
            public string Location { get; set; }
            public string EventName { get; set; }
            public float Time { get; set; }
            public string Date { get; set; }
        }

    }
}