namespace BestPracticeApp
{
    internal static class Constants
    {
        internal static class ConnectionStrings
        {
            internal const string DosDataContext = "DOSConnectionString";

            internal const string IntranetDataContext = "IntranetConnectionString";

            internal const string MillenniumDataContext = "VCUConnectionString";
        }

        internal static class Roles
        {
            internal const string ViewDivision = "permAttendance";

            internal const string EditDivision = "permAttendance, permReports";

            internal const string ViewAll = "permReports, permCalendarAdmin, permAdmin";

            internal const string EditAll = "permCalendarAdmin, permAdmin";

            internal const string Admin = "permCalendarAdmin, permAdmin";

            internal const string View = ViewDivision + ", " + ViewAll;

            internal const string Edit = EditDivision + ", " + EditAll;
        }

        internal static class Tabs
        {
            internal const string Home = "Home";

            internal const string Event = "Event";

            internal const string Registrants = "Registrants";

            internal const string Guests = "Guests";

            internal const string Attendance = "Attendance";

            internal const string Rsvp = "RSVP";
        }

        internal static class NotAuthorized
        {
            internal const string General = "You do not have permissions to do this action.";

            internal const string EventView = "You do not have permission to view this event.";

            internal const string EventEdit = "You do not have permission to edit this event.";

            internal const string EventExport = "You do not have permission to export this event.";

            internal const string RegistrantAdd = "You do not have permission to add registrants for this event.";

            internal const string RegistrantEdit = "You do not have permission to edit registrants for this event.";

            internal const string AttendanceView = "You do not have permission to view attendance for this event.";

            internal const string AttendanceEdit = "You do not have permission to edit attendance for this event.";

            internal const string AttendanceSubmit = "You do not have permission to submit attendance for this event.";

            internal const string AttendanceConfirm = "You do not have permission to confirm attendance for this event.";

            internal const string RsvpView = "You do not have permission to view RSVP info for this event.";

            internal const string RsvpEdit = "You do not have permission to edit RSVP info for this event.";
        }

        internal static class FileContentType
        {
            internal const string Excel = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        }
    }
}