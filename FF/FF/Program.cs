namespace FF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\acer\Desktop\FF\FF\Test\";
            
            
            int choise;
            do
            {
                Console.WriteLine("1-Create");
                Console.WriteLine("2-DeleteByName");
                Console.WriteLine("3-GetAllFiles");
                Console.WriteLine("4-DeleteAllFiles");
                Console.WriteLine("5-Update File Name");
                Console.WriteLine("6-Write text to file");
                Console.WriteLine("7-Read file info");
                Console.WriteLine("8-Exit");
                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    
                    case 1:
                        {
                            Console.WriteLine("Faylin adini daxil edin");
                            string fileName = Console.ReadLine();
                            Console.WriteLine("Faylin extension dail edin");
                            string extension=Console.ReadLine();
                            File.Create(Path.Combine(path, fileName + $".{extension.ToLower()}"));
                            Console.WriteLine("File uqurla yaradildi");
                            Console.WriteLine(new string('-',30));
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Silinecek faylin adini daxil edin:");
                            string fileName = Console.ReadLine();
                            Console.WriteLine("Faylin extension dail edin");
                            string extension = Console.ReadLine();
                            if (File.Exists(Path.Combine(path, fileName + $".{extension.ToLower()}")))
                            {
                              File.Delete(Path.Combine(path, fileName + $".{extension.ToLower()}"));
                              Console.WriteLine("File uqurla silindi");

                            }
                            else
                            {
                                Console.WriteLine("Bu adda fayl yoxdur");
                            }
                            Console.WriteLine(new string('-', 30));
                            break;
                        }
                    case 3:
                        {
                            string[] allFiles = Directory.GetFiles(path, "*.*");
                            foreach (var file in allFiles)
                            {
                                if (File.Exists(file))
                                {
                                    Console.WriteLine("Qovluqun icerisindeki fayllarin adlari: ");
                                    Console.WriteLine(file.Replace(path, ""));
                                }
                                else
                                {
                                    Console.WriteLine("Bu qovluqda fayl yoxdur");
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            string[] allFiles = Directory.GetFiles(path, "*.*");
                            foreach (var file in allFiles)
                            {
                                File.Delete(file);
                            }
                            Console.WriteLine("Butun fayllar uqurla silindi");
                            Console.WriteLine(new string('-', 30));
                            
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine(" Faylin adini daxil edin:");
                            string fileName = Console.ReadLine();
                            Console.WriteLine("Faylin extension dail edin");
                            string extension = Console.ReadLine();
                            if (File.Exists(Path.Combine(path, fileName + $".{extension.ToLower()}")))
                            {
                                Console.WriteLine(" Deyisdirelecek faylin adini daxil edin:");
                                string newFileName = Console.ReadLine();
                                string oldFileName = Path.Combine(path, fileName + $".{extension.ToLower()}");
                                string renameFileName = Path.Combine(path, newFileName + $".{extension.ToLower()}");
                                File.Move(oldFileName,renameFileName);
                                Console.WriteLine("Faylin adi uqurla deyisdirildi");
                            }
                            else
                            {
                                Console.WriteLine("Bu adda fayl yoxdur");
                            }
                            Console.WriteLine(new string('-', 30));

                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Faylin adini daxil edin");
                            string fileName = Console.ReadLine();
                            Console.WriteLine("Faylin extension dail edin");
                            string extension = Console.ReadLine();
                            Console.WriteLine("Yazi daxil edin");
                            string text =Console.ReadLine();
                            File.WriteAllText(Path.Combine(path, fileName + $".{extension.ToLower()}"), text);
                            Console.WriteLine("Yazi uqurla yazildi");
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Faylin adini daxil edin");
                            string fileName = Console.ReadLine();
                            Console.WriteLine("Faylin extension dail edin");
                            string extension = Console.ReadLine();
                            foreach (var line in File
                                .ReadAllLines(Path.Combine(path, fileName + $".{extension.ToLower()}"))
                                .Select((value)=> new {value}))
                            {
                                Console.WriteLine($"{line.value}");
                            }
                            Console.WriteLine(new string('-', 30));

                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Good Bye!");
                            break;
                        }
                    default:
                        Console.WriteLine("Bele bir secim yoxdur");
                        break;
                }
            } while (choise != 8);
        }
    }
}