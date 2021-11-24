using System;
using System.Reflection;
namespace third
{


    public class Processor
    {
        public List<Lawyer> lawyersList = new List<Lawyer>();
        public List<Case> casesList = new List<Case>();
        public List<Client> clientsList = new List<Client>();
        public List<Appointment> appointmentList = new List<Appointment>();
        public List<Administration> administrationList = new List<Administration>();
        public List<Receptionist> receptionistList = new List<Receptionist>();


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


        public Case inputCase()
        {
            // Id, CustomerId, CaseType(Corporate, Family or Criminal), StartDate, ExpectedProcessDuration,TotalCharges, LawyerId, SituationDescription, OtherNotes 
            Case input_case = new Case();

            bool correct = false;
            string correct_string;

            while (!correct)
            {
                Console.WriteLine("Input Id");
                input_case.Id = Console.ReadLine();

                Console.WriteLine("Input CustomerId");
                input_case.CustomerId = Console.ReadLine();

                Console.WriteLine("Input CaseType");
                Console.WriteLine("1. Corporate \n2. Family \n3. Criminal");
                input_case.CaseType = Console.ReadLine();

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
                Console.WriteLine($"Id\t CustomerId\t CaseType\t StartDate\t ExpectedProcessDuration\t TotalCharges\t LawyerId\t SituationDescription\t OtherNotes");

                Console.WriteLine($"{input_case.Id}\t {input_case.CustomerId}\t {input_case.CaseType}\t {input_case.StartDate}\t {input_case.ExpectedProcessDuration}\t {input_case.TotalCharges}\t {input_case.LawyerId}\t {input_case.SituationDescription}\t {input_case.OtherNotes}");


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

            Console.WriteLine($"Id\t Firstname\t MiddleName\t Lastname\t DOB\t CaseType\t Street\t Street_Nr\t Zip\t City\t ");
            foreach (Client c in list_of_clients)
            {
                Console.WriteLine($"{c.Id}\t {c.FirstName}\t {c.MiddleName}\t {c.LastName}\t {c.DOB}\t {c.CaseType}\t {c.Street}\t {c.Street_Nr}\t {c.Zip}\t {c.City}\t ");
            }

        }

        void ListCases(List<Case> list_of_cases)
        {
            Console.WriteLine($"Id\t CustomerId\t CaseType\t StartDate\t ExpectedProcessDuration\t TotalCharges\t LawyerId\t SituationDescription\t OtherNotes\t");
            foreach (Case c in list_of_cases)
            {
                Console.WriteLine($"{c.CustomerId}\t {c.CaseType}\t {c.StartDate}\t {c.ExpectedProcessDuration}\t {c.TotalCharges}\t {c.LawyerId}\t {c.SituationDescription}\t {c.OtherNotes}");
            }
        }



        void listAppointments(List<Appointment> list_of_appointments)
        {

            Console.WriteLine($"Id\t ClientId\t LawyerId\t DateTime\t MeetingRoom\t ShortDescription");
            foreach (Appointment a in list_of_appointments)
            {
                Console.WriteLine($"{a.ClientId}\t {a.LawyerId}\t {a.DateTime}\t {a.MeetingRoom}\t {a.ShortDescription}");
            }

        }


        public void login()
        {
            bool all_finished = false;
            while (!all_finished)
            {
                /* When the application starts it presents three options 1. Lawyer 2. Admin 3. Receptionist */
                Console.WriteLine("Choose between:");
                Console.WriteLine(" 1. Receptionist");
                Console.WriteLine(" 2. Lawyer");
                Console.WriteLine(" 3. Admin");
                Console.WriteLine(" 4. Exit");
                int chosen_option = int.Parse(Console.ReadLine());


                /* After selecting one of the three roles. User is prompted with Login. User is asked username and
                password and if correct details are entered user is presented with the features available. */

                /*Console.WriteLine("Input your username:");
                string input_user = Console.ReadLine();
                Console.WriteLine("Input your password:");
                string input_password = Console.ReadLine();

                string allowed_user = "user";
                string allowed_password = "pw";*/

                //if (input_password == allowed_password && input_user == allowed_user)
                /* After successful login, a list of choices is presented. */
                if (chosen_option == 1)
                {
                    /* o Receptionist can perform following features.
                        § Register a new client
                        § Add a new Appointment
                        § List all appointments
                        § List all clients */

                    bool finished = false;
                    int receptionist_option;

                    while (!finished)
                    {
                        Console.WriteLine(finished);
                        Console.WriteLine("Choose between the possible options for recptionists:");
                        Console.WriteLine(" 1. Register a new client");
                        Console.WriteLine(" 2. Add a new appointment");
                        Console.WriteLine(" 3. List all appointments");
                        Console.WriteLine(" 4. List all clients");
                        Console.WriteLine(" 5. Exit");
                        receptionist_option = int.Parse(Console.ReadLine());
                        switch (receptionist_option)
                        {
                            case 1:
                                // add a new client - IMPLEMENT
                                Client cli = inputClient();
                                clientsList = AddNewClient(clientsList, cli);
                                break;
                            case 2:
                                // add a new appointment - IMPLEMENT
                                Appointment app = inputAppointment();
                                appointmentList = AddNewAppointment(appointmentList, app);
                                break;
                            case 3:
                                listAppointments(appointmentList);
                                break;
                            case 4:
                                ListClients(clientsList);
                                break;
                            case 5:
                                finished = true;
                                break;
                            default:
                                Console.WriteLine("Choose between 1, 2, 3 and 4");
                                break;
                        }
                    }
                }
                else if (chosen_option == 2)
                {
                    /*o Lawyer should be able to perform following tasks
                    § List all Cases
                    § Add a new Case
                    § List all appointments*/
                    bool finished = false;
                    int lawyer_option;
                    while (!finished)
                    {
                        Console.WriteLine("Choose between the possible options for Lawyers:");
                        Console.WriteLine(" 1. List all cases");
                        Console.WriteLine(" 2. Add a new case");
                        Console.WriteLine(" 3. List all appointments");
                        Console.WriteLine(" 4. Exit");
                        lawyer_option = int.Parse(Console.ReadLine());

                        switch (lawyer_option)
                        {
                            case 1:
                                ListCases(casesList);
                                break;
                            case 2:
                                // add a new case - IMPLEMENT
                                Case cas = inputCase();
                                casesList = AddNewCase(casesList, cas);
                                break;
                            case 3:
                                listAppointments(appointmentList);
                                break;
                            case 4:
                                finished = true;
                                break;
                            default:
                                Console.WriteLine("Choose between 1, 2 and 3");
                                break;
                        }
                    }
                }
                else if (chosen_option == 3)
                {
                    /*o Admin staff should be able to perform following tasks:
                    § List all Cases
                    § List all appointments */

                    int admin_option;
                    bool finished = false;

                    while (!finished)
                    {
                        Console.WriteLine("Choose between the possible options for Admins:");
                        Console.WriteLine(" 1. List all cases");
                        Console.WriteLine(" 2. List all appointments");
                        Console.WriteLine(" 3. Exit");

                        admin_option = int.Parse(Console.ReadLine());

                        switch (admin_option)
                        {
                            case 1:
                                ListCases(casesList);
                                break;
                            case 2:
                                listAppointments(appointmentList);
                                break;
                            case 3:
                                finished = true;
                                break;
                            default:
                                Console.WriteLine("Choose between 1 and 2");
                                break;
                        }
                    }

                }
                else if (chosen_option == 4)
                {
                    all_finished = true;
                }
            }
        }
    }

    public class Program
    {

        static void Main(string[] args)
        {
            Processor myProc = new Processor();
            myProc.lawyersList = myProc.ImportFile("lawyers_database.csv");
            myProc.login();
        }
    }
}