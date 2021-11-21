namespace third{

/*Build appropriate Classes for storing the following entities:
Client, Lawyer, Administration, Receptionist, Case and Appointment*/

class Person
{

}
class Client
{
    string Id;
    string Firstname;
    string MiddleName;
    string Lastname;
    DateTime DOB;
    string CaseType;
    string Street;
    int Steet_Nr;
    string Zip;
    string City;
}
class Lawyer
{
    string EmployeeId;
    string Name;
    string DOB;
    string YearsofExperience;
    string Specialization;
    string JoinedDate;
    string OtherExpertise;
}
class Administration
{
    string Id;
    string Name;
    DateTime JoinedOn;
    string Role;
    string OtherExpertise;
}

class Receptionist
{
    string Id;
    string Name;
    string OtherExpertise;
    string JoinedDate;
}

class Case
{
    string Id;
    string CustomerId;
    string Casetype;// (Corporate, Family or Criminal)
    DateTime Startdate;
    string ExpectedProcessDuration;
    string TotalCharges;
    string LawyerId;
    string SituationDescription;
    string OtherNotes;
}

class Appointment
{
    string Id;
    string ClientId;
    string LawyerId;
    DateTime Datetime;
    string MeetingRoom;
    string ShortDescription;
}

}