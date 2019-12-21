using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickZ.Core.Enums
{
    /// <summary>
    /// Database storage options
    /// </summary>
    public enum DataStorageTypeEnum
    {
        XML,
        AccessDB,
        SqlServerExpress,
        ApplicationServer
    }

    public enum RelationshipEnum
    {
        [Description("None")]
        None = 0,

        [Description("Father")]
        Father = 1,

        [Description("Mother")]
        Mother = 2,

        [Description("Aunt")]
        Aunt = 3,

        [Description("Uncle")]
        Uncle = 4,

        [Description("Brother")]
        Brother = 5,

        [Description("Sister")]
        Sister = 6
    }

    public enum GradeEntryStatus
    {
        Draft = 0,
        Submitted = 1,
        Verified = 2,
        Approved = 3,
        Redrafted = 4,
        Final = 9999
    }

    public enum AcademicPeriodTypeEnum
    {
        GP, // Grading Period
        AP, // Attendance Priod
        S   // Semester
    }
}
