namespace third
{
    class Processor
    {
        private List<FilmInfo> lawyersList = new List<FilmInfo>();

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

                l.EmployeeId = int.Parse(columns[0]);
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
        public List<Appointment> AddNewAppointment(List<Appointment> list_of_appointments, Client appointment_to_add)
        {
            list_of_appoitnments.Add(appointment_to_add);
            return list_of_appointments;
        }
        public List<Case> AddNewCase(List<Case> list_of_cases, Client case_to_add)
        {
            list_of_cases.Add(case_to_add);
            return list_of_cases;
        }



        public List<string> FindUniqueActoressesNames()
        {
            List<string> actoresses = new List<string>();

            StringBuilder sb = new StringBuilder();

            foreach (FilmInfo f in filmList)
            {
                //if one actoress already exists in the list then do not add
                if (!actoresses.Exists(a => a == f.Actoress))
                {
                    actoresses.Add(f.Actoress);
                    sb.AppendLine(f.Actoress);
                }

            }

            File.WriteAllText("/Users/abidh/Teaching/IP/TestData/output.csv", sb.ToString());

            return actoresses;
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

            Console.WriteLine($"Id\t CustomerId\t CaseType\t Startdate\t ExpectedProcessDuration\t TotalCharges\t LawyerId\t SituationDescription\t Othernotes\t");
            foreach (Client c in list_of_cases)
            {
                Console.WriteLine($"{c.CustomerId}\t {c.CaseType}\t {c.StartDate}\t {c.ExpectedProcessDuration}\t {c.TotalCharges}\t {c.LawyerId}\t {c.SituationDescription}\t {c.Othernotes}");
            }

        }




    void ListAppointments()
    {

    }

    void login()
    {
        /* When the application starts it presents three options 1. Lawyer 2. Admin 3. Receptionist */
        Console.WriteLine("Choose between:");
        Console.WriteLine(" 1. Lawyer");
        Console.WriteLine(" 2. Admin");
        Console.WriteLine(" 3. Receptionist");
        int option = int.Parse(Console.Readline());


        /* After selecting one of the three roles. User is prompted with Login. User is asked username and
        password and if correct details are entered user is presented with the features available. */
        Console.WriteLine("Input your username:");
        string input_user = Console.Readline();
        Console.WriteLine("Input your password:");
        string input_password = Console.Readline();

        string allowed_user = "user";
        string allowed_password = "pw";

        if (input_password == allowed_password && input_user == allowed_user)
        {
            function_usage();
        }
    }

    void function_usage()
    {
        /* After successful login, a list of choices is presented. */
        if (option == 1)
        {
            /* o Receptionist can perform following features.
                § Register a new client
                § Add a new Appointment
                § List all appointments
                § List all clients */
            Console.WriteLine("Choose between the possible options for recptionists:");
            Console.WriteLine(" 1. Register a new client");
            Console.WriteLine(" 2. Add a new appointment");
            Console.WriteLine(" 3. List all appointments");
            Console.WriteLine(" 4. List all clients");
            int receptionist_option = int.Parse(Console.Readline());

        }
        else if (option == 2)
        {
            /*o Lawyer should be able to perform following tasks
            § List all Cases
            § Add a new Case
            § List all appointments*/
            Console.WriteLine("Choose between the possible options for Lawyers:");
            Console.WriteLine(" 1. List all cases");
            Console.WriteLine(" 2. Add a new case");
            Console.WriteLine(" 3. List all appointments");
            int lawyer_option = int.Parse(Console.Readline());

        }
        else if (option == 3)
        {
            /*o Admin staff should be able to perform following tasks:
            § List all Cases
            § List all appointments */

            Console.WriteLine("Choose between the possible options for Admins:");
            Console.WriteLine(" 1. List all cases");
            Console.WriteLine(" 2. List all appointments");
            int lawyer_option = int.Parse(Console.Readline());

        }
    }


    class Program
    {

        static void Main(string[] args)
        {

            List<Lawyer> listLawyers;
            List<Client> listClients;
            List<Administration> ListAdministrations;
            list<Receptionist> listReceptionists;
            List<Case> listCases;
            List<Appointment> listAppointments;


            listLawyers = ImportFile("lawyers_database.csv");

            login();
        }
    }}}