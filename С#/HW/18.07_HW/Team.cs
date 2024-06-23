using _18._07_HW.Workers;
using System.Text;

namespace _18._07_HW
{
    public class Team
    {
        public List<Worker> Workers { get; set; }
        public TeamLeader TeamLeader { get; set; }
        public House House { get; set; }

        public Team(List<Worker> workers, TeamLeader teamLeader, House house)
        {
            Workers = workers;
            TeamLeader = teamLeader;
            House = house;
            foreach (Worker worker in workers) 
            {
                worker.House = House;
            }
            teamLeader.House = House;
        }

        public void AddWorker(Worker worker)
        {
            worker.House = House;
            Workers.Add(worker);
        }

        public void Work()
        {
            foreach (Worker worker in Workers)
            {
                worker.Work();
            }
            TeamLeader.Work();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Worker worker in Workers) 
            {
                sb.Append(worker.ToString());
                sb.Append('\n');
            }
            sb.Append(TeamLeader.ToString());
            sb.Append('\n');
            return sb.ToString();
        }
    }
}
