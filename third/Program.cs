using System;
namespace third
{


    public class Processor: functions
    {
        public List<Lawyer> lawyersList = new List<Lawyer>();
        public List<Case> casesList = new List<Case>();
        public List<Client> clientsList = new List<Client>();
        public List<Appointment> appointmentList = new List<Appointment>();
        public List<Administration> administrationList = new List<Administration>();
        public List<Receptionist> receptionistList = new List<Receptionist>();



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