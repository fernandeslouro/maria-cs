using System;
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




        public void login()
        {
            /* When the application starts it presents three options 1. Lawyer 2. Admin 3. Receptionist */
            Console.WriteLine("Choose between:");
            Console.WriteLine(" 1. Lawyer");
            Console.WriteLine(" 2. Admin");
            Console.WriteLine(" 3. Receptionist");
            int option = int.Parse(Console.ReadLine());


            /* After selecting one of the three roles. User is prompted with Login. User is asked username and
            password and if correct details are entered user is presented with the features available. */
            Console.WriteLine("Input your username:");
            string input_user = Console.ReadLine();
            Console.WriteLine("Input your password:");
            string input_password = Console.ReadLine();

            string allowed_user = "user";
            string allowed_password = "pw";

            if (input_password == allowed_password && input_user == allowed_user)
            {
                function_usage(option);
            }
        }

        void function_usage(int chosen_option)
        {
            /* After successful login, a list of choices is presented. */
            if (chosen_option == 1)
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
                int receptionist_option = int.Parse(Console.ReadLine());

                if (receptionist_option == 1)
                {
                    // add a new client - IMPLEMENT
                }
                else if (receptionist_option == 2)
                {
                    // add a new appointment - IMPLEMENT
                }
                else if (receptionist_option == 3)
                {
                    listAppointments(appointmentList);
                }
                else if (receptionist_option == 4)
                {
                    ListClients(clientsList);
                }
                else
                {
                    Console.WriteLine("Choose between 1, 2, 3 and 4");
                }



            }
            else if (chosen_option == 2)
            {
                /*o Lawyer should be able to perform following tasks
                § List all Cases
                § Add a new Case
                § List all appointments*/
                Console.WriteLine("Choose between the possible options for Lawyers:");
                Console.WriteLine(" 1. List all cases");
                Console.WriteLine(" 2. Add a new case");
                Console.WriteLine(" 3. List all appointments");
                int lawyer_option = int.Parse(Console.ReadLine());

                if (lawyer_option == 1)
                {
                    ListCases(casesList);
                }
                else if (lawyer_option == 2)
                {
                    // add a new case - IMPLEMENT
                }
                else if (lawyer_option == 3)
                {
                    listAppointments(appointmentList);
                }
                else
                {
                    Console.WriteLine("Choose between 1, 2 and 3");
                }
            }
            else if (chosen_option == 3)
            {
                /*o Admin staff should be able to perform following tasks:
                § List all Cases
                § List all appointments */

                Console.WriteLine("Choose between the possible options for Admins:");
                Console.WriteLine(" 1. List all cases");
                Console.WriteLine(" 2. List all appointments");
                int admin_option = int.Parse(Console.ReadLine());
                if (admin_option == 1)
                {
                    ListCases(casesList);
                }
                else if (admin_option == 2)
                {
                    listAppointments(appointmentList);
                }
                else
                {
                    Console.WriteLine("Choose between 1 and 2");
                }


            }
        }
    }

    public class Program
    {

        static void Main(string[] args)
        {
            Processor myProc = new Processor();
            Console.WriteLine("ayy");
            myProc.lawyersList = myProc.ImportFile("lawyers_database.csv");
            myProc.login();
        }
    }
}