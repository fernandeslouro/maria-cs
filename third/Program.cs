using System;
using System.Collections.Generic;
using System.Linq;
namespace third
{
    public class Processor : functions
    {
        public List<Client> clientsList = new List<Client>();
        public List<Case> casesList = new List<Case>();
        public List<Appointment> appointmentList = new List<Appointment>();
        public List<Administration> administrationList = new List<Administration>();
        public List<Receptionist> receptionistList = new List<Receptionist>();

        public bool allow_access(string user_type)
        {
            Console.WriteLine("Input your username:");
            string input_user = Console.ReadLine();
            Console.WriteLine("Input your password:");
            string input_password = Console.ReadLine();

            string receptionist_user = "receptionist";
            string receptionist_password = "receptionistpw";
            string lawyer_user = "lawyer";
            string lawyer_password = "lawyerpw";
            string admin_user = "admin";
            string admin_password = "adminpw";

            switch (user_type)
            {
                case "receptionist":
                    if (input_user == receptionist_user && input_password == receptionist_password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "lawyer":
                    if (input_user == lawyer_user && input_password == lawyer_password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "admin":
                    if (input_user == admin_user && input_password == admin_password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                default:
                    return false;
            }

        }

        public void login()
        {

            List<Lawyer> lawyersList = ImportFile("lawyers_database.csv");
            bool all_finished = false;
            bool finished = false;
            while (!all_finished)
            {
                /* When the application starts it presents three options 1. Lawyer 2. Admin 3. Receptionist */
                Console.WriteLine("Choose between:");
                Console.WriteLine(" 1. Receptionist");
                Console.WriteLine(" 2. Lawyer");
                Console.WriteLine(" 3. Admin");
                Console.WriteLine(" 4. Exit");
                string chosen_option = Console.ReadLine();

                switch (chosen_option)
                {

                    /* After selecting one of the three roles. User is prompted with Login. User is asked username and
                    password and if correct details are entered user is presented with the features available. */



                    // After successful login, a list of choices is presented.
                    case "1":
                        if (allow_access("receptionist"))
                        {
                            /* o Receptionist can perform following features.
                                § Register a new client
                                § Add a new Appointment
                                § List all appointments
                                § List all clients */

                            finished = false;
                            string receptionist_option;

                            while (!finished)
                            {
                                Console.WriteLine("Choose between the possible options for recptionists:");
                                Console.WriteLine(" 1. Register a new client");
                                Console.WriteLine(" 2. Add a new appointment");
                                Console.WriteLine(" 3. List all appointments");
                                Console.WriteLine(" 4. List all clients");
                                Console.WriteLine(" 5. Exit");
                                receptionist_option = Console.ReadLine();
                                switch (receptionist_option)
                                {
                                    case "1":
                                        clientsList = AddNewClient(clientsList);
                                        break;
                                    case "2":
                                        if (!clientsList.Any())
                                        {
                                            Console.WriteLine("It is not possible to book an appointment when there are no registered clients.\nRegister a Client first.");
                                        }
                                        else
                                        {
                                            appointmentList = AddNewAppointment(appointmentList, lawyersList, clientsList);
                                        }
                                        break;
                                    case "3":
                                        displayListContents(appointmentList);
                                        break;
                                    case "4":
                                        displayListContents(clientsList);
                                        break;
                                    case "5":
                                        finished = true;
                                        break;
                                    default:
                                        Console.WriteLine("Choose between 1, 2, 3 and 4");
                                        break;
                                }
                            }
                        }
                        break;
                    case "2":
                        if (allow_access("lawyer"))
                        {
                            /*o Lawyer should be able to perform following tasks
                            § List all Cases
                            § Add a new Case
                            § List all appointments*/
                            finished = false;
                            string lawyer_option;
                            while (!finished)
                            {
                                Console.WriteLine("Choose between the possible options for Lawyers:");
                                Console.WriteLine(" 1. List all cases");
                                Console.WriteLine(" 2. Add a new case");
                                Console.WriteLine(" 3. List all appointments");
                                Console.WriteLine(" 4. Exit");
                                lawyer_option = Console.ReadLine();

                                switch (lawyer_option)
                                {
                                    case "1":
                                        displayListContents(casesList);
                                        break;
                                    case "2":
                                        if (!clientsList.Any())
                                        {
                                            Console.WriteLine("It is not possible to book an appointment when there are no registered clients.\nRegister a Client first.");
                                        }
                                        else
                                        {
                                            casesList = AddNewCase(casesList, lawyersList, clientsList);
                                        }
                                        break;
                                    case "3":
                                        displayListContents(appointmentList);
                                        break;
                                    case "4":
                                        finished = true;
                                        break;
                                    default:
                                        Console.WriteLine("Choose between 1, 2 and 3");
                                        break;
                                }
                            }
                        }
                        break;
                    case "3":
                        if (allow_access("admin"))
                        {
                            /*o Admin staff should be able to perform following tasks:
                            § List all Cases
                            § List all appointments */

                            string admin_option;
                            finished = false;

                            while (!finished)
                            {
                                Console.WriteLine("Choose between the possible options for Admins:");
                                Console.WriteLine(" 1. List all cases");
                                Console.WriteLine(" 2. List all appointments");
                                Console.WriteLine(" 3. Exit");

                                admin_option = Console.ReadLine();

                                switch (admin_option)
                                {
                                    case "1":
                                        displayListContents(casesList);
                                        break;
                                    case "2":
                                        displayListContents(appointmentList);
                                        break;
                                    case "3":
                                        finished = true;
                                        break;
                                    default:
                                        Console.WriteLine("Choose between 1 and 2");
                                        break;
                                }
                            }
                        }
                        break;
                    case "4":
                        all_finished = true;
                        break;
                    default:
                        Console.WriteLine("Insert a valid option");
                        break;
                }
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Processor myProc = new Processor();

            myProc.login();

        }
    }

}