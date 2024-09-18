using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Final.Project.Heavy.Armor.List
{
    [JsonPolymorphic]
    [JsonDerivedType(typeof(MBT), "MBT")]
    [JsonDerivedType(typeof(APC), "APC")]
    [JsonDerivedType(typeof(MLRS), "MLRS")]
    [JsonDerivedType(typeof(SPG), "SPG")]
    [JsonDerivedType(typeof(IFV), "IFV")]
    [JsonDerivedType(typeof(TankDestroyer), "TankDestroyer")]
    [JsonDerivedType(typeof(ARV), "ARV")]
    [JsonDerivedType(typeof(AAV), "AAV")]
    abstract class HeavyArmorUnit
    {
        public double Weight { get; set; }
        public double EnginePower { get; set; }
        public double CrewMemberCount { get; set; }
        public double PowerReserve { get; set; }
        public double MaxSpeed { get; set; }

        public HeavyArmorUnit(double weight, double enginePower, double crewMemberCount, double powerReserve, double maxSpeed)
        {
            Weight = weight;
            EnginePower = enginePower;
            CrewMemberCount = crewMemberCount;
            PowerReserve = powerReserve;
            MaxSpeed = maxSpeed;
        }

        public abstract string GetDescription();
        public virtual void PrintDetails()
        {
            Console.WriteLine($"Weight: {Weight} t");
            Console.WriteLine($"Engine Power: {EnginePower} HP");
            Console.WriteLine($"Crew Member Count: {CrewMemberCount}");
            Console.WriteLine($"Power Reserve: {PowerReserve} km");
            Console.WriteLine($"Max Speed: {MaxSpeed} km/h");
        }
    }

    class MBT : HeavyArmorUnit
    {
        public string Type { get; set; }
        public double MainGunCaliber { get; set; }

        public MBT(double weight, double enginePower, double crewMemberCount, double powerReserve, string type, double mainGunCaliber, double maxSpeed)
            : base(weight, enginePower, crewMemberCount, powerReserve, maxSpeed)
        {
            Type = type;
            MainGunCaliber = mainGunCaliber;
        }

        public override string GetDescription()
        {
            return $"Main battle tank - {Type}, Main gun caliber: {MainGunCaliber}mm";
        }
        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($"Main Gun Caliber: {MainGunCaliber} mm");
        }
    }

    class APC : HeavyArmorUnit
    {
        public string Type { get; set; }
        public int PassengerCapacity { get; set; }

        public APC(double weight, double enginePower, double crewMemberCount, double powerReserve, string type, int passengerCapacity, double maxSpeed)
            : base(weight, enginePower, crewMemberCount, powerReserve, maxSpeed)
        {
            Type = type;
            PassengerCapacity = passengerCapacity;
        }

        public override string GetDescription()
        {
            return $"Armored personal carrier - {Type}, Passenger capacity: {PassengerCapacity}";
        }
        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($"Passenger capacity: {PassengerCapacity}");
        }
    }

    class TankDestroyer : HeavyArmorUnit
    {
        public string Type { get; set; }
        public double GunCaliber { get; set; }

        public TankDestroyer(double weight, double enginePower, double crewMemberCount, double powerReserve, string type, double gunCaliber, double maxSpeed)
            : base(weight, enginePower, crewMemberCount, powerReserve, maxSpeed)
        {
            Type = type;
            GunCaliber = gunCaliber;
        }

        public override string GetDescription()
        {
            return $"Tank Destroyer - {Type}, Gun caliber: {GunCaliber}mm";
        }
        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($"Gun caliber: {GunCaliber}mm");
        }

    }

    class ARV : HeavyArmorUnit
    {
        public string Type { get; set; }
        public double TowingCapacity { get; set; }

        public ARV(double weight, double enginePower, double crewMemberCount, double powerReserve, string type, double towingCapacity, double maxSpeed)
            : base(weight, enginePower, crewMemberCount, powerReserve, maxSpeed)
        {
            Type = type;
            TowingCapacity = towingCapacity;
        }

        public override string GetDescription()
        {
            return $"Armored Recovery Vehicle - {Type}, Towing capacity: {TowingCapacity} tons";
        }
        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($"Towing capacity: {TowingCapacity} tons");
        }
    }

    class AAV : HeavyArmorUnit
    {
        public string Type { get; set; }
        public double WaterSpeed { get; set; }

        public AAV(double weight, double enginePower, double crewMemberCount, double powerReserve, string type, double waterSpeed, double maxSpeed)
            : base(weight, enginePower, crewMemberCount, powerReserve, maxSpeed)
        {
            Type = type;
            WaterSpeed = waterSpeed;
        }

        public override string GetDescription()
        {
            return $"Amphibious Assault Vehicle - {Type}, Water speed: {WaterSpeed} km/h";
        }
        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($" Water speed: {WaterSpeed} km/h");
        }
    }

    class MLRS : HeavyArmorUnit
    {
        public string Type { get; set; }
        public int RocketCount { get; set; }

        public MLRS(double weight, double enginePower, double crewMemberCount, double powerReserve, string type, int rocketCount, double maxSpeed)
            : base(weight, enginePower, crewMemberCount, powerReserve, maxSpeed)
        {
            Type = type;
            RocketCount = rocketCount;
        }

        public override string GetDescription()
        {
            return $"Multi-launch rocket system - {Type}, Rocket count: {RocketCount}";
        }
        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($"Rocket count: {RocketCount}");
        }
    }

    class SPG : HeavyArmorUnit
    {
        public string Type { get; set; }
        public double MaxFireRange { get; set; }

        public SPG(double weight, double enginePower, double crewMemberCount, double powerReserve, string type, double maxFireRange, double maxSpeed)
            : base(weight, enginePower, crewMemberCount, powerReserve, maxSpeed)
        {
            Type = type;
            MaxFireRange = maxFireRange;
        }

        public override string GetDescription()
        {
            return $"Self-Propelled Gun - {Type}, Max fire Range: {MaxFireRange}km";
        }
        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($"Max fire range: {MaxFireRange}mm");
        }
    }

    class IFV : HeavyArmorUnit
    {
        public string Type { get; set; }
        public bool HasAntiTankMissiles { get; set; }

        public IFV(double weight, double enginePower, double crewMemberCount, double powerReserve, string type, bool hasAntiTankMissiles, double maxSpeed)
            : base(weight, enginePower, crewMemberCount, powerReserve, maxSpeed)
        {
            Type = type;
            HasAntiTankMissiles = hasAntiTankMissiles;
        }

        public override string GetDescription()
        {
            return $"Infantry Fighting Vehicle - {Type}, Has anti-tank missiles: {HasAntiTankMissiles}";
        }
        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($"Has anti-tank missiles: {HasAntiTankMissiles}");
        }
    }

    internal class Program
    {
        static List<HeavyArmorUnit> heavyUnit = new List<HeavyArmorUnit>();
        static int unitCount = 0;

        static void Main(string[] args)
        {
            MainMenuShow();
        }

        static void MainMenuShow()
        {
            while (true)
            {
                Console.WriteLine("1. Create new unit");
                Console.WriteLine("2. Showcase all units");
                Console.WriteLine("3. View unit details");
                Console.WriteLine("4. Save all units description to file");
                Console.WriteLine("5. Load units description from file");
                Console.WriteLine("6. Sort units");
                Console.WriteLine("7. View/Edit/Delete specific unit");
                Console.WriteLine("8. Exit");

                Console.Write("Select option: ");
                int menuItem = Convert.ToInt32(Console.ReadLine());
                switch (menuItem)
                {
                    case 1:
                        AddUnit();
                        break;
                    case 2:
                        PrintAllUnits();
                        break;
                    case 3:
                        ViewUnitDetailsMenu();
                        break;
                    case 4:
                        SaveAllUnitsInformation();
                        break;
                    case 5:
                        LoadAllUnitsInformation();
                        break;
                    case 6:
                        SortUnitsMenu();
                        break;
                    case 7:
                        ViewEditDeleteUnitMenu();
                        break;
                    case 8:
                        Console.WriteLine("Exiting program.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // Меню сортування
        private static void SortUnitsMenu()
        {
            Console.WriteLine("Sort units by:");
            Console.WriteLine("1. Weight");
            Console.WriteLine("2. Engine Power");
            Console.WriteLine("3. Crew Member Count");
            Console.WriteLine("4. Power Reserve");
            Console.WriteLine("5. Max Speed");

            int sortChoice = GetValidInteger("Enter your choice: ");
            string sortOrder = GetValidSortOrder("Do you want ascending (asc) or descending (desc) order? (asc/desc): ");

            switch (sortChoice)
            {
                case 1:
                    SortUnitsByWeight(sortOrder);
                    break;
                case 2:
                    SortUnitsByEnginePower(sortOrder);
                    break;
                case 3:
                    SortUnitsByCrewCount(sortOrder);
                    break;
                case 4:
                    SortUnitsByPowerReserve(sortOrder);
                    break;
                case 5:
                    SortUnitsByMaxSpeed(sortOrder);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        // Методи сортування
        private static void SortUnitsByWeight(string sortOrder)
        {
            heavyUnit.Sort((x, y) => sortOrder == "asc" ? x.Weight.CompareTo(y.Weight) : y.Weight.CompareTo(x.Weight));
            Console.WriteLine("Units sorted by weight:");
            PrintAllUnits();
        }

        private static void SortUnitsByEnginePower(string sortOrder)
        {
            heavyUnit.Sort((x, y) => sortOrder == "asc" ? x.EnginePower.CompareTo(y.EnginePower) : y.EnginePower.CompareTo(x.EnginePower));
            Console.WriteLine("Units sorted by engine power:");
            PrintAllUnits();
        }

        private static void SortUnitsByCrewCount(string sortOrder)
        {
            heavyUnit.Sort((x, y) => sortOrder == "asc" ? x.CrewMemberCount.CompareTo(y.CrewMemberCount) : y.CrewMemberCount.CompareTo(x.CrewMemberCount));
            Console.WriteLine("Units sorted by crew member count:");
            PrintAllUnits();
        }

        private static void SortUnitsByPowerReserve(string sortOrder)
        {
            heavyUnit.Sort((x, y) => sortOrder == "asc" ? x.PowerReserve.CompareTo(y.PowerReserve) : y.PowerReserve.CompareTo(x.PowerReserve));
            Console.WriteLine("Units sorted by power reserve:");
            PrintAllUnits();
        }

        private static void SortUnitsByMaxSpeed(string sortOrder)
        {
            heavyUnit.Sort((x, y) => sortOrder == "asc" ? x.MaxSpeed.CompareTo(y.MaxSpeed) : y.MaxSpeed.CompareTo(x.MaxSpeed));
            Console.WriteLine("Units sorted by max speed:");
            PrintAllUnits();
        }

        // Меню перегляду, редагування та видалення одиниць техніки
        private static void ViewUnitDetailsMenu()
        {
            if (heavyUnit.Count == 0)
            {
                Console.WriteLine("No units available.");
                return;
            }

            Console.WriteLine("Enter the index of the unit to view details (starting from 0):");
            int index = GetValidInteger("Index: ");

            if (index < 0 || index >= heavyUnit.Count)
            {
                Console.WriteLine("Invalid index.");
                return;
            }

            HeavyArmorUnit selectedUnit = heavyUnit[index];

            // Відображення назви техніки
            Console.WriteLine($"\nUnit {index + 1}: {selectedUnit.GetDescription()}");

            // Відображення всіх характеристик
            selectedUnit.PrintDetails();
        }
        private static void ViewEditDeleteUnitMenu()
        {
            Console.WriteLine("Enter the index of the unit to view/edit/delete: ");
            int index = GetValidInteger("Enter index (starting from 0): ");

            if (index < 0 || index >= heavyUnit.Count)
            {
                Console.WriteLine("Invalid index.");
                return;
            }

            Console.WriteLine("Selected unit:");
            Console.WriteLine(heavyUnit[index].GetDescription());

            Console.WriteLine("Options:");
            Console.WriteLine("1. Edit unit");
            Console.WriteLine("2. Delete unit");
            Console.WriteLine("3. Return to main menu");

            int choice = GetValidInteger("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    EditUnit(index);
                    break;
                case 2:
                    DeleteUnit(index);
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        // Редагування одиниці техніки
        private static void EditUnit(int index)
        {
            Console.WriteLine("Editing unit...");

            var unit = heavyUnit[index];
            unit.Weight = GetValidDouble("Enter new weight: ");
            unit.EnginePower = GetValidDouble("Enter new engine power: ");
            unit.CrewMemberCount = GetValidDouble("Enter new crew member count: ");
            unit.PowerReserve = GetValidDouble("Enter new power reserve: ");
            unit.MaxSpeed = GetValidDouble("Enter new max speed: ");

            Console.WriteLine("Unit updated successfully.");
        }

        // Видалення одиниці техніки
        private static void DeleteUnit(int index)
        {
            heavyUnit.RemoveAt(index);
            Console.WriteLine("Unit deleted successfully.");
        }

        // Виведення всіх одиниць техніки
        private static void PrintAllUnits()
        {
            if (heavyUnit.Count == 0)
            {
                Console.WriteLine("No units to display.");
                return;
            }

            Console.WriteLine($"Total units: {heavyUnit.Count}");
            Console.WriteLine("Details of each unit:");

            foreach (var unit in heavyUnit)
            {
                Console.WriteLine(unit.GetDescription());
            }
        }

        // Завантаження та збереження техніки у файл
        private static void LoadAllUnitsInformation()
        {
            try
            {
                if (File.Exists("heavy_units.json"))
                {
                    string json = File.ReadAllText("heavy_units.json");
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        IncludeFields = true,
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                    };
                    heavyUnit = JsonSerializer.Deserialize<List<HeavyArmorUnit>>(json, options);
                    Console.WriteLine("Units loaded successfully.");
                }
                else
                {
                    Console.WriteLine("No data file found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }

        private static void SaveAllUnitsInformation()
        {
            try
            {
                JsonSerializerOptions option = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };
                string json = JsonSerializer.Serialize(heavyUnit, option);
                File.WriteAllText("heavy_units.json", json);
                Console.WriteLine("Units saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        // Додавання одиниці техніки
        private static void AddUnit()
        {
            while (true)
            {
                try
                {
                    int choice = GetValidInteger("Choose unit type: 1 for MBT, 2 for APC, 3 for MLRS, 4 for IFV, 5 for SPG, 6 for TD, 7 for AAV, 8 for ARV: ");

                    var commonParams = GetCommonParameters();
                    double weight = commonParams.weight;
                    double enginePower = commonParams.enginePower;
                    double crewCount = commonParams.crewCount;
                    double powerReserve = commonParams.powerReserve;
                    double maxSpeed = commonParams.maxSpeed;

                    Console.Write("Enter type: ");
                    string type = Console.ReadLine();

                    HeavyArmorUnit newUnit = choice switch
                    {
                        1 => new MBT(weight, enginePower, crewCount, powerReserve, type, GetValidDouble("Enter main gun caliber (mm): "), maxSpeed),
                        2 => new APC(weight, enginePower, crewCount, powerReserve, type, GetValidInteger("Enter passenger capacity: "), maxSpeed),
                        3 => new MLRS(weight, enginePower, crewCount, powerReserve, type, GetValidInteger("Enter rocket count: "), maxSpeed),
                        4 => new IFV(weight, enginePower, crewCount, powerReserve, type, GetValidBoolean("Has anti-tank missiles (true/false): "), maxSpeed),
                        5 => new SPG(weight, enginePower, crewCount, powerReserve, type, GetValidDouble("Enter max fire ramge (km): "), maxSpeed),
                        6 => new TankDestroyer(weight, enginePower, crewCount, powerReserve, type, GetValidDouble("Enter gun caliber (mm): "), maxSpeed),
                        7 => new AAV(weight, enginePower, crewCount, powerReserve, type, GetValidDouble("Enter water speed (km/h): "), maxSpeed),
                        8 => new ARV(weight, enginePower, crewCount, powerReserve, type, GetValidDouble("Enter towing capacity (tons): "), maxSpeed),
                        _ => throw new ArgumentException("Invalid choice. Please enter a number between 1 and 8.")
                    };

                    heavyUnit.Add(newUnit);
                    unitCount++;
                    Console.WriteLine($"{newUnit.GetDescription()} has been added successfully.");
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}. Please try again.");
                }
            }
        }

        // Допоміжні методи
        private static double GetValidDouble(string prompt)
        {
            double result;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out result))
                    break;
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            return result;
        }

        private static int GetValidInteger(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                    break;
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            return result;
        }

        private static bool GetValidBoolean(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().ToLower();
                if (input == "true" || input == "false")
                    return bool.Parse(input);
                Console.WriteLine("Invalid input. Please enter 'true' or 'false'.");
            }
        }

        private static string GetValidSortOrder(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().ToLower();
                if (input == "asc" || input == "desc")
                    return input;
                Console.WriteLine("Invalid input. Please enter 'asc' for ascending or 'desc' for descending.");
            }
        }

        private static (double weight, double enginePower, double crewCount, double powerReserve, double maxSpeed) GetCommonParameters()//введення параметрів техніки
        {
            double weight = GetValidDouble("Enter weight: ");
            double enginePower = GetValidDouble("Enter engine power: ");
            double crewCount = GetValidDouble("Enter crew member count: ");
            double powerReserve = GetValidDouble("Enter power reserve: ");
            double maxSpeed = GetValidDouble("Enter max speed (km/h): ");
            return (weight, enginePower, crewCount, powerReserve, maxSpeed);
        }
    }
}
