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
                l.DOB = DateTime.ParseExact(columns[2], "yyyy-MM-dd", null);
                l.YearsofExperience = columns[3];
                // Parsing the string into the enum type
                l.Specialization = (ECaseType)Enum.Parse(typeof(ECaseType), columns[4], true);
                l.JoinedDate = DateTime.ParseExact(columns[5], "yyyy-MM-dd", null);
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
                input_client.ClientId = input_valid_clientid(list_of_clients, true);

                Console.WriteLine("Input FirstName");
                input_client.FirstName = Console.ReadLine();

                Console.WriteLine("Input Middlename");
                input_client.MiddleName = Console.ReadLine();

                Console.WriteLine("Input Lastname");
                input_client.LastName = Console.ReadLine();

                input_client.DOB = input_valid_date();

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


        public string input_valid_clientid(List<Client> list_of_clients, bool registration = false)
        {
            if (registration)
            {
                bool found_repeated;
                while (true)
                {
                    Console.WriteLine("Input ClientId");
                    string input_cid = Console.ReadLine();
                    found_repeated = false;
                    foreach (Client c in list_of_clients)
                    {
                        if (c.ClientId == input_cid)
                        {
                            Console.WriteLine("There is already a Client registered with this ID");
                            found_repeated = true;
                            break;
                        }
                    }
                    if (!found_repeated)
                    {
                        return input_cid;
                    }
                }
            }

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

        public string input_valid_lawyerid(List<Lawyer> list_of_lawyers, List<Client> list_of_clients, string input_client_id)
        {

            ECaseType needed_expertise = ECaseType.Corporate; // placeholder value
            // getting casetype from Client in order to suggest expert lawyers
            foreach (Client c in list_of_clients)
            {
                if (c.ClientId == input_client_id)
                {
                    needed_expertise = c.CaseType;
                    break;
                }
            }

            while (true)
            {
                displayListContents(list_of_lawyers, needed_expertise);
                Console.WriteLine("Input LawyerId");
                string input_lid = Console.ReadLine();

                foreach (Lawyer l in list_of_lawyers)
                {
                    if (l.EmployeeId == input_lid && l.Specialization == needed_expertise)
                    {
                        return input_lid;
                    }
                }
                Console.WriteLine("Input the LawyerId from one of the available lawyers");
            }
        }


        public string input_valid_appointmentid(List<Appointment> list_of_appointments)
        {
            bool found_repeated;
            while (true)
            {
                Console.WriteLine("Input the ID of the new appointment");
                string input_aid = Console.ReadLine();
                found_repeated = false;
                foreach (Appointment a in list_of_appointments)
                {
                    if (a.Id == input_aid)
                    {
                        Console.WriteLine("\nThere is already an Appointment registered with this ID\n");
                        found_repeated = true;
                        break;
                    }
                }
                if (!found_repeated)
                {
                    return input_aid;
                }
            }
        }

        public string input_valid_caseid(List<Case> list_of_cases)
        {
            bool found_repeated;
            while (true)
            {
                Console.WriteLine("Input the ID of the new Case");
                string input_cid = Console.ReadLine();
                found_repeated = false;
                foreach (Case c in list_of_cases)
                {
                    if (c.Id == input_cid)
                    {
                        Console.WriteLine("\nThere is already a Case registered with this ID\n");
                        found_repeated = true;
                        break;
                    }
                }
                if (!found_repeated)
                {
                    return input_cid;
                }
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

        public DateTime input_valid_date(bool includeTime = false)
        {
            while (true)
            {
                DateTime input_datetime;
                try
                {
                    if (!includeTime)
                    {
                        Console.WriteLine("Input Date (yyyy-mm-dd)");
                        input_datetime = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);
                        return input_datetime;
                    }
                    else
                    {
                        Console.WriteLine("Input Date and Time (yyyy-mm-dd HH:MM)");
                        input_datetime = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null);
                        return input_datetime;

                    }
                }
                catch
                {
                    Console.WriteLine("\nInput a valid date\n");
                }
            }
        }


        public List<Appointment> AddNewAppointment(List<Appointment> list_of_appointments, List<Lawyer> firm_lawyers, List<Client> current_clients)
        {
            Appointment input_appointment = new Appointment();
            bool correct = false;
            string correct_string;

            while (!correct)
            {
                input_appointment.Id = input_valid_appointmentid(list_of_appointments);

                input_appointment.ClientId = input_valid_clientid(current_clients);
                input_appointment.LawyerId = input_valid_lawyerid(firm_lawyers, current_clients, input_appointment.ClientId);

                input_appointment.DateTime = input_valid_date(true);

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
                input_case.Id = input_valid_caseid(list_of_cases);

                input_case.ClientId = input_valid_clientid(current_clients);

                input_case.StartDate = input_valid_date();

                Console.WriteLine("Input ExpectedProcessDuration");
                input_case.ExpectedProcessDuration = Console.ReadLine();

                Console.WriteLine("Input TotalCharges");
                input_case.TotalCharges = Console.ReadLine();

                input_case.LawyerId = input_valid_lawyerid(firm_lawyers, current_clients, input_case.ClientId);

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
            if (list_of_clients.Any())
            {
                Console.WriteLine(new string('.', 111));
                Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|{8,10}|{9,10}|", "ClientId", "FirstName", "MiddleName", "LastName", "DOB", "CaseType", "Street", "Street_Nr", "Zip", "City"));
                Console.WriteLine(new string('.', 111));

                foreach (Client c in list_of_clients)
                {
                    Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|{8,10}|{9,10}|", c.ClientId.Truncate(10), c.FirstName.Truncate(10), c.MiddleName.Truncate(10), c.LastName.Truncate(10), c.DOB.ToShortDateString(), c.CaseType, c.Street.Truncate(10), c.Street_Nr.Truncate(10), c.Zip.Truncate(10), c.City.Truncate(10)));
                    Console.WriteLine(new string('.', 111));
                }
            }
            else
            {
                Console.WriteLine("\nThere are no registered clients\n");
            }
        }

        public void displayListContents(List<Case> list_of_cases)
        {
            if (list_of_cases.Any())
            {
                Console.WriteLine(new string('.', 100));
                Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,25}|{8,20}|", "Id", "ClientId", "CaseType", "StartDate", "Ex.Pr.Dur.", "T.Charges", "LawyerId", "Sit.Desc.", "OtherNotes"));
                Console.WriteLine(new string('.', 100));

                foreach (Case c in list_of_cases)
                {
                    Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,25}|{8,20}|", c.Id.Truncate(10), c.ClientId.Truncate(10), c.CaseType, c.StartDate.ToShortDateString(), c.ExpectedProcessDuration.Truncate(10), c.TotalCharges.Truncate(10), c.LawyerId.Truncate(10), c.SituationDescription.Truncate(25), c.OtherNotes.Truncate(20)));
                    Console.WriteLine(new string('.', 100));
                }
            }
            else
            {
                Console.WriteLine("\nThere are no registered cases\n");
            }
        }


        public void displayListContents(List<Appointment> list_of_appointments)
        {
            if (list_of_appointments.Any())
            {
                Console.WriteLine(new string('.', 67));
                Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,22}|{4,11}|{5,25}|", "Id", "ClientId", "LawyerId", "DateTime", "MeetingRoom", "ShortDescription"));
                Console.WriteLine(new string('.', 67));

                foreach (Appointment a in list_of_appointments)
                {
                    Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,22}|{4,11}|{5,25}|", a.Id.Truncate(10), a.ClientId.Truncate(10), a.LawyerId.Truncate(10), a.DateTime, a.MeetingRoom, a.ShortDescription.Truncate(25)));
                    Console.WriteLine(new string('.', 67));
                }
            }
            else
            {
                Console.WriteLine("\nThere are no scheduled appointments\n");
            }
        }

        public void displayListContents(List<Lawyer> list_of_lawyers)
        {
            if (list_of_lawyers.Any())
            {
                Console.WriteLine(new string('.', 113));
                Console.WriteLine(String.Format("|{0,10}|{1,20}|{2,10}|{3,10}|{4,15}|{5,10}|{6,30}|", "Emp.ID", "Name", "DOB", "YOE", "Specializ.", "JoinDate", "OtherExp."));
                Console.WriteLine(new string('.', 113));

                foreach (Lawyer l in list_of_lawyers)
                {
                    Console.WriteLine(String.Format("|{0,10}|{1,20}|{2,10}|{3,10}|{4,15}|{5,10}|{6,20}|", l.EmployeeId.Truncate(10), l.EmployeeName.Truncate(20), l.DOB.ToShortDateString(), l.YearsofExperience, l.Specialization, l.JoinedDate.ToShortDateString(), l.OtherExpertise.Truncate(20)));
                    Console.WriteLine(new string('.', 113));
                }
            }
            else
            {
                Console.WriteLine("\nThere are no registered lawyers\n");
            }
        }

        public void displayListContents(List<Lawyer> list_of_lawyers, ECaseType specialization)
        {
            if (list_of_lawyers.Any())
            {
                Console.WriteLine(new string('.', 113));
                Console.WriteLine(String.Format("|{0,10}|{1,20}|{2,10}|{3,10}|{4,15}|{5,10}|{6,30}|", "Emp.ID", "Name", "DOB", "YOE", "Specializ.", "JoinDate", "OtherExp."));
                Console.WriteLine(new string('.', 113));

                foreach (Lawyer l in list_of_lawyers)
                {
                    if (l.Specialization == specialization)
                    {
                        Console.WriteLine(String.Format("|{0,10}|{1,20}|{2,10}|{3,10}|{4,15}|{5,10}|{6,30}|", l.EmployeeId, l.EmployeeName, l.DOB.ToShortDateString(), l.YearsofExperience, l.Specialization, l.JoinedDate.ToShortDateString(), l.OtherExpertise));
                        Console.WriteLine(new string('.', 113));
                    }
                }
            }
            else
            {
                Console.WriteLine("\nThere are no registered lawyers\n");
            }
        }



    }
    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}