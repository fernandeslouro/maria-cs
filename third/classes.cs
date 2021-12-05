namespace third
{

    /*Build appropriate Classes for storing the following entities:
    Client, Lawyer, Administration, Receptionist, Case and Appointment*/


    public abstract class Staff
    {

        public string EmployeeId;
        public string EmployeeName;
        public string OtherExpertise;
        public DateTime JoinedDate;
    }


    public class Receptionist : Staff
    {
    }


    public class Administration : Staff
    {
        public string Role;
    }

    public class Lawyer : Staff
    {
        public DateTime DOB;
        public string YearsofExperience;
        public ECaseType Specialization;
    }

    public class Client
    {
        public string LawyerId;
        public string ClientId;
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public DateTime DOB;
        public ECaseType CaseType;
        public string Street;
        public string Street_Nr;
        public string Zip;
        public string City;
    }

    public class Appointment
    {
        public string ClientId;
        public string LawyerId;
        public string Id;
        public DateTime DateTime;
        public EMeetingRoom MeetingRoom;
        public string ShortDescription;
    }


    public class Case 
    {
        public string Id;
        public string ClientId;
        public string LawyerId;
        public ECaseType CaseType;
        public DateTime StartDate;
        public int ExpectedProcessDuration;
        public int TotalCharges;
        public string SituationDescription;
        public string OtherNotes;
    }



    public enum EMeetingRoom
    {
        Acquarium,
        Cube,
        Cave
    }
    public enum ECaseType
    {
        Corporate,
        Criminal,
        Family
    }

}