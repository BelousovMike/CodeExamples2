using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APS.EFDataAccessLibrary.Models
{
    public class APSTask
    {
        [Key]
        public int Id { get; set; }

        public LMIItem LMIItem { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string AcceptableCondition { get; set; }

        public string TaskExecutionGuidanceNote { get; set; }

        public int? IntervalHours { get; set; } 

        public string IntervalMTT { get; set; }

        public int IntervalValue { get; set; }

        public Usage IntervalUnit { get; set; }

        public Discipline Discipline { get; set; }

        public Resource Resource { get; set; }

        public double Duration { get; set; }

        public ActivityType Activity { get; set; }

        public string Technology { get; set; }

        public Compliance Compliance { get; set; }

        public string ComplianceReference { get; set; }

        public SystemCondition SystemStatus { get; set; }

        public string Isolations { get; set; }

        public string Approach { get; set; }

        public string TaskType { get; set; }

        public string TaskPriority { get; set; }

        public ICollection<APSTask> SecondaryTasks { get; set; }

        public string Image { get; set; }

        public string DetailedWorkInstructions { get; set; }

        public string CustomField1 { get; set; }

        public string CustomField2 { get; set; }

        public string Function { get; set; }

        public string FunctionUpdated { get; set; }

        public string FunctionFailure { get; set; }

        public string FailureMode { get; set; }

        public string FailureCause { get; set; }

        public string FailureEffect { get; set; }

        public int MTBFValue { get; set; }

        public Usage MTBFUnit { get; set; }

        public double StandardDeviation { get; set; }

        public string FailureProgression { get; set; }

        public string FailurePattern { get; set; }

        public int PFPeriod { get; set; }
    }
}
