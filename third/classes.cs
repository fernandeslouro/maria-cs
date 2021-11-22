namespace third
{

    /*Build appropriate Classes for storing the following entities:
    Client, Lawyer, Administration, Receptionist, Case and Appointment*/

    public class Person
    {

    }
    public class Client
    {
        public string Id;
        public string Firstname;
        public string MiddleName;
        public string Lastname;
        public DateTime DOB;
        public string CaseType;
        public string Street;
        public int Steet_Nr;
        public string Zip;
        public string City;
    }
    public class Lawyer
    {
        public string EmployeeId;
        public string Name;
        public string DOB;
        public int YearsofExperience;
        public string Specialization;
        public string JoinedDate;
        public string OtherExpertise;
    }
    public class Administration
    {
        public string Id;
        public string Name;
        public DateTime JoinedOn;
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
        public string CustomerId;
        public string Casetype;// (Corporate, Family or Criminal)
        public DateTime Startdate;
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
        public DateTime Datetime;
        public string MeetingRoom;
        public string ShortDescription;
    }



    public Client inputClient(){
    }

    public Client inputClient(){
        // Id, Firstname, MiddleName, Lastname, DOB, CaseType, Street, Steet Nr, Zip, City
        Client input_client = new Client;

        Console.WriteLine("Input Id");
        Client.Id = Console.ReadLine();

        Console.WriteLine("Input FirstName");
        Client.FirstName = Console.ReadLine();

        Console.WriteLine("Input Middlename");
        Client.Middlename = Console.ReadLine();

        Console.WriteLine("Input Lastname");
        Client.Lastname = Console.ReadLine();

        Console.WriteLine("Input DOB");
        Client.DOB = Console.ReadLine();

        Console.WriteLine("Input CaseType");
        Client.CaseType = Console.ReadLine();

        Console.WriteLine("Input Street");
        Client.Street = Console.ReadLine();

        Console.WriteLine("Input Street Nr");
        Client.Street_Nr = Console.ReadLine();

        Console.WriteLine("Input Zip");
        Client.Zip = Console.ReadLine();

        Console.WriteLine("Input City");
        Client.City = Console.ReadLine();


    }

    public List<Lawyer> ImportFile(string path_layers_file)
    {
        //initialized and empty array list of Lawyer object type
        List<Lawyer> lawyers = new List<Lawyer>();

        string[] lines = File.ReadAllLines(path_layers_file);

        //loop to split and read each line into objects
        for (int i = 1; i < lines.Length; i++)
        {
            var columns = lines[i].Split(',');
            Lawyer l = new Lawyer();

            l.EmployeeId = columns[0];
            l.Name = columns[1];
            l.DOB = columns[2];
            l.YearsofExperience = int.Parse(columns[3]);
            l.Specialization = columns[4];
            l.JoinedDate = columns[5];
            l.OtherExpertise = columns[6];

            lawyers.Add(l);

        }

        lawyersList = lawyers;
        return lawyers;

    }


    public List<Client> AddNewClient(List<Client> list_of_clients, Client client_to_add)
    {
        list_of_clients.Add(client_to_add);
        return list_of_clients;
    }
    public List<Appointment> AddNewAppointment(List<Appointment> list_of_appointments, Appointment appointment_to_add)
    {
        list_of_appointments.Add(appointment_to_add);
        return list_of_appointments;
    }
    public List<Case> AddNewCase(List<Case> list_of_cases, Case case_to_add)
    {
        list_of_cases.Add(case_to_add);
        return list_of_cases;
    }


    void ListClients(List<Client> list_of_clients)
    {

        Console.WriteLine($"Id\t Firstname\t MiddleName\t Lastname\t DOB\t CaseType\t Street\t Steet_Nr\t Zip\t City\t ");
        foreach (Client c in list_of_clients)
        {
            Console.WriteLine($"{c.Id}\t {c.Firstname}\t {c.MiddleName}\t {c.Lastname}\t {c.DOB}\t {c.CaseType}\t {c.Street}\t {c.Steet_Nr}\t {c.Zip}\t {c.City}\t ");
        }

    }

    void ListCases(List<Case> list_of_cases)
    {

        Console.WriteLine($"Id\t CustomerId\t CaseType\t Startdate\t ExpectedProcessDuration\t TotalCharges\t LawyerId\t SituationDescription\t OtherNotes\t");
        foreach (Case c in list_of_cases)
        {
            Console.WriteLine($"{c.CustomerId}\t {c.Casetype}\t {c.Startdate}\t {c.ExpectedProcessDuration}\t {c.TotalCharges}\t {c.LawyerId}\t {c.SituationDescription}\t {c.OtherNotes}");
        }

    }

    void listAppointments(List<Appointment> list_of_appointments)
    {

        Console.WriteLine($"Id\t ClientId\t LawyerId\t Datetime\t MeetingRoom\t ShortDescription");
        foreach (Appointment a in list_of_appointments)
        {
            Console.WriteLine($"{a.ClientId}\t {a.LawyerId}\t {a.Datetime}\t {a.MeetingRoom}\t {a.ShortDescription}");
        }

    }
}