using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Sharp_Apps_Nikita.Transportation.Final_Project.CargoSpace;
using C_Sharp_Apps_Nikita.Transportation.Final_Project.CargoVehicleType;
using C_Sharp_Apps_Nikita.Transportation.Final_Project.Items;
using static System.Net.Mime.MediaTypeNames;

namespace C_Sharp_Apps_Nikita.Transportation.Final_Project
{
    public class ProjectTest
    {

        public static void RunAllTests()
        {
            int passedTests = 0;
            int failedTests = 0;

            PrintInYellow("===================-Running All Tests-====================");

            if (Test1()) passedTests++; else failedTests++;
            if (Test2()) passedTests++; else failedTests++;
            if (Test3()) passedTests++; else failedTests++;
            if (Test4()) passedTests++; else failedTests++;
            if (Test5()) passedTests++; else failedTests++;
            if (Test6()) passedTests++; else failedTests++;
            if (Test7()) passedTests++; else failedTests++;
            if (Test8()) passedTests++; else failedTests++;
            if (Test9()) passedTests++; else failedTests++;
            if (Test10()) passedTests++; else failedTests++;
            if (DeliveryTest1()) passedTests++; else failedTests++;
            if (DeliveryTest2()) passedTests++; else failedTests++;
            if (DeliveryTest3()) passedTests++; else failedTests++;
            if (DeliveryTest4()) passedTests++; else failedTests++;
            if (DeliveryTest5()) passedTests++; else failedTests++;

            PrintInYellow($"=======================-Summary-==========================");
            PrintInGreen($"Passed: {passedTests}");
            PrintInRed($"Failed: {failedTests}");
        }

        static bool Test1()
        {
            PrintInYellow("-------------------------Test - 1-------------------------");
            Driver nick = new Driver("Nick", "Hayef", "1", CargoType.Airplane);
            Driver stephan = new Driver("Stephan", "Kosher", "2", CargoType.Airplane);
            Driver bobi = new Driver("Bobi", "Bonten", "1", CargoType.Train);
            Driver[] AllDrivers = { nick, bobi, stephan };

            int countPilot = 0;
            int countShip = 0;
            int countTrain = 0;
            for (int i = 0; i < AllDrivers.Length; i++)
            {


                if (AllDrivers[i].DriverType == CargoType.Null)
                {
                    PrintInRed($"Test 1: Faild -  Null Type Driver!");
                    Console.WriteLine("----------------------------------------------------------");
                    return false;
                }
                else
                {
                    switch (AllDrivers[i].DriverType)
                    {
                        case CargoType.Airplane: countPilot++; break;
                        case CargoType.Ship: countShip++; break;
                        case CargoType.Train: countTrain++; break;
                        default: Console.WriteLine("Unexpected Erorr!"); break;
                    }
                    Console.Write($"Found {AllDrivers[i].DriverType} Driver: ");
                    Console.WriteLine(AllDrivers[i].Name);
                }
            }
            PrintInGreen($"Test 1 - Passed -> Found {countPilot} Pilots | {countShip} Sailers | {countTrain} Train Operator");
            return true;
        }
        static bool Test2()
        {
            //Driver
            Driver stephan = new Driver("Stephan", "Kosher", "2", CargoType.Airplane);
            //Ports
            Port port1 = new Port(CargoType.Airplane, "Israel", "TLV", "Ben Gurion", 12);
            Port port2 = new Port(CargoType.Airplane, "Israel", "Eilat", "Ramon", 22);
            //Items
            IPortable item1 = new GeneralItem(1, 1, 1, 20, false, port1);
            IPortable item2 = new GeneralItem(5, 5, 5, 20, false, port1);
            IPortable item3 = new GeneralItem(10, 10, 10, 20, false, port1);
            List<IPortable> items = new List<IPortable> { item1, item2, item3 };
            ////Plane
            AirePlane LY466 = new AirePlane(stephan, 1000, 100000, port1, port2, 1);
            PrintInYellow("-------------------------Test - 2-------------------------");
            LY466.PlaneCargo.Load(items);
            LY466.DisplayCargo();
            //LY466.SetOverWeight(true);//change to check if iy works
            if (LY466.PlaneCargo.GetCurrentWeight() < LY466.PlaneCargo.GetMaxWeight() && !LY466.GetOverWeight())
            {
                PrintInGreen("Test 2 - Passed");
                return true;
            }
            else
            {
                PrintInRed($"Test 2 - Failed -> Your OverWeight Prosperity is: {LY466.GetOverWeight()} | Expected: {LY466.PlaneCargo.GetCurrentWeight() > LY466.PlaneCargo.GetMaxWeight()}");
                return false;
            }
        }
        static bool Test3()
        {
            PrintInYellow("-------------------------Test - 3-------------------------");
            //Ports
            Port port1 = new Port(CargoType.Airplane, "Israel", "TLV", "Ben Gurion", 12);
            Port port2 = new Port(CargoType.Airplane, "Israel", "Eilat", "Ramon", 22);
            CargoContainer containerTest = new CargoContainer(1000, 5000);

            IPortable testItem1 = new GeneralItem(1, 1, 1, 50, false, port1);
            IPortable testItem2 = new GeneralItem(2, 2, 2, 100, true, port1);

            Console.WriteLine("Adding items to the container:");
            containerTest.Load(testItem1);
            containerTest.Load(testItem2);
            containerTest.GetContainerList(); // Display items in the container

            Console.WriteLine("\nRemoving an item from the container:");
            containerTest.Unload(testItem1);
            containerTest.GetContainerList(); // Display items in the container after removal

            if (containerTest.GetCurrentWeight() == testItem2.GetWeight() && containerTest.GetCurrentVolume() == testItem2.GetVolume())
            {
                PrintInGreen("Test 3 - Passed: Correctly added and removed items from the container.");
                return true;
            }
            else
            {
                PrintInRed("Test 3 - Failed: Incorrect handling of items in the container.");
                return false;
            }
        }
        static bool Test4()
        {
            PrintInYellow("-------------------------Test - 4-------------------------");
            // Setup
            Port haifaPort = new Port(CargoType.Ship, "Israel", "Haifa", "Haifa Port", 2);
            Driver shipDriver = new Driver("Moshe", "Dayan", "002", CargoType.Ship);
            Ship testShip = new Ship(shipDriver, 5000, 20000, haifaPort, null, 0);

            // Containers
            CargoContainer container1 = new CargoContainer(1000, 5000);
            CargoContainer container2 = new CargoContainer(1500, 7000);

            // Adding containers to the ship
            Console.WriteLine("Adding containers to the ship:");
            testShip.AddContainer(container1);
            testShip.AddContainer(container2);
            testShip.DisplayContainers(); // Display the containers on the ship

            // Verify if the ship's weight and volume are updated correctly
            double expectedWeight = container1.GetCurrentWeight() + container2.GetCurrentWeight();
            double expectedVolume = container1.GetCurrentVolume() + container2.GetCurrentVolume();

            if (testShip.GetCurrentWeight() == expectedWeight && testShip.GetCurrentVolume() == expectedVolume)
            {
                PrintInGreen("Test 4 - Passed: Ship correctly added containers and updated weight and volume.");
                return true;
            }
            else
            {
                PrintInRed("Test 4 - Failed: Ship did not handle containers correctly.");
                return false;
            }
        }
        static bool Test5()
        {
            PrintInYellow("-------------------------Test - 5-------------------------");
            // Setup
            Port haifaPort = new Port(CargoType.Ship, "Israel", "Haifa", "Haifa Port", 2);
            Driver shipDriver = new Driver("Moshe", "Dayan", "002", CargoType.Ship);
            Ship testShip = new Ship(shipDriver, 2000, 10000, haifaPort, null, 0); // Smaller capacity for testing

            // Items to be loaded into containers
            IPortable item1 = new GeneralItem(10, 10, 10, 4700, false, haifaPort);
            IPortable item2 = new GeneralItem(20, 20, 20, 5700, true, haifaPort);

            // Containers
            CargoContainer container1 = new CargoContainer(1000, 5000);
            CargoContainer container2 = new CargoContainer(1200, 6000); // This should push the ship over its limit

            // Load items into the containers
            container1.Load(item1);
            container2.Load(item2);

            // Adding containers to the ship
            Console.WriteLine("Adding containers to the ship:");
            testShip.AddContainer(container1);
            testShip.AddContainer(container2);
            testShip.DisplayContainers(); // Display the containers on the ship

            // Check if the ship is overloaded
            if (testShip.GetOverWeight())
            {
                PrintInGreen("Test 5 - Passed: Ship correctly identified overload condition.");
                return true;
            }
            else
            {
                PrintInRed("Test 5 - Failed: Ship did not identify overload condition.");
                return false;
            }
        }
        static bool Test6()
        {
            PrintInYellow("-------------------------Test - 6-------------------------");
            // Setup
            Port ashdodPort = new Port(CargoType.Train, "Israel", "Ashdod", "Ashdod Port", 3);
            Driver trainDriver = new Driver("Yitzhak", "Rabin", "003", CargoType.Train);
            Train testTrain = new Train(trainDriver, 3000, 10000, ashdodPort, null, 0);

            // Crones
            Crone crone1 = new Crone(1000, 5000);
            Crone crone2 = new Crone(1500, 7000);

            // Adding crones to the train
            Console.WriteLine("Adding crones to the train:");
            testTrain.AddCrone(crone1);
            testTrain.AddCrone(crone2);
            testTrain.DisplayCrones(); // Display the crones on the train

            // Verify if the train's weight and volume are updated correctly
            double expectedWeight = crone1.GetCurrentWeight() + crone2.GetCurrentWeight();
            double expectedVolume = crone1.GetCurrentVolume() + crone2.GetCurrentVolume();

            if (testTrain.GetCurrentWeight() == expectedWeight && testTrain.GetCurrentVolume() == expectedVolume)
            {
                PrintInGreen("Test 6 - Passed: Train correctly added crones and updated weight and volume.");
                return true;
            }
            else
            {
                PrintInRed("Test 6 - Failed: Train did not handle crones correctly.");
                return false;
            }
        }
        static bool Test7()
        {
            PrintInYellow("-------------------------Test - 7-------------------------");
            // Setup
            Port ashdodPort = new Port(CargoType.Train, "Israel", "Ashdod", "Ashdod Port", 3);
            Driver trainDriver = new Driver("Yitzhak", "Rabin", "003", CargoType.Train);
            Train testTrain = new Train(trainDriver, 10000, 20000, ashdodPort, null, 0); // Example with 10,000 max weight

            // Heavy Items to be loaded into crones
            IPortable item1 = new GeneralItem(10, 10, 10, 4700, false, ashdodPort); // Heavy item
            IPortable item2 = new GeneralItem(20, 20, 20, 5700, true, ashdodPort);  // Even heavier item

            // Crones
            Crone crone1 = new Crone(5000, 5000); // Capacity up to 5000 units of weight
            Crone crone2 = new Crone(7000, 6000); // Capacity up to 7000 units of weight

            // Load items into the crones
            crone1.Load(item1);
            crone2.Load(item2);

            // Adding crones to the train
            Console.WriteLine("Adding crones to the train:");
            testTrain.AddCrone(crone1);
            testTrain.AddCrone(crone2);
            testTrain.DisplayCrones(); // Display the crones on the train

            // Check if the train is overloaded
            if (testTrain.GetOverWeight())
            {
                PrintInGreen("Test 7 - Passed: Train correctly identified overload condition.");
                return true;
            }
            else
            {
                PrintInRed("Test 7 - Failed: Train did not identify overload condition.");
                return false;
            }
        }
        static bool Test8()
        {
            PrintInYellow("-------------------------Test - 8-------------------------");
            // Setup
            Port telAvivPort = new Port(CargoType.Airplane, "Israel", "Tel Aviv", "Ben Gurion", 1);
            Port eilatPort = new Port(CargoType.Airplane, "Israel", "Eilat", "Ramon", 2);
            Driver planeDriver = new Driver("David", "BenGurion", "001", CargoType.Airplane);
            AirePlane testPlane = new AirePlane(planeDriver, 10000, 50000, telAvivPort, eilatPort, 300); 

            // Items
            IPortable item1 = new GeneralItem(10, 10, 10, 100, false, telAvivPort);  
            IPortable item2 = new GeneralItem(20, 20, 20, 200, true, telAvivPort);   

            // Calculate price for a single item and for a list of items
            double priceSingle = testPlane.CalculatePrice(item1, 300);
            double priceList = testPlane.CalculatePrice(new List<IPortable> { item1, item2 }, 300);

            // Expected values
            int unitsItem1 = (int)(item1.GetVolume() / 100) + (int)item1.GetWeight();  
            int unitsItem2 = ((int)(item2.GetVolume() / 100) + (int)item2.GetWeight()) * 2;  

            double expectedPriceSingle = unitsItem1 * 300 * 50;  
            double expectedPriceList = (unitsItem1 + unitsItem2) * 300 * 50;

            
            if (priceSingle == expectedPriceSingle)
            {
                PrintInGreen("Test 8 - Passed: Plane price for a single item is correct.");
            }
            else
            {
                PrintInRed($"Test 8 - Failed: Plane price for a single item is incorrect. Expected: {expectedPriceSingle}, Got: {priceSingle}");
            }

            if (priceList == expectedPriceList)
            {
                PrintInGreen("Test 8 - Passed: Plane price for a list of items is correct.");
                return true;
            }
            else
            {
                PrintInRed($"Test 8 - Failed: Plane price for a list of items is incorrect. Expected: {expectedPriceList}, Got: {priceList}");
                return false;
            }
        }
        static bool Test9()
        {
            PrintInYellow("-------------------------Test - 9-------------------------");
            // Setup
            Port haifaPort = new Port(CargoType.Ship, "Israel", "Haifa", "Haifa Port", 2);
            Port ashdodPort = new Port(CargoType.Ship, "Israel", "Ashdod", "Ashdod Port", 3);
            Driver shipDriver = new Driver("Moshe", "Dayan", "002", CargoType.Ship);
            Ship testShip = new Ship(shipDriver, 20000, 50000, haifaPort, ashdodPort, 1000);

            // Items
            IPortable item1 = new GeneralItem(10, 10, 10, 500, false, haifaPort);
            IPortable item2 = new GeneralItem(20, 20, 20, 800, true, haifaPort);

            // Calculate price for a single item and for a list of items
            double priceSingle = testShip.CalculatePrice(item1, 1000);
            double priceList = testShip.CalculatePrice(new List<IPortable> { item1, item2 }, 1000);

            // Expected values
            int unitsItem1 = (int)(item1.GetVolume() / 100) + (int)item1.GetWeight();
            int unitsItem2 = ((int)(item2.GetVolume() / 100) + (int)item2.GetWeight()) * 2;

            double expectedPriceSingle = unitsItem1 * 1000 * 20;
            double expectedPriceList = (unitsItem1 + unitsItem2) * 1000 * 20;

            // Verify if the prices are calculated correctly
            if (priceSingle == expectedPriceSingle)
            {
                PrintInGreen("Test 9 - Passed: Ship price for a single item is correct.");
            }
            else
            {
                PrintInRed($"Test 9 - Failed: Ship price for a single item is incorrect. Expected: {expectedPriceSingle}, Got: {priceSingle}");
            }

            if (priceList == expectedPriceList)
            {
                PrintInGreen("Test 9 - Passed: Ship price for a list of items is correct.");
                return true;
            }
            else
            {
                PrintInRed($"Test 9 - Failed: Ship price for a list of items is incorrect. Expected: {expectedPriceList}, Got: {priceList}");
                return false;
            }
        }
        static bool Test10()
        {
            PrintInYellow("-------------------------Test - 10-------------------------");
            // Setup
            Port ashdodPort = new Port(CargoType.Train, "Israel", "Ashdod", "Ashdod Port", 3);
            Port jerusalemPort = new Port(CargoType.Train, "Israel", "Jerusalem", "Jerusalem Central", 4);
            Driver trainDriver = new Driver("Yitzhak", "Rabin", "003", CargoType.Train);
            Train testTrain = new Train(trainDriver, 15000, 30000, ashdodPort, jerusalemPort, 200); // Example: 200 km distance

            // Items to be loaded into crones
            IPortable item1 = new GeneralItem(10, 10, 10, 300, false, ashdodPort);  // Non-fragile item
            IPortable item2 = new GeneralItem(10, 10, 10, 500, true, ashdodPort);   // Fragile item

            // Crones
            Crone crone1 = new Crone(5000, 5000); // Capacity up to 5000 units of weight
            Crone crone2 = new Crone(7000, 6000); // Capacity up to 7000 units of weight

            // Load items into the crones
            crone1.Load(item1);
            crone2.Load(item2);

            // Adding crones to the train
            Console.WriteLine("Adding crones to the train:");
            testTrain.AddCrone(crone1);
            testTrain.AddCrone(crone2);
            testTrain.DisplayCrones(); // Display the crones on the train

            // Calculate price for the items loaded into the crones
            double priceList = testTrain.CalculatePrice(new List<IPortable> { item1, item2 }, 200);

            // Expected values
            int unitsItem1 = (int)(item1.GetVolume() / 100) + (int)item1.GetWeight();  // Non-fragile
            int unitsItem2 = ((int)(item2.GetVolume() / 100) + (int)item2.GetWeight()) * 2;  // Fragile item (x2)

            double expectedPriceList = (unitsItem1 + unitsItem2) * 200 * 5;

            // Verify if the prices are calculated correctly
            if (priceList == expectedPriceList)
            {
                PrintInGreen("Test 10 - Passed: Train price for the items in crones is correct.");
                return true;
            }
            else
            {
                PrintInRed($"Test 10 - Failed: Train price for the items in crones is incorrect. Expected: {expectedPriceList}, Got: {priceList}");
                return false;
            }
        }


        static bool DeliveryTest1()
        {
            PrintInYellow("-------------------------Delivery Test - 1(plane)-------------------------");
            //Ports
            Port port1 = new Port(CargoType.Airplane, "Israel", "TLV", "Ben Gurion", 12);
            Port port2 = new Port(CargoType.Airplane, "Israel", "Eilat", "Ramon", 22);

            //Items
            IPortable item1 = new GeneralItem(1, 1, 1, 20, false, port2);
            IPortable item2 = new GeneralItem(5, 5, 5, 20, false, port2);
            IPortable item3 = new GeneralItem(10, 10, 10, 20, false, port2);
            List<IPortable> items = new List<IPortable> { item1, item2, item3 };
            //Plane
            AirePlane LY_Test = new AirePlane(null, 1000, 100000, port1, port2, 1);
            //Driver
            Driver stephan = new Driver("Stephan", "Kosher", "2", CargoType.Airplane);

            LY_Test.SetDriver(stephan);       //stephan is the pilot now
            LY_Test.GoToNextDestination();    //fly to next destination
            LY_Test.SetNextDestination(port1);//new destination
            LY_Test.PlaneCargo.Load(items);   //loads all the items for itmes list
            LY_Test.DisplayCargo();           //this is shows that all the items are indeed on the plane
            LY_Test.GoToNextDestination();    //Flying to next destination
            LY_Test.PlaneCargo.UpdateItemLocations(LY_Test.Current_Port);//update the item location to next port
            LY_Test.DisplayCargo();           //Display That the items are updated to the new location
            LY_Test.PlaneCargo.Unload(items); //unload the items from the plane
            LY_Test.DisplayCargo();           //display that there no items on plane
            PrintInGreen("Flight Test Finished");

            return true;
        }
        static bool DeliveryTest2()
        {
            PrintInYellow("-------------------------Delivery Test - 2(plane)-------------------------");

            // Ports
            Port haifaPort = new Port(CargoType.Airplane, "Israel", "Haifa", "Haifa Airport", 15);
            Port eilatPort = new Port(CargoType.Airplane, "Israel", "Eilat", "Ramon", 30);

            // Items
            IPortable item1 = new GeneralItem(15, 15, 15, 350, false, eilatPort);  // Non-fragile item
            IPortable item2 = new GeneralItem(25, 25, 25, 550, true, eilatPort);   // Fragile item
            IPortable item3 = new GeneralItem(30, 30, 30, 250, true, eilatPort);   // Fragile item
            List<IPortable> itemsToLoad = new List<IPortable> { item1, item2, item3 };

            // Plane
            AirePlane flightTestPlane = new AirePlane(null, 1500, 20000, haifaPort, eilatPort, 1);

            // Driver
            Driver amir = new Driver("Amir", "Levi", "004", CargoType.Airplane);

            flightTestPlane.SetDriver(amir);       // Assign Amir as the pilot
            flightTestPlane.GoToNextDestination(); // Fly to the next destination (Eilat)
            flightTestPlane.SetNextDestination(haifaPort); // Set next destination back to Haifa
            flightTestPlane.PlaneCargo.Load(itemsToLoad);   // Load the items at Eilat
            flightTestPlane.DisplayCargo();         // Show that the items are on the plane
            flightTestPlane.GoToNextDestination();  // Fly back to Haifa
            flightTestPlane.PlaneCargo.UpdateItemLocations(flightTestPlane.Current_Port); // Update item locations
            flightTestPlane.DisplayCargo();         // Display that the items are now updated to Haifa
            flightTestPlane.PlaneCargo.Unload(itemsToLoad);  // Unload the items at Haifa
            flightTestPlane.DisplayCargo();         // Display that the plane is empty
            PrintInGreen("Delivery Test 2 Finished");

            return true;
        }
        static bool DeliveryTest3()
        {
            PrintInYellow("-------------------------Delivery Test - 3 (Ship)-------------------------");

            // Ports
            Port haifaPort = new Port(CargoType.Ship, "Israel", "Haifa", "Haifa Port", 15);
            Port ashdodPort = new Port(CargoType.Ship, "Israel", "Ashdod", "Ashdod Port", 25);

            // Items
            IPortable item1 = new GeneralItem(10, 1, 1, 1000, false, ashdodPort);  // Non-fragile item
            IPortable item2 = new GeneralItem(70, 1, 1, 1000, true, ashdodPort);   // Fragile item
            IPortable item3 = new GeneralItem(80, 1, 1, 1000, true, ashdodPort);   // Fragile item
            List<IPortable> itemsToLoad = new List<IPortable> { item1, item2, item3 };

            // Ship
            Ship deliveryShip = new Ship(null, 20_000_00, 100000, haifaPort, ashdodPort, 1);

            // Driver
            Driver moshe = new Driver("Moshe", "Cohen", "005", CargoType.Ship);

            deliveryShip.SetDriver(moshe);             // Assign Moshe as the ship's captain
            deliveryShip.GoToNextDestination();        // Sail to the next destination (Ashdod)
            deliveryShip.SetNextDestination(haifaPort); // Set next destination back to Haifa

            // Load items into a cargo container and add it to the ship
            CargoContainer shipContainer = new CargoContainer(20000, 100000);
            shipContainer.Load(itemsToLoad);
            deliveryShip.AddContainer(shipContainer);

            deliveryShip.DisplayContainers();           // Show that the container with items is on the ship

            deliveryShip.GoToNextDestination();         // Sail back to Haifa
            shipContainer.UpdateItemLocations(deliveryShip.Current_Port); // Update item locations

            deliveryShip.DisplayContainers();           // Display that the items are now updated to Haifa

            // Unload the container from the ship and unload the items from the container
            shipContainer.Unload(itemsToLoad);
            deliveryShip.RemoveContainer(shipContainer);

            deliveryShip.DisplayContainers();           // Display that the ship is empty
            PrintInGreen("Delivery Test 3 (Ship) Finished");

            return true;
        }
        static bool DeliveryTest4()
        {
            PrintInYellow("-------------------------Delivery Test - 4 (Train)-------------------------");

            // Ports
            Port haifaPort = new Port(CargoType.Train, "Israel", "Haifa", "Haifa Train Station", 10);
            Port telAvivPort = new Port(CargoType.Train, "Israel", "Tel Aviv", "Tel Aviv Central", 20);

            // Items
            IPortable item1 = new GeneralItem(10, 1, 1, 100, false, telAvivPort);  // Non-fragile item
            IPortable item2 = new GeneralItem(20, 1, 1, 50, true, telAvivPort);   // Fragile item
            IPortable item3 = new GeneralItem(15, 1, 1, 300, true, telAvivPort);   // Fragile item
            List<IPortable> itemsToLoad = new List<IPortable> { item1, item2, item3 };

            // Train
            Train deliveryTrain = new Train(null, 10000, 50000, haifaPort, telAvivPort, 1);

            // Driver
            Driver yitzhak = new Driver("Yitzhak", "Navon", "006", CargoType.Train);

            deliveryTrain.SetDriver(yitzhak);           // Assign Yitzhak as the train's driver
            deliveryTrain.GoToNextDestination();        // Travel to the next destination (Tel Aviv)
            deliveryTrain.SetNextDestination(haifaPort); // Set next destination back to Haifa

            // Load items into a crone and add it to the train
            Crone trainCrone = new Crone(3000, 5000); // Ensure enough capacity
            trainCrone.Load(itemsToLoad);
            deliveryTrain.AddCrone(trainCrone);

            deliveryTrain.DisplayCrones();             // Show that the crone with items is on the train

            deliveryTrain.GoToNextDestination();       // Travel back to Haifa
            trainCrone.UpdateItemLocations(deliveryTrain.Current_Port); // Update item locations

            deliveryTrain.DisplayCrones();             // Display that the items are now updated to Haifa

            // Unload the crone from the train and unload the items from the crone
            trainCrone.Unload(itemsToLoad);
            deliveryTrain.RemoveCrone(trainCrone);

            deliveryTrain.DisplayCrones();             // Display that the train is empty
            PrintInGreen("Delivery Test 4 (Train) Finished");

            return true;
        }
        static bool DeliveryTest5()
        {
            PrintInYellow("-------------------------Delivery Test - 5 (Complex Multi-Transport)-------------------------");

            double totalPrice = 0;
            int totalKm = 0;
            List<string> driversList = new List<string>();

            // Ports
            Port usPort = new Port(CargoType.Ship, "USA", "New York", "New York Harbor", 10000);
            Port ashdodPort = new Port(CargoType.Ship, "Israel", "Ashdod", "Ashdod Port", 15);
            Port telAvivPort = new Port(CargoType.Train, "Israel", "Tel Aviv", "Tel Aviv Central", 20);
            Port eilatPort = new Port(CargoType.Airplane, "Israel", "Eilat", "Ramon", 300);

            // Items
            IPortable superComp = new GeneralItem(1, 1, 1, 200, false, usPort);
            IPortable bigStatueOfTrump = new GeneralItem(1, 1, 1, 1000, true, usPort);
            IPortable secretWeapon = new GeneralItem(1, 1, 1, 860, true, usPort);
            List<IPortable> itemsToLoad = new List<IPortable> { superComp, bigStatueOfTrump, secretWeapon };

            // 1. Ship Transport (USA -> Ashdod)
            Ship deliveryShip = new Ship(null, 50000, 200000, usPort, ashdodPort, 10000);
            Driver shipDriver = new Driver("John", "Doe", "007", CargoType.Ship);
            deliveryShip.SetDriver(shipDriver);
            driversList.Add($"{shipDriver.Name} {shipDriver.LastName}");

            CargoContainer shipContainer = new CargoContainer(50000, 200000);
            shipContainer.Load(itemsToLoad);
            deliveryShip.AddContainer(shipContainer);

            deliveryShip.DisplayContainers();
            totalPrice += deliveryShip.CalculatePrice(itemsToLoad, deliveryShip.GetNextPortDistance());
            totalKm += deliveryShip.GetNextPortDistance();

            deliveryShip.GoToNextDestination();
            shipContainer.UpdateItemLocations(ashdodPort);

            deliveryShip.DisplayContainers();
            shipContainer.Unload(itemsToLoad);
            deliveryShip.RemoveContainer(shipContainer);
            deliveryShip.DisplayContainers();

            // 2. Train Transport (Ashdod -> Tel Aviv)
            Train deliveryTrain = new Train(null, 50000, 200000, ashdodPort, telAvivPort, 40);
            Driver trainDriver = new Driver("David", "BenGurion", "008", CargoType.Train);
            deliveryTrain.SetDriver(trainDriver);
            driversList.Add($"{trainDriver.Name} {trainDriver.LastName}");

            Crone trainCrone = new Crone(50000, 200000);
            trainCrone.Load(itemsToLoad);
            deliveryTrain.AddCrone(trainCrone);

            deliveryTrain.DisplayCrones();
            totalPrice += deliveryTrain.CalculatePrice(itemsToLoad, deliveryTrain.GetNextPortDistance());
            totalKm += deliveryTrain.GetNextPortDistance();

            deliveryTrain.GoToNextDestination();
            trainCrone.UpdateItemLocations(telAvivPort);

            deliveryTrain.DisplayCrones();
            trainCrone.Unload(itemsToLoad);
            deliveryTrain.RemoveCrone(trainCrone);
            deliveryTrain.DisplayCrones();

            // 3. Airplane Transport (Tel Aviv -> Eilat)
            AirePlane deliveryPlane = new AirePlane(null, 50000, 200000, telAvivPort, eilatPort, 300);
            Driver planeDriver = new Driver("Amir", "Levi", "009", CargoType.Airplane);
            deliveryPlane.SetDriver(planeDriver);
            driversList.Add($"{planeDriver.Name} {planeDriver.LastName}");

            deliveryPlane.PlaneCargo.Load(itemsToLoad);

            deliveryPlane.DisplayCargo();
            totalPrice += deliveryPlane.CalculatePrice(itemsToLoad, deliveryPlane.GetNextPortDistance());
            totalKm += deliveryPlane.GetNextPortDistance();

            deliveryPlane.GoToNextDestination();
            deliveryPlane.PlaneCargo.UpdateItemLocations(eilatPort);

            deliveryPlane.DisplayCargo();
            deliveryPlane.PlaneCargo.Unload(itemsToLoad);
            deliveryPlane.DisplayCargo();

            // Display Summary
            PrintInYellow("--------------------------Delivery Summary---------------------------");
            Console.WriteLine($"Total Price: ${totalPrice}");
            Console.WriteLine($"Total Kilometers Traveled: {totalKm} KM");
            Console.WriteLine("Drivers Involved:");
            foreach (var driver in driversList)
            {
                Console.WriteLine($"- {driver}");
            }
            PrintInGreen("Delivery Test 5 (Complex Multi-Transport) Finished");

            return true;
        }



        static void PrintInGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine(text);
            Console.WriteLine("----------------------------------------------------------\n");
            Console.ResetColor();
        }

        static void PrintInRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine(text);
            Console.WriteLine("----------------------------------------------------------\n");
            Console.ResetColor();
        }

        static void PrintInYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine(text);
            Console.WriteLine("----------------------------------------------------------\n");
            Console.ResetColor();
        }
       
    }
}
