using System;
namespace third
{
    public class Processor : functions
    {
        //public List<Lawyer> lawyersList = new List<Lawyer>();
        public List<Client> clientsList = new List<Client>();
        public List<Case> casesList = new List<Case>();
        public List<Appointment> appointmentList = new List<Appointment>();
        public List<Administration> administrationList = new List<Administration>();
        public List<Receptionist> receptionistList = new List<Receptionist>();


        public void login()
        {

            List<Lawyer> lawyersList = ImportFile("lawyers_database.csv");
            listLawyers(lawyersList);
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
                                clientsList = AddNewClient(clientsList);
                                break;
                            case 2:
                                if (!clientsList.Any())
                                {
                                    Console.WriteLine("It is not possible to book an appointment when there are no registered clients.\nRegister a Client first.");
                                }
                                else
                                {
                                    appointmentList = AddNewAppointment(appointmentList, lawyersList, clientsList);
                                }
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
                                if (!clientsList.Any())
                                {
                                    Console.WriteLine("It is not possible to book an appointment when there are no registered clients.\nRegister a Client first.");
                                }
                                else
                                {
                                    casesList = AddNewCase(casesList, lawyersList, clientsList);
                                }
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
            //myProc.lawyersList = myProc.ImportFile("lawyers_database.csv");

            //myProc.usage();
            myProc.login();

        }
    }

}