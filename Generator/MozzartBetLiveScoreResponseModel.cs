using System.Collections.Generic;

namespace Generator
{
    public class Country
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Sport
    {
        public string name { get; set; }
        public int id { get; set; }
        public int priority { get; set; }
    }

    public class Competition
    {
        public Country country { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string shortName { get; set; }
        public int priority { get; set; }
        public Sport sport { get; set; }
    }

    public class PeriodScore
    {
        public List<string> periodType { get; set; }
        public int winner { get; set; }
        public string scoreType { get; set; }
        public bool active { get; set; }
        public string visitor { get; set; }
        public string home { get; set; }
    }

    public class AdditionalScoreInfo
    {
        public List<string> periodType { get; set; }
        public int winner { get; set; }
        public string scoreType { get; set; }
        public bool active { get; set; }
        public string visitor { get; set; }
        public string home { get; set; }
    }

    public class Score
    {
        public List<PeriodScore> periodScores { get; set; }
        public List<AdditionalScoreInfo> additionalScoreInfo { get; set; }
        public int server { get; set; }
        public int winner { get; set; }
        public string time { get; set; }
    }

    public class SubGame
    {
        public int gameId { get; set; }
        public int subGameId { get; set; }
        public string gameName { get; set; }
        public string specialOddValueType { get; set; }
        public int id { get; set; }
        public string gameShortName { get; set; }
        public string subGameName { get; set; }
        public string subGameDescription { get; set; }
    }

    public class Odd
    {
        public string winStatus { get; set; }
        public SubGame subGame { get; set; }
        public int id { get; set; }
        public string specialOddValue { get; set; }
        public string value { get; set; }
        public int matchId { get; set; }
    }

    public class Season
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class CompetitionPhase
    {
        public int round { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class MatchEventStatus
    {
        public int code { get; set; }
    }

    public class Participant
    {
        public string name { get; set; }
        public string description { get; set; }
        public int id { get; set; }
        public string shortName { get; set; }
    }

    public class Status
    {
        public int code { get; set; }
    }

    public class Match
    {
        public int allOddsCount { get; set; }
        public int competitionId { get; set; }
        public int matchEventStatusShort { get; set; }
        public string competitionName { get; set; }
        public int listTypeId { get; set; }
        public Competition competition { get; set; }
        public string mainMatch { get; set; }
        public object changeTime { get; set; }
        public Score score { get; set; }
        public int sportId { get; set; }
        public int specialType { get; set; }
        public List<Odd> odds { get; set; }
        public Season season { get; set; }
        public object startTime { get; set; }
        public int id { get; set; }
        public int roundId { get; set; }
        public CompetitionPhase competitionPhase { get; set; }
        public int matchNumber { get; set; }
        public MatchEventStatus matchEventStatus { get; set; }
        public List<Participant> participants { get; set; }
        public Status status { get; set; }
        public int index { get; set; }
        public string competitionComment { get; set; }
        public string matchComment { get; set; }
    }

    public class MozzartBetLiveScoreResponseModel
    {
        public List<Match> matches { get; set; }
        public int total { get; set; }
    }


}