
using System.Reflection;
namespace third
{
    public class functions
    {
        public Client inputClient()
        {
            // Id, Firstname, MiddleName, Lastname, DOB, CaseType, Street, Street Nr, Zip, City
            Client input_client = new Client();

            bool correct = false;
            string correct_string;

            while (!correct)
            {
                Console.WriteLine("Input Id");
                input_client.Id = Console.ReadLine();

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
                Console.WriteLine($"Id\t Firstname\t MiddleName\t Lastname\t DOB\t CaseType\t Street\t Street_Nr\t Zip\t City\t ");
                Console.WriteLine($"{input_client.Id}\t {input_client.FirstName}\t {input_client.MiddleName}\t {input_client.LastName}\t {input_client.DOB}\t {input_client.CaseType}\t {input_client.Street}\t {input_client.Street_Nr}\t {input_client.Zip}\t {input_client.City}\t ");

                Console.WriteLine("\nIs it Correct? (y/N)");
                correct_string = Console.ReadLine();
                if (correct_string == "y")
                {
                    correct = true;
                }
            }
            return input_client;
        }


        public Appointment inputAppointment()
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
                input_appointment.ClientId = Console.ReadLine();

                Console.WriteLine("Input LawyerId");
                input_appointment.LawyerId = Console.ReadLine();

                Console.WriteLine("Input DateTime");
                input_appointment.DateTime = Console.ReadLine();

                Console.WriteLine("Input MeetingRoom");
                input_appointment.MeetingRoom = Console.ReadLine();

                Console.WriteLine("Input ShortDescription");
                input_appointment.ShortDescription = Console.ReadLine();

                Console.WriteLine("The input Appointment is:\n");

                Console.WriteLine($"Id\t ClientId\t LawyerId\t DateTime\t MeetingRoom\t ShortDescription");
                Console.WriteLine($"{input_appointment.ClientId}\t {input_appointment.LawyerId}\t {input_appointment.DateTime}\t {input_appointment.MeetingRoom}\t {input_appointment.ShortDescription}");

                Console.WriteLine("\nIs it Correct? (y/N)");
                correct_string = Console.ReadLine();
                if (correct_string == "y")
                {
                    correct = true;
                }
            }
            return input_appointment;
        }


        public void printSpecialistLawyers(List<Lawyer> lawyers_list, string specialization)
        {

        }
        public Case inputCase()
        {
            // Id, ClientId, CaseType(Corporate, Family or Criminal), StartDate, ExpectedProcessDuration,TotalCharges, LawyerId, SituationDescription, OtherNotes 
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
                Console.WriteLine($"Id\t ClientId\t CaseType\t StartDate\t ExpectedProcessDuration\t TotalCharges\t LawyerId\t SituationDescription\t OtherNotes");


                Console.WriteLine(new string('.', 90)); 

                Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|{8,10}|","Id", "ClientId", "CaseType", "StartDate", "Ex.P.Dur.", "T. Charges", "LawyerId", "Sit. Desc", "OtherNotes"));

                Console.WriteLine(new string('.', 90)); 
                Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|{8,10}|",input_case.Id, input_case.ClientId, input_case.CaseType, input_case.StartDate, input_case.ExpectedProcessDuration, input_case.TotalCharges, input_case.LawyerId, input_case.SituationDescription, input_case.OtherNotes));


                Console.WriteLine(new string('.', 90)); 

                Console.WriteLine("\nIs it Correct? (y/N)");
                correct_string = Console.ReadLine();
                if (correct_string == "y")
                {
                    correct = true;
                }
            }
            return input_case;
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


                l.EmployeeId = columns[0];
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


        public void ListClients(List<Client> list_of_clients)
        {
            Console.WriteLine($"Id\t Firstname\t MiddleName\t Lastname\t DOB\t CaseType\t Street\t Street_Nr\t Zip\t City\t ");
            foreach (Client c in list_of_clients)
            {
                Console.WriteLine($"{c.Id}\t {c.FirstName}\t {c.MiddleName}\t {c.LastName}\t {c.DOB}\t {c.CaseType}\t {c.Street}\t {c.Street_Nr}\t {c.Zip}\t {c.City}\t ");
            }
        }

        public void ListCases(List<Case> list_of_cases)
        {
            Console.WriteLine($"Id\t ClientId\t CaseType\t StartDate\t ExpectedProcessDuration\t TotalCharges\t LawyerId\t SituationDescription\t OtherNotes\t");
            foreach (Case c in list_of_cases)
            {
                Console.WriteLine($"{c.ClientId}\t {c.CaseType}\t {c.StartDate}\t {c.ExpectedProcessDuration}\t {c.TotalCharges}\t {c.LawyerId}\t {c.SituationDescription}\t {c.OtherNotes}");
            }
        }



        public void listAppointments(List<Appointment> list_of_appointments)
        {

            Console.WriteLine($"Id\t ClientId\t LawyerId\t DateTime\t MeetingRoom\t ShortDescription");
            foreach (Appointment a in list_of_appointments)
            {
                Console.WriteLine($"{a.ClientId}\t {a.LawyerId}\t {a.DateTime}\t {a.MeetingRoom}\t {a.ShortDescription}");
            }

        }

    }
}