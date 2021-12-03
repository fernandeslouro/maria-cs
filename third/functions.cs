using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
namespace third
{
    public abstract class functions
    {

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
                l.EmployeeName = columns[1];
                l.DOB = columns[2];
                l.YearsofExperience = columns[3];
                // Parsing the string into the enum type
                l.Specialization = (ECaseType) Enum.Parse(typeof(ECaseType), columns[4], true);
                l.JoinedDate = columns[5];
                l.OtherExpertise = columns[6];

                lawyers.Add(l);

            }

            return lawyers;
        }

        public List<Client> AddNewClient(List<Client> list_of_clients)
        {
            Client input_client = new Client();
            bool correct = false;
            string correct_string;

            while (!correct)
            {
                Console.WriteLine("Input the Id of the new Client");
                input_client.ClientId = Console.ReadLine();

                Console.WriteLine("Input FirstName");
                input_client.FirstName = Console.ReadLine();

                Console.WriteLine("Input Middlename");
                input_client.MiddleName = Console.ReadLine();

                Console.WriteLine("Input Lastname");
                input_client.LastName = Console.ReadLine();

                Console.WriteLine("Input DOB");
                input_client.DOB = Console.ReadLine();

                input_client.CaseType = input_valid_casetype();

                Console.WriteLine("Input Street");
                input_client.Street = Console.ReadLine();

                Console.WriteLine("Input Street Nr");
                input_client.Street_Nr = Console.ReadLine();

                Console.WriteLine("Input Zip");
                input_client.Zip = Console.ReadLine();

                Console.WriteLine("Input City");
                input_client.City = Console.ReadLine();

                Console.WriteLine("The input Client is:\n");

                displayListContents(new List<Client> { input_client });

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


        public string input_valid_id(List<Client> list_of_clients)
        {
            while (true)
            {
                displayListContents(list_of_clients);
                Console.WriteLine("Input ClientId");
                string input_cid = Console.ReadLine();

                foreach (Client c in list_of_clients)
                {
                    if (c.ClientId == input_cid)
                    {
                        return input_cid;
                    }
                }
                Console.WriteLine("Input the ClientId from one of the available clients");
            }
        }

        public string input_valid_id(List<Lawyer> list_of_lawyers)
        {
            while (true)
            {
                displayListContents(list_of_lawyers);
                Console.WriteLine("Input LawyerId");
                string input_lid = Console.ReadLine();

                foreach (Lawyer l in list_of_lawyers)
                {
                    if (l.EmployeeId == input_lid)
                    {
                        return input_lid;
                    }
                }
                Console.WriteLine("Input the LawyerId from one of the available lawyers");
            }
        }



        public ECaseType input_valid_casetype()
        {
            while (true)
            {
                Console.WriteLine("Input CaseType");
                Console.WriteLine("1. Corporate \n2. Family \n3. Criminal");
                string casetype_str = Console.ReadLine();

                switch (casetype_str)
                {
                    case "1":
                        return ECaseType.Corporate;
                    case "2":
                        return ECaseType.Family;
                    case "3":
                        return ECaseType.Criminal;
                    default:
                        Console.WriteLine("Choose between 1, 2 and 3");
                        break;
                }
            }
        }
        public EMeetingRoom input_valid_meetingRoom()
        {
            while (true)
            {
                Console.WriteLine("Input MeetingRoom");
                Console.WriteLine("1. Acquarium \n2. Cube \n3. Cave");
                string meetingroom_str = Console.ReadLine();

                switch (meetingroom_str)
                {
                    case "1":
                        return EMeetingRoom.Acquarium;
                    case "2":
                        return EMeetingRoom.Cube;
                    case "3":
                        return EMeetingRoom.Cave;
                    default:
                        Console.WriteLine("Choose between 1, 2 and 3");
                        break;
                }
            }
        }

        public void input_valid_date(bool includeTime)
        {
            // TODO: Implement protection for dates
            Console.WriteLine("Input DateTime");
            //input_appointment.DateTime = Console.ReadLine();

        }


        public List<Appointment> AddNewAppointment(List<Appointment> list_of_appointments, List<Lawyer> firm_lawyers, List<Client> current_clients)
        {
            Appointment input_appointment = new Appointment();
            bool correct = false;
            string correct_string;

            while (!correct)
            {
                Console.WriteLine("Input the Id of the new Appointment");
                input_appointment.Id = Console.ReadLine();

                input_appointment.ClientId = input_valid_id(current_clients);
                input_appointment.LawyerId = input_valid_id(firm_lawyers);


                Console.WriteLine("Input DateTime");
                input_appointment.DateTime = Console.ReadLine();

                input_appointment.MeetingRoom = input_valid_meetingRoom();

                Console.WriteLine("Input ShortDescription");
                input_appointment.ShortDescription = Console.ReadLine();

                Console.WriteLine("The input Appointment is:\n");

                displayListContents(new List<Appointment> { input_appointment });

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



        public List<Case> AddNewCase(List<Case> list_of_cases, List<Lawyer> firm_lawyers, List<Client> current_clients)
        {
            Case input_case = new Case();
            bool correct = false;
            string correct_string;

            while (!correct)
            {
                Console.WriteLine("Input the Id of the new Case");
                input_case.Id = Console.ReadLine();

                input_case.ClientId = input_valid_id(current_clients);

                Console.WriteLine("Input StartDate");
                input_case.StartDate = Console.ReadLine();

                Console.WriteLine("Input ExpectedProcessDuration");
                input_case.ExpectedProcessDuration = Console.ReadLine();

                Console.WriteLine("Input TotalCharges");
                input_case.TotalCharges = Console.ReadLine();

                input_case.LawyerId = input_valid_id(firm_lawyers);

                Console.WriteLine("Input SituationDescription");
                input_case.SituationDescription = Console.ReadLine();

                Console.WriteLine("Input OtherNotes");
                input_case.OtherNotes = Console.ReadLine();

                Console.WriteLine("The input Appointment is:\n");

                displayListContents(new List<Case> { input_case });

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


        public void displayListContents(List<Client> list_of_clients)
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

        public void displayListContents(List<Case> list_of_cases)
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


        public void displayListContents(List<Appointment> list_of_appointments)
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

        public void displayListContents(List<Lawyer> list_of_lawyers)
        {
            Console.WriteLine(new string('.', 113));
            Console.WriteLine(String.Format("|{0,10}|{1,20}|{2,10}|{3,10}|{4,15}|{5,10}|{6,30}|", "Emp.ID", "Name", "DOB", "YOE", "Specializ.", "JoinDate", "OtherExp."));
            Console.WriteLine(new string('.', 113));

            foreach (Lawyer l in list_of_lawyers)
            {
                Console.WriteLine(String.Format("|{0,10}|{1,20}|{2,10}|{3,10}|{4,15}|{5,10}|{6,30}|", l.EmployeeId, l.EmployeeName, l.DOB, l.YearsofExperience, l.Specialization, l.JoinedDate, l.OtherExpertise));
                Console.WriteLine(new string('.', 113));
            }
        }

        public void displayListContents(List<Lawyer> list_of_lawyers, ECaseType specialization)
        {
            Console.WriteLine(new string('.', 113));
            Console.WriteLine(String.Format("|{0,10}|{1,20}|{2,10}|{3,10}|{4,15}|{5,10}|{6,30}|", "Emp.ID", "Name", "DOB", "YOE", "Specializ.", "JoinDate", "OtherExp."));
            Console.WriteLine(new string('.', 113));

            foreach (Lawyer l in list_of_lawyers)
            {
                if (l.Specialization == specialization)
                {
                    Console.WriteLine(String.Format("|{0,10}|{1,20}|{2,10}|{3,10}|{4,15}|{5,10}|{6,30}|", l.EmployeeId, l.EmployeeName, l.DOB, l.YearsofExperience, l.Specialization, l.JoinedDate, l.OtherExpertise));
                    Console.WriteLine(new string('.', 113));
                }
            }
        }



    }
}