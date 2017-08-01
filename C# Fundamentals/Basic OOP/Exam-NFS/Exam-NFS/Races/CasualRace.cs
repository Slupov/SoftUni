using System;
using System.Collections.Generic;
using System.Linq;

class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool, List<Car> participants) : base(length, route, prizePool, participants)
    {
    }

    public override void AssingPerformancePoints()
    {
        foreach (var participant in Participants)
        {
            participant.PerformancePoints = participant.OverallPerformance;
        }
    }
}