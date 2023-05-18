using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;
        public Controller()
        {
            booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(booths.Models.Count + 1, capacity);
            booths.AddModel(booth);
            return $"Added booth number {booth.BoothId} with capacity {booth.Capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            //booths.Models.Any(b=>b.CocktailMenu.Models.Any(c=>c.Name == cocktailName)) && booths.Models.Any(b => b.CocktailMenu.Models.Any(c => c.Size == size)))
            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            if (cocktailTypeName != "MulledWine" && cocktailTypeName != "Hibernation")
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }
            else if (size != "Large" && size != "Middle" && size != "Small")
            {
                return $"{size} is not recognized as valid cocktail size!";
            }
            //check if you need to search the given booth insted of whole collection
            else if (booth.CocktailMenu.Models.Any(c=>c.Name == cocktailName && c.Size == size))
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }
            ICocktail cocktail = null;
            if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            //var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            booth.CocktailMenu.AddModel(cocktail);

            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            //check here
            if (delicacyTypeName != "Stolen" && delicacyTypeName != "Gingerbread")
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }
            //check if you need to search the given booth insted of whole collection
            else if (booth.DelicacyMenu.Models.Any(d=>d.Name == delicacyName))
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }

            IDelicacy delicacy = null;
            if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }
            else if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            //var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            booth.DelicacyMenu.AddModel(delicacy);

            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string BoothReport(int boothId)
        {
            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            return booth.ToString().TrimEnd();
        }

        public string LeaveBooth(int boothId)
        {
            //check here
            StringBuilder sb = new StringBuilder();
            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");
            booth.Charge();
            booth.ChangeStatus();
            sb.AppendLine($"Booth {booth.BoothId} is now available!");
            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            var booth = booths.Models.Where(b => b.IsReserved == false && b.Capacity >= countOfPeople).ToList();
            if (booth.Count == 0)
            {
                return $"No available booth for {countOfPeople} people!";
            }
            var firstBooth = booth.OrderBy(b => b.Capacity).ThenByDescending(b => b.BoothId).First();
            firstBooth.ChangeStatus();

            return $"Booth {firstBooth.BoothId} has been reserved for {countOfPeople} people!";
        }

        public string TryOrder(int boothId, string order)
        {
            //TryOrder 1 MulledWine / Redstar / 2 / Middle
            //TryOrder 1 Gingerbread / Santabiscuit / 2
            string[] tokens = order.Split('/',StringSplitOptions.RemoveEmptyEntries);
            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            ICocktail cocktail = null;
            IDelicacy delicacy = null;
            if (tokens.Length == 4)
            {
                string itemType = tokens[0];
                string itemName = tokens[1];
                int orderedCount = int.Parse(tokens[2]);
                string size = tokens[3];

                if (itemType != "MulledWine" && itemType != "Hibernation")
                {
                    return $"{itemType} is not recognized type!";
                }
                else if (!booth.CocktailMenu.Models.Any(c=>c.Name == itemName))
                {
                    return $"There is no {itemType} {itemName} available!";
                }

                if (itemType == "MulledWine")
                {
                    cocktail = new MulledWine(itemName, size);
                }
                else if (itemType == "Hibernation")
                {
                    cocktail = new Hibernation(itemName, size);
                }
                
                if (!booth.CocktailMenu.Models.Any(c => c.Name == itemName && c.GetType().Name == itemType && c.Size == size))
                {
                    return $"There is no {size} {itemName} available!";
                }

                booth.UpdateCurrentBill(cocktail.Price * orderedCount);

                return $"Booth {boothId} ordered {orderedCount} {itemName}!";
            }
            else
            {
                string itemType = tokens[0];
                string itemName = tokens[1];
                int orderedCount = int.Parse(tokens[2]);

                if (itemType != "Stolen" && itemType != "Gingerbread")
                {
                    return $"{itemType} is not recognized type!";
                }
                else if (!booth.DelicacyMenu.Models.Any(d => d.Name == itemName))
                {
                    return $"There is no {itemType} {itemName} available!";
                }

                if (itemType == "Stolen")
                {
                    delicacy = new Stolen(itemName);
                }
                else if (itemType == "Gingerbread")
                {
                    delicacy = new Gingerbread(itemName);
                }

                if (!booth.DelicacyMenu.Models.Any(c => c.Name == itemName && c.GetType().Name == itemType))
                {
                    return $"There is no {itemType} {itemName} available!";
                }

                booth.UpdateCurrentBill(delicacy.Price * orderedCount);

                return $"Booth {boothId} ordered {orderedCount} {itemName}!";
            }

        }
    }
}
