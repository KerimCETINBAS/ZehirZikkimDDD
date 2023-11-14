using System.ComponentModel;

namespace ZehirZikkim.Domain.Common.Enums;
public enum DinnerStatus {

    [Description("Upcoming")]
    Upcoming ,

    [Description("InProgres")]
    InProgres,

    [Description("Ended")]
    Ended,
    [Description("Canceled")]
    Canceled ,
}