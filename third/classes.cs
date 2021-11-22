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



    public Client inputClient()
    {
    }

    public Client inputClient()
    {
        // Id, Firstname, MiddleName, Lastname, DOB, CaseType, Street, Steet Nr, Zip, City
        Client input_client = new Client;

        bool correct = false;
        string correct_string;

        while (!correct)
        {
            Console.WriteLine("Input Id");
            input_client.Id = Console.ReadLine();

            Console.WriteLine("Input FirstName");
            input_client.FirstName = Console.ReadLine();

            Console.WriteLine("Input Middlename");
            input_client.Middlename = Console.ReadLine();

            Console.WriteLine("Input Lastname");
            input_client.Lastname = Console.ReadLine();

            Console.WriteLine("Input DOB");
            input_client.DOB = Console.ReadLine();

            Console.WriteLine("Input CaseType");
            input_client.CaseType = Console.ReadLine();

            Console.WriteLine("Input Street");
            input_client.Street = Console.ReadLine();

            Console.WriteLine("Input Street Nr");
            input_client.Street_Nr = Console.ReadLine();

            Console.WriteLine("Input Zip");
            input_client.Zip = Console.ReadLine();

            Console.WriteLine("Input City");
            input_client.City = Console.ReadLine();

            Console.WriteLine("The input Client is:\n");
            Console.WriteLine($"Id\t Firstname\t MiddleName\t Lastname\t DOB\t CaseType\t Street\t Steet_Nr\t Zip\t City\t ");
            Console.WriteLine($"{input_client.Id}\t {input_client.Firstname}\t {input_client.MiddleName}\t {input_client.Lastname}\t {input_client.DOB}\t {input_client.CaseType}\t {input_client.Street}\t {input_client.Steet_Nr}\t {input_client.Zip}\t {input_client.City}\t ");

            Console.WriteLine("\nIs it Correct? (y/N)");
            correct_string = Console.ReadLine();
            if (correct_string == "y")
            {
                correct = true;
            }
        }
        return input_client;
    }


    public Client inputAppointment()
    {
        //Id, ClientId, LawyerId, Datetime, MeetingRoom, ShortDescription
        Appointment input_appointment = new Appointment;

        bool correct = false;
        string correct_string;

        while (!correct)
        {
            Console.WriteLine("Input Id");
            input_appointment.Id = Console.ReadLine();

            Console.WriteLine("Input ClientId");
            input_appointment.ClientId = Console.ReadLine();

            Console.WriteLine("Input LawyerId");
            input_appointment.LawyerId = Console.ReadLine();

            Console.WriteLine("Input Datetime");
            input_appointment.Datetime = Console.ReadLine();

            Console.WriteLine("Input MeetingRoom");
            input_appointment.MeetingRoom = Console.ReadLine();

            Console.WriteLine("Input ShortDescription");
            input_appointment.CaseType = Console.ReadLine();

            Console.WriteLine("The input Appointment is:\n");

            Console.WriteLine($"Id\t ClientId\t LawyerId\t Datetime\t MeetingRoom\t ShortDescription");
            Console.WriteLine($"{input_appointment.ClientId}\t {input_appointment.LawyerId}\t {input_appointment.Datetime}\t {input_appointment.MeetingRoom}\t {input_appointment.ShortDescription}");

            Console.WriteLine("\nIs it Correct? (y/N)");
            correct_string = Console.ReadLine();
            if (correct_string == "y")
            {
                correct = true;
            }
        }
        return input_appointment;
    }

    public dynamic inputInfo(string class_type)
    {
        if (class_type == "Client")
        {
            Client input = new Client();
            PropertyInfo[] properties = typeof(Client).GetProperties();
        }
        else if (class_type == "Appointment")
        {
            Appointment input = new Case();
            PropertyInfo[] properties = typeof(Appointment).GetProperties();
        }
        else if (class_type == "Case")
        {
            Case input = new Case();
            PropertyInfo[] properties = typeof(Case).GetProperties();
        }

        string value;
        string correct = false;

        while (!correct)
        {
            foreach (PropertyInfo p in properties)
            {
                Console.WriteLine($"Input property");
                value = Console.ReadLine;
                case_property.SetValue(input, value);
            }


            Console.WriteLine("The input Appointment is:\n");

            foreach (var p in properties)
            {
                Console.Write(p.Name);
                Console.Write("\t");
            }
            Console.WriteLine("");
            foreach (var p in properties)
            {
                Console.Write(p.GetValue(input));
                Console.Write("\t");
            }


            Console.WriteLine("\nIs it Correct? (y/N)");
            correct_string = Console.ReadLine();
            if (correct_string == "y")
            {
                correct = true;
            }

        }

        return input;
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