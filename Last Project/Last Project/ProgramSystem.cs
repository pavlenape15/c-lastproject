using System.Xml.Serialization;

namespace Last_Project
{
    public class ProgramSystem
    {
        List<string> programs = new List<string>() { "Restaurant ", "Store " };

        public void ShowOursProgramList()
        {
            foreach (var program in programs)
            {
                Console.WriteLine(program);
            }

        }
        public void UserEnter()
        {
            Console.WriteLine("Hello!!\nLogin(1) OR Register(2)");
            int Userchoice = int.Parse(Console.ReadLine());
            switch (Userchoice)
            {
                case 1:
                    LoginUser();
                    break;
                case 2:
                    RegistrationUser();
                    break;

            }
        }
        public void RegistrationUser()
        {
            Console.WriteLine("Enter Name");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Email");
            string userEmail = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string userPassword = Console.ReadLine();
            Console.WriteLine("Choose program");
            ShowOursProgramList();
            string UserchoiceProgram = Console.ReadLine();
            SerializeUser(userName, userEmail, userPassword, UserchoiceProgram);
            WhichProgramRun(UserchoiceProgram);

        }
        public void LoginUser()
        {
            Console.WriteLine("Enter Name");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string userPassword = Console.ReadLine();
            string Programname = deserealize(userName, userPassword);
            WhichProgramRun(Programname);

        }
        public void SerializeUser(string userName, string userEmail, string userPassword, string UserchoiceProgram)
        {
            User p = new User()
            {
                UserName = userName,
                Email = userEmail,
                Password = userPassword,
                ProgramName = UserchoiceProgram
            };

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @$"\{userName}.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(User));

            serializer.Serialize(File.Create(path), p);

        }
        public string deserealize(string username, string password)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @$"\{username}.xml";
            XmlSerializer deserealize = new XmlSerializer(typeof(User));

            User p = (User)deserealize.Deserialize(File.OpenRead(path));
            if (password == p.Password)
            {
                Console.WriteLine("correct");
                return p.ProgramName;
            }
            else
            {
                Console.WriteLine("incorect Password");
            }
            return "LoginUser";

        }
        public void WhichProgramRun(string ProgramName)
        {
            if (ProgramName == "Restaurant")
            {
                Restaurant();
            }
            else if (ProgramName == "Store")
            {
                Store();
            }
            else if (ProgramName == "LoginUser")
            {
                LoginUser();
            }
        }
        public void Restaurant()
        {
            Restaurant restaurant = new Restaurant();
            restaurant.RestaurantSystem();
        }
        public void Store()
        {
            Console.WriteLine("Run Store Syster");
        }

    }
}
