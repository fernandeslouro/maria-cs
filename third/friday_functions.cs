using System.Reflection;
namespace third
{
    public class friday_funcs: Processor
    {
        public List<Client> addClient2List(List<Client> list_of_clients)
        {

            Client input_client = new Client();

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

            list_of_clients.Add(input_client);

            return list_of_clients;

        }


        public void usage()
        {
            // 3 options to use program
            Console.WriteLine("WELCOME USERS");
            Console.WriteLine("CHOOSE TYPE OF USER");
            Console.WriteLine("1. Lawyer");
            Console.WriteLine("2. Admin");
            Console.WriteLine("3. Receptionist");

            string user_type = Console.ReadLine();


            switch (user_type)
            {
                case "1":
                    Console.WriteLine("OPTIONS FOR LAWYERS");
                    Console.WriteLine("1. List all cases");
                    Console.WriteLine("2. Add a new case");
                    Console.WriteLine("3. List all appointments");
                    string lawyer_option = Console.ReadLine();

                    // lawyer stuff
                    break;
                case "2":
                    // admin stuff
                    Console.WriteLine("OPTIONS FOR ADMINS");
                    Console.WriteLine("1. List all cases");
                    Console.WriteLine("2. List all appointments");
                    string admin_option = Console.ReadLine();

                    break;
                case "3":
                    bool finished = false;
                    while (!finished)
                    {
                        // receptionist stuff
                        Console.WriteLine("OPTIONS FOR RECEPTIONISTS");
                        Console.WriteLine("1. Register a new client");
                        Console.WriteLine("2. Add a new appointment");
                        Console.WriteLine("3. List all appointments");
                        Console.WriteLine("4. List all clients");
                        Console.WriteLine("5. Exit");
                        string receptionist_option = Console.ReadLine();

                        switch (receptionist_option)
                        {
                            case "1":
                                clientsList = addClient2List(clientsList);
                                break;

                            case "5":
                                finished = true;
                                break;
                        }
                    }

                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        }

 


    }
}