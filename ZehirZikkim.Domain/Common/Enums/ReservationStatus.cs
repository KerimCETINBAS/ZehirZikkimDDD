using System.ComponentModel;

namespace ZehirZikkim.Domain.Common.Enums;


public enum ReservationStatus {
    [Description("Reserved")]
    Reserved,

    [Description("PendingGuestConfirmation")]
    PendingGuestConfirmation,

    [Description("Canceled")]
    Canceled
}