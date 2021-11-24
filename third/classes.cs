namespace third
{

    /*Build appropriate Classes for storing the following entities:
    Client, Lawyer, Administration, Receptionist, Case and Appointment*/

    public class Client
    {
        public string Id;
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public string DOB;
        public string CaseType;
        public string Street;
        public string Street_Nr;
        public string Zip;
        public string City;
    }
    public class Lawyer
    {
        public string EmployeeId;
        public string Name;
        public string DOB;
        public string YearsofExperience;
        public string Specialization;
        public string JoinedDate;
        public string OtherExpertise;
    }
    public class Administration
    {
        public string Id;
        public string Name;
        public string JoinedOn;
        public string Role;
        public string OtherExpertise;
    }

    public class Receptionist
    {
        public string Id;
        public string Name;
        public string OtherExpertise;
        public string JoinedDate;
    }

    public class Case
    {
        public string Id;
        public string ClientId;
        public string CaseType;// (Corporate, Family or Criminal)
        public string StartDate;
        public string ExpectedProcessDuration;
        public string TotalCharges;
        public string LawyerId;
        public string SituationDescription;
        public string OtherNotes;
    }

    public class Appointment
    {
        public string Id;
        public string ClientId;
        public string LawyerId;
        public string DateTime;
        public string MeetingRoom;
        public string ShortDescription;
    }



}