using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tiwaz.Server.Api.DtoModel;
using Tiwaz.Server.Classes;

namespace Tiwaz.Server.DatabaseModel
{
    public class Match : MatchRuleSet
    {
        public Match() 
        {
        }

        /// <summary>
        /// The ID of the match
        /// </summary>
        [Key]
        public int Id { get; set; }


        /// <summary>
        /// The List of the Players for Team 1
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public Player[]? Team1Players { get; set; }

        /// <summary>
        /// The Ids of the Players for Team 1
        /// </summary>
        [NotMapped]
        public List<int> Team1PlayerIds { get; set; } = new List<int>();

        /// <summary>
        /// The List of the Players for Team 2
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public Player[]? Team2Players { get; set; }

        /// <summary>
        /// The Ids of the Players for Team 2
        /// </summary>
        [NotMapped]
        public List<int> Team2PlayerIds { get; set; } = new List<int>();

        /// <summary>
        /// Score of Team1
        /// </summary>
        [Required]
        public int Team1Score { get; set; }

        /// <summary>
        /// Score of Team2
        /// </summary>
        [Required]
        public int Team2Score { get; set; }

        /// <summary>
        /// Name of Team1
        /// </summary>
        [Required]
        public string? Team1Name { get; set; }

        /// <summary>
        /// Name of Team2
        /// </summary>
        [Required]
        public string? Team2Name { get; set; }

        /// <summary>
        /// Time left in seconds
        /// </summary>
        [Required]
        public int CurrentTimeLeft { get; set; }

        /// <summary>
        /// The current halftime; 0 = match not started
        /// </summary>
        [Required]
        public int CurrentHalftime { get; set; }

        /// <summary>
        /// The Status of the Match
        /// </summary>
        public int MatchStatus { get; set; }

        /// <summary>
        /// The Scheduled time when the match should start
        /// </summary>
        public DateTime? ScheduledTime { get; set; }

        /// <summary>
        /// The timestamps of matchevents
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public List<MatchEvent> MatchEvents { get; set; }

        /// <summary>
        /// The event IDs for this Match
        /// </summary>
        [NotMapped]
        public List<int> MatchEventIds { get; set; }


        /// <summary>
        /// Converts the object to a DTO object
        /// </summary>
        /// <returns></returns>
        public DtoMatch ToDto()
        {
            var dto = new DtoMatch()
            {
                Id = Id,
                Team1Score = Team1Score,
                Team2Score = Team2Score,
                Team1Name = Team1Name,
                Team2Name = Team2Name,
                TimeLeftSeconds = CurrentTimeLeft,
                MatchStatus = MatchStatus,
                ScheduledTime = ScheduledTime,
                Team1PlayerIds = Team1PlayerIds,
                Team2PlayerIds = Team2PlayerIds
            };

            return dto;
        }

        /// <summary>
        /// Converts the object from a DTO object
        /// </summary>
        /// <param name="dto"></param>
        public void FromDto(DtoMatch dto)
        {
            Id = dto.Id;
            Team1Score = dto.Team1Score ?? 0;
            Team2Score = dto.Team2Score ?? 0;
            Team1Name = dto.Team1Name;
            Team2Name = dto.Team2Name;
            CurrentTimeLeft = dto.TimeLeftSeconds ?? 0;            
            MatchStatus = dto.MatchStatus;
            ScheduledTime = dto.ScheduledTime;
            GameName = dto.GameName;
            Team1PlayerIds = dto.Team1PlayerIds ?? new List<int>();
            Team2PlayerIds = dto.Team2PlayerIds ?? new List<int>();
        }
    }
}
