using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Last_Project
{
    public class Restaurant
    {
        public int documentid { get; set; }

        public List<Table> tables = new List<Table>()
        {
            new Table(){placed="1",TableId =1,freeTable=true},
            new Table(){placed="2", TableId=2,freeTable=true},
            new Table(){placed="3", TableId=3,freeTable=false},


        };
        public List<Food> foods = new List<Food>()
        {
            new Food(){Name="Pizza",Price=13.50},
            new Food() {Name="Hamburger",Price=9.30 },
            new Food(){Name="Hotdog",Price=6},
            new Food(){Name="caesar salad",Price=12},
            new Food(){Name="Sushi",Price=20},
            new Food(){Name="CheeseCake",Price=10}
        };

        string User;
        public void TableReservation()
        {
            Console.WriteLine("which table would you like to book?");
            Console.WriteLine("1.in the center");
            Console.WriteLine("2.next to window");
            Console.WriteLine("3.in the corner");
            User = Console.ReadLine();

            if (User == tables[0].placed)
            {
                documentid = tables[0].TableId;

            }
            else if (User == tables[1].placed)
            {
                documentid = tables[1].TableId;
            }
            else if (User == tables[2].placed)
            {
                documentid = tables[2].TableId;
            }


            while (true)
            {
                switch (User)
                {
                    case "1":
                        if (tables[0].freeTable != true)
                        {
                            Console.WriteLine("sorry table is already booked");

                        }
                        else
                        {
                            Console.WriteLine("your table is booked succesfully");
                        }
                        break;
                    case "2":
                        if (tables[1].freeTable != true)
                        {
                            Console.WriteLine("sorry table is already booked");

                        }
                        else
                        {
                            Console.WriteLine("your table is booked succesfully");
                        }
                        break;
                    case "3":
                        if (tables[2].freeTable != true)
                        {
                            Console.WriteLine("sorry table is already booked");
                            Console.WriteLine("pick other one");
                            User = Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("your table is booked succesfully");
                        }
                        break;

                }
                break;

            }

        }

        public void Order(Table orderedfood)
        {
            while (true)
            {
                Console.WriteLine("which food would you like to have?");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1.Pizza Price: 13.50gel");
                Console.WriteLine("2.Hamburger  price:9.30gel");
                Console.WriteLine("3.hotdog price:6gel ");
                Console.WriteLine("4.caesar salad  price : 12gel");
                Console.WriteLine("5.Sushi price:20gel");
                Console.WriteLine("6.Chessecake price:10gel");
                Console.WriteLine("____________________________");
                User = Console.ReadLine();

                switch (User)
                {
                    case "1":
                        orderedfood.orderedFood.Add(foods[0]);
                        Console.WriteLine("pizza was added to your order succesfully");

                        break;
                    case "2":
                        orderedfood.orderedFood.Add(foods[1]);
                        Console.WriteLine("Hamburger was added to your order succesfully");
                        break;
                    case "3":
                        orderedfood.orderedFood.Add(foods[2]);
                        Console.WriteLine("Hotdog was added to your order succesfully");
                        break;
                    case "4":
                        orderedfood.orderedFood.Add(foods[3]);
                        Console.WriteLine("Caesar salad was added to your order succesfully");
                        break;
                    case "5":
                        orderedfood.orderedFood.Add(foods[4]);
                        Console.WriteLine("Sushi was added to your order succesfully");
                        break;
                    case "6":
                        orderedfood.orderedFood.Add(foods[6]);
                        Console.WriteLine("Cheesecake was added to your order succesfully");
                        break;


                }
                if (User == "0")
                {
                    break;
                }

            }



        }
        public void PrintCheck(Table orderedFood)
        {


            Console.WriteLine("do you want to see the check?");
            if (User == "yes".ToLower())
            {

            }
            else
            {
                Console.WriteLine("sorry what?");
            }

        }
        public static void WriteFile(string path, string content)
        {
            FileInfo fi = new FileInfo(path);
            using (StreamWriter sw = fi.AppendText())
            {
                sw.WriteLine(content);
            }
        }
        public void RestaurantSystem()
        {
            Restaurant restaurant = new Restaurant();
            Table table = new Table();
            restaurant.TableReservation();
            restaurant.Order(table);
            double totalPrice = 0;
            foreach (var food in table.orderedFood)
            {
                Console.WriteLine(food.Name);
                totalPrice += food.Price;

            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $@"{table.orderedFood}";
            DirectoryInfo dir = new DirectoryInfo(path);
            dir.Create();
            DateTime FileName = DateTime.Now;
            string path2 = dir.FullName + @$"\{FileName.Year}_{FileName.Day}_{FileName.Hour}_{FileName.Minute}_{FileName.Second}.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Food>));

            serializer.Serialize(File.Create(path2), table.orderedFood);
            Console.WriteLine($" Total Price : {totalPrice} gel");



            string path3 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Menu";

            DirectoryInfo dir2 = new DirectoryInfo(path3);
            dir2.Create();
            DirectoryInfo Menu = dir.CreateSubdirectory("Menu");



            foreach (Food food in restaurant.foods)
            {
                Restaurant.WriteFile(Menu.FullName, $@"{food.Name}---{food.Price}");
                
            }
        }
    }
}
