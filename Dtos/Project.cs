using BusinessLogicLayer;
using System.Collections.Generic;
using System.Linq;

namespace Dtos
{ 
    public abstract class Project
    {
        protected int ProjectId { get; set; }
        protected string ProjectName { get; set; }

        public Project(int pojectid, string projectName)
        {
            ProjectId = pojectid;
            ProjectName = projectName;
        }

        public abstract int GetInvoiceAmount();
    }

    public class TimeBasedProject : Project
    {
        public TimeBasedProject(int pojectid, string projectName) : base(pojectid,projectName)
        {

        }
        public int TotalLoggedHours { get; set; }

        public override int GetInvoiceAmount()
        {
            return 500 * TotalLoggedHours;
        }
    }

    public class MileStoneBasedProject : Project
    {
        private readonly Imilestone _imilestone;
        public MileStoneBasedProject(int pojectid, string projectName, Imilestone imilestone) : base(pojectid, projectName)
        {
            _imilestone = imilestone;
        }

        public override int GetInvoiceAmount()
        {
            return _imilestone.GetFixedAmountForMilestone();
        }
    }

    public interface Imilestone
    {
        PhaseType phaseType { get;}
        int GetFixedAmountForMilestone();
    }

    public class MilestonePhaseOne : Imilestone
    {
        PhaseType Imilestone.phaseType { get => PhaseType.one; }

        public int GetFixedAmountForMilestone()
        {
            return 500;
        }
    }

    public class MilestonePhaseTwo : Imilestone
    {
        PhaseType Imilestone.phaseType { get => PhaseType.two; }
        public int GetFixedAmountForMilestone()
        {
            return 1000;
        }
    }

    public interface IProvider
    {
        Imilestone GetMilstone(PhaseType phaseType);
    }

    public class Provider : IProvider
    {
        private readonly IEnumerable<Imilestone> _imilestones;
        public Imilestone GetMilstone(PhaseType phaseType)
        {
           return _imilestones.FirstOrDefault(a => a.phaseType == phaseType);
        }
    }

}
