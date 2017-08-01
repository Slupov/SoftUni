using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    public bool IsClosed { get; set; }

    protected Race(int length, string route, int prizePool, List<Car> participants)
    {
        Length = length;
        Route = route;
        PrizePool = prizePool;
        Participants = participants;
        IsClosed = false;
    }

    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    private int length;

    protected int Length
    {
        get { return length; }
        set { length = value; }
    }

    private string route;

    protected string Route
    {
        get { return route; }
        set { route = value; }
    }

    private int prizePool;

    protected int PrizePool
    {
        get { return prizePool; }
        set { prizePool = value; }
    }

    private List<Car> participants;

    public List<Car> Participants
    {
        get { return participants; }
        set
        {
            if (IsClosed)
            {
                return;
            }
            participants = value;
        }
    }

    public virtual void RankParticipants()
    {
        AssingPerformancePoints();
        Participants = Participants.OrderByDescending(p => p.PerformancePoints).ToList();
    }

    public abstract void AssingPerformancePoints();

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}");

        if (Participants.Count > 0)
        {
            //RankParticipants
            var winners = Participants.Take(3).ToList();
            List<int> prizes = new List<int>()
            {
                (PrizePool * 50) / 100,
                (PrizePool * 30) / 100,
                (PrizePool * 20) / 100
            };
            for (int i = 0; i < winners.Count; i++)
            {
                sb.AppendLine(
                    $"{i + 1}. {winners[i].Brand} {winners[i].Model} {winners[i].PerformancePoints}PP - ${prizes[i]}");
            }
        }

        return sb.ToString().Trim();
    }
}