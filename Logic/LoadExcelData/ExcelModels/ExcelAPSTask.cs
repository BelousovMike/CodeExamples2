using Ganss.Excel;

namespace APS.Core.LoadExcelData.ExcelModels
{
    internal class ExcelAPSTask
    {
        [Column(Letter = "X")]
        public int Id { get; set; }

        [Column(Letter = "A")]
        public int LMIItemId { get; set; }

        [Column(Letter = "E")]
        public string Description { get; set; }

        [Column(Letter = "F")]
        public string AcceptableCondition { get; set; }

        [Column(Letter = "G")]
        public string TaskExecutionGuidanceNote { get; set; }

        [Column(Letter = "H")]
        public int? IntervalHours { get; set; }

        [Column(Letter = "I")]
        public string IntervalMTT { get; set; }

        [Column(Letter = "J")]
        public int IntervalValue { get; set; }

        [Column(Letter = "K")]
        public string IntervalUnitCode { get; set; }

        [Column(Letter = "L")]
        public string DisciplineCode { get; set; }

        [Column(Letter = "M")]
        public string ResourceCode { get; set; }

        [Column(Letter = "N")]
        public double Duration { get; set; }

        [Column(Letter = "O")]
        public string ActivityDescription { get; set; }

        [Column(Letter = "P")]
        public string Technology { get; set; }

        [Column(Letter = "Q")]
        public string ComplianceCode { get; set; }

        [Column(Letter = "R")]
        public string ComplianceReference { get; set; }

        [Column(Letter = "S")]
        public string SystemStatusDescription { get; set; }

        [Column(Letter = "T")]
        public string Isolations { get; set; }

        [Column(Letter = "U")]
        public string Approach { get; set; }

        [Column(Letter = "V")]
        public string TaskType { get; set; }

        [Column(Letter = "W")]
        public string TaskPriority { get; set; }

        [Column(Letter = "Y")]
        public string SecondaryTasks { get; set; }

        [Column(Letter = "Z")]
        public string Image { get; set; }

        [Column(Letter = "AA")]
        public string DetailedWorkInstructions { get; set; }

        [Column(Letter = "AB")]
        public string CustomField1 { get; set; }

        [Column(Letter = "AC")]
        public string CustomField2 { get; set; }

        [Column(Letter = "AD")]
        public string Function { get; set; }

        [Column(Letter = "AE")]
        public string FunctionUpdated { get; set; }

        [Column(Letter = "AF")]
        public string FunctionFailure { get; set; }

        [Column(Letter = "AG")]
        public string FailureMode { get; set; }

        [Column(Letter = "AH")]
        public string FailureCause { get; set; }

        [Column(Letter = "AI")]
        public string FailureEffect { get; set; }

        [Column(Letter = "AJ")]
        public int MTBFValue { get; set; }

        [Column(Letter = "AK")]
        public string MTBFUnitCode { get; set; }

        [Column(Letter = "AL")]
        public double StandardDeviation { get; set; }

        [Column(Letter = "AM")]
        public string FailureProgression { get; set; }

        [Column(Letter = "AN")]
        public string FailurePattern { get; set; }

        [Column(Letter = "AO")]
        public int PFPeriod { get; set; }
    }
}
