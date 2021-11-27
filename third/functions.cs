
using System.Reflection;
namespace third
{
    public class functions
    {

        public void printSpecialistLawyers(List<Lawyer> lawyers_list, string specialization)
        {
            // implement
        }

        public void inputValidLawyerId(List<Lawyer> list_of_lawyers)
        {
            bool id_allowed = false;
            while (!id_allowed)
            {
                Console.WriteLine("Input Lawyer ID");
                string input_id = Console.ReadLine();
                if (IdInLawyersList(list_of_lawyers, input_id){
                    id_allowed = true;
                }
                else
                {
                    Console.WriteLine("Insert a valid Lawyer ID");
                }
            }
        }


        public void inputValidClientId(List<Client> list_of_clients)
        {
            bool id_allowed = false;
            while (!id_allowed)
            {
                Console.WriteLine("Input Client ID");
                string input_id = Console.ReadLine();
                if (IdInClientsList(list_of_clients, input_id){
                    id_allowed = true;
                }
                else
                {
                    Console.WriteLine("Insert a valid Client ID");
                }
            }
        }



        public bool IdInLawyersList(List<Lawyer> list_of_lawyers, string input_id)
        {
            foreach (Lawyer l in list_of_lawyers)
            {
                if (input_id == l.EmployeeId)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IdInClientsList(List<Client> list_of_clients, string input_id)
        {
            foreach (Client c in list_of_clients)
            {
                if (input_id == c.ClientId)
                {
                    return true;
                }
            }
            return false;
        }

        public Case inputSimplified()
        {
            Console.Write("\n\n\n\n");
            Case input = new Case();
            PropertyInfo[] properties = typeof(Case).GetProperties();

            string value;
            bool correct = false;
            string correct_string = "N";

            while (!correct)
            {
                foreach (PropertyInfo p in properties)
                {
                    Console.WriteLine($"Input property");
                    value = Console.ReadLine();
                    p.SetValue(input, value);
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


                l.Id = columns[0];
                l.Name = columns[1];
                l.DOB = columns[2];
                l.YearsofExperience = columns[3];
                l.Specialization = columns[4];
                l.JoinedDate = columns[5];
                l.OtherExpertise = columns[6];

                lawyers.Add(l);

            }

            return lawyers;

        }
        public List<Client> AddNewClient(List<Client> list_of_clients)
        {
            // Id, Firstname, MiddleName, Lastname, DOB, CaseType, Street, Street Nr, Zip, City
            Client input_client = new Client();

            bool correct = false;
            string correct_string;

            while (!correct)
            {
                Console.WriteLine("Input Id");
                input_client.ClientId = Console.ReadLine();

                Console.WriteLine("Input FirstName");
                input_client.FirstName = Console.ReadLine();

                Console.WriteLine("Input Middlename");
                input_client.MiddleName = Console.ReadLine();

                Console.WriteLine("Input Lastname");
                input_client.LastName = Console.ReadLine();

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

                ListClients(new List<Client> { input_client });

                Console.WriteLine("\nIs it Correct? (y/N)");
                correct_string = Console.ReadLine();
                if (correct_string == "y")
                {
                    correct = true;
                }
            }

            list_of_clients.Add(input_client);
            return list_of_clients;
        }



        public List<Appointment> AddNewAppointment(List<Appointment> list_of_appointments)
        {
            //Id, ClientId, LawyerId, DateTime, MeetingRoom, ShortDescription
            Appointment input_appointment = new Appointment();

            bool correct = false;
            string correct_string;

            while (!correct)
            {
                Console.WriteLine("Input Id");
                input_appointment.Id = Console.ReadLine();

                Console.WriteLine("Input ClientId");
                ListClients(clientsList);
                input_appointment.ClientId = Console.ReadLine();

                listLawyers(listLawyers);

                Console.WriteLine("Input LawyerId");
                input_appointment.LawyerId = Console.ReadLine();

                Console.WriteLine("Input DateTime");
                input_appointment.DateTime = Console.ReadLine();

                Console.WriteLine("Input MeetingRoom");
                input_appointment.MeetingRoom = Console.ReadLine();

                Console.WriteLine("Input ShortDescription");
                input_appointment.ShortDescription = Console.ReadLine();

                Console.WriteLine("The input Appointment is:\n");

                listAppointments(new List<Appointment> { input_appointment });

                Console.WriteLine("\nIs it Correct? (y/N)");
                correct_string = Console.ReadLine();
                if (correct_string == "y")
                {
                    correct = true;
                }
            }

            list_of_appointments.Add(input_appointment);
            return list_of_appointments;
        }



        public List<Case> AddNewCase(List<Case> list_of_cases)
        {
            Case input_case = new Case();

            bool correct = false;
            bool finished = false;
            string correct_string;

            while (!correct)
            {
                Console.WriteLine("Input Id");
                input_case.Id = Console.ReadLine();

                Console.WriteLine("Input ClientId");
                input_case.ClientId = Console.ReadLine();

                Console.WriteLine("Input CaseType");
                Console.WriteLine("1. Corporate \n2. Family \n3. Criminal");
                string casetype_str = Console.ReadLine();

                finished = false;
                while (!finished)
                {
                    switch (casetype_str)
                    {
                        case "1":
                            input_case.CaseType = "Corporate";
                            finished = true;
                            break;
                        case "2":
                            input_case.CaseType = "Family";
                            finished = true;
                            break;
                        case "3":
                            input_case.CaseType = "Criminal";
                            finished = true;
                            break;
                        default:
                            Console.WriteLine("Choose between 1, 2 and 3");
                            break;
                    }
                }

                Console.WriteLine("Input StartDate");
                input_case.StartDate = Console.ReadLine();

                Console.WriteLine("Input ExpectedProcessDuration");
                input_case.ExpectedProcessDuration = Console.ReadLine();

                Console.WriteLine("Input TotalCharges");
                input_case.TotalCharges = Console.ReadLine();

                Console.WriteLine("Input LawyerId");
                input_case.SituationDescription = Console.ReadLine();

                Console.WriteLine("Input SituationDescription");
                input_case.SituationDescription = Console.ReadLine();

                Console.WriteLine("Input OtherNotes");
                input_case.OtherNotes = Console.ReadLine();

                Console.WriteLine("The input Appointment is:\n");

                ListCases(new List<Case> { input_case });

                Console.WriteLine("\nIs it Correct? (y/N)");
                correct_string = Console.ReadLine();
                if (correct_string == "y")
                {
                    correct = true;
                }
            }

            list_of_cases.Add(input_case);
            return list_of_cases;
        }


        public void ListClients(List<Client> list_of_clients)
        {
            Console.WriteLine(new string('.', 111));
            Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|{8,10}|{9,10}|", "ClientId", "FirstName", "MiddleName", "LastName", "DOB", "CaseType", "Street", "Street_Nr", "Zip", "City"));
            Console.WriteLine(new string('.', 111));

            foreach (Client c in list_of_clients)
            {
                Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|{8,10}|{9,10}|", c.ClientId, c.FirstName, c.MiddleName, c.LastName, c.DOB, c.CaseType, c.Street, c.Street_Nr, c.Zip, c.City));
                Console.WriteLine(new string('.', 111));
            }
        }

        public void ListCases(List<Case> list_of_cases)
        {
            Console.WriteLine(new string('.', 100));
            Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|{8,10}|", "Id", "ClientId", "CaseType", "StartDate", "Ex.Pr.Dur.", "T.Charges", "LawyerId", "Sit.Desc.", "OtherNotes"));
            Console.WriteLine(new string('.', 100));

            foreach (Case c in list_of_cases)
            {
                Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|{8,10}|", c.Id, c.ClientId, c.CaseType, c.StartDate, c.ExpectedProcessDuration, c.TotalCharges, c.LawyerId, c.SituationDescription, c.OtherNotes));
                Console.WriteLine(new string('.', 100));
            }
        }


        public void listAppointments(List<Appointment> list_of_appointments)
        {
            Console.WriteLine(new string('.', 67));
            Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|", "Id", "ClientId", "LawyerId", "DateTime", "MeetingRoom", "ShortDescription"));
            Console.WriteLine(new string('.', 67));

            foreach (Appointment a in list_of_appointments)
            {
                Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|", a.Id, a.ClientId, a.LawyerId, a.DateTime, a.MeetingRoom, a.ShortDescription));
                Console.WriteLine(new string('.', 67));
            }
        }

        public void listLawyers(List<Lawyer> list_of_lawyers)
        {
            Console.WriteLine(new string('.', 78));
            Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|", "Emp.ID", "Name", "DOB", "YOE", "Specializ.", "OtherExp."));
            Console.WriteLine(new string('.', 78));

            foreach (Lawyer l in list_of_lawyers)
            {
                Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|", l.Id, l.Name, l.DOB, l.YearsofExperience, l.Specialization, l.OtherExpertise));
                Console.WriteLine(new string('.', 78));
            }
        }



    }
}