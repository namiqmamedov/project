using Core.Entities;
using Core.Helper;
using DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace Manage.Controller
{
    public class DrugController
    {
        private DrugRepository _drugRepository;
        private DrugStoreRepository _drugStoreRepository;

        public DrugController()
        {
            _drugRepository = new DrugRepository();
            _drugStoreRepository = new DrugStoreRepository();
        }

        #region Create
        public void Create()
        {           
            var drugstores = _drugStoreRepository.GetAll();
            if (drugstores.Count > 0)
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter new drug name");
                string name = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter new drug price");
                string price = Console.ReadLine();
                double drugPrice;
                bool result = double.TryParse(price, out drugPrice);

            Count: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter new drug count");
                string count = Console.ReadLine();
                int drugCount;
                var result1 = int.TryParse(count, out drugCount);
                if (result1)
                {
                    if (drugCount <= 0)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "You cannot write numbers less than 0");
                        goto Count;
                    }

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugstores");
                    foreach (var drugstore in drugstores)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID -- {drugstore.ID} Drugstore name - {drugstore.Name} Drugstore Address - {drugstore.Address} Contact Number - {drugstore.ContactNumber}");
                    }
                ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore ID");
                    string id = Console.ReadLine();
                    int storeID;
                    bool result2 = int.TryParse(id, out storeID);
                    if (result2)
                    {
                        var dbStore = _drugStoreRepository.Get(d => d.ID == storeID);
                        if (dbStore != null)
                        {
                            Drug drug = new Drug
                            {
                                Name = name,
                                Price = drugPrice,
                                Count = drugCount,
                                DrugStore = dbStore,
                            };
                            _drugRepository.Create(drug);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name -- {drug.Name} Price -- {drug.Price} Count -- {drug.Count} Drugstore -- {drug.DrugStore.Name} is creating successfully");
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Including drugstore doesn't exist");
                            goto ID;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter drugstore ID in correct format");
                        goto ID;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter drug count in correct format");
                    goto Count;

                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "You must create drugstore before creating drugs");
            }
        }
        #endregion

        #region Update
        public void Update()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugs list");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Drugstore ID - {drug.DrugStore.ID} Drugstore name - {drug.DrugStore.Name}  Drugs name - {drug.Name} Drugs Price - {drug.Price} Drugs Count - {drug.Count}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugs ID");
                string id = Console.ReadLine();
                int storeID;
                var result = int.TryParse(id, out storeID);
                if (result)
                {
                    var drugStoreID = _drugStoreRepository.GetAll();
                    if (drugStoreID != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugs new name");
                        string name = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugs new price");
                        string price = Console.ReadLine();
                        double drugPrice;
                        bool result1 = double.TryParse(price, out drugPrice);

                    Count: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugs new count");

                        string count = Console.ReadLine();
                        int drugCount;
                        result = int.TryParse(count, out drugCount);
                        if (result)
                        {
                            var updatedDrugs = new Drug
                            {
                                Name = name,
                                Price = drugPrice,
                                Count = drugCount,
                            };
                            _drugRepository.Update(updatedDrugs);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{updatedDrugs.Name} {updatedDrugs.Price} {updatedDrugs.Count} is updated to successfully");
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter count in correct format");
                        }

                        if (drugCount <= 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "You cannot write numbers less than 0");
                            goto Count;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Drugstore doesnt exist with this ID");
                        goto ID;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter correct ID");
                    goto ID;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There are not any drugstores");
            }

        }
        #endregion

        #region Delete
        public void Delete()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugs list");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Drugstore name -- {drug.DrugStore.Name} Drugs ID -- {drug.ID} Drugs Name -- {drug.Name} Drugs Price -- {drug.Price} Drugs Count -- {drug.Count}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugs ID");
                string id = Console.ReadLine();
                int drugstoreID;
                var result = int.TryParse(id, out drugstoreID);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.ID == drugstoreID);
                    if (drug != null)
                    {
                        string allInfo = $"{drug.Name} {drug.Price} {drug.Count}";
                        _drugRepository.Delete(drug);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{allInfo} is deleted ");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Drug doesn't exist with this ID");
                        goto ID;
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter ID in correct format");
                    goto ID;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There are not any drugs");
            }
        }
        #endregion

        #region GetAll

        public void GetAll()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugs list");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Drugstore info - {drug.DrugStore.Name} {drug.DrugStore.ID} Drugs info - {drug.Name} {drug.Price} {drug.Count}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is no any drugs");
            }
        }
        #endregion

        #region GetAllDrugsByDrugStore

        public void GetAllDrugsByDrugStore()
        {
            var drugstores = _drugStoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugstores list");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID - {drugstore.ID} {drugstore.Name} {drugstore.Address} {drugstore.ContactNumber}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore ID");
                string id = Console.ReadLine();
                int drugstoreID;
                bool result = int.TryParse(id, out drugstoreID);
                if (result)
                {
                    var dbDrugStore = _drugStoreRepository.Get(d => d.ID == drugstoreID);
                    if (dbDrugStore != null)
                    {
                        var drugs = _drugRepository.GetAll(d => d.ID == drugstoreID);
                        if (drugs.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "All drugs of drugstore");
                            foreach (var drug in drugs)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"ID - {drug.ID} Name - {drug.Name}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "The drugstore has no drugs");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Drugstore doesn't exist with this ID");
                        goto ID;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter ID in correct format");
                    goto ID;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is no drugstore here");
            }
        }

        #endregion

        #region Filter
        public void Filter()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please, enter price");
                string price = Console.ReadLine();
                double FilterPrice;
                bool result = double.TryParse(price, out FilterPrice);
                if (result)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugs list");
                    foreach (var drug in drugs)
                    {
                        if (drug.Price <= FilterPrice)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID -- {drug.ID} Name -- {drug.Name} Price -- {drug.Price}  Count -- {drug.Count}");
                        }
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter price in correct format");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is no drugs here");
            }
        }

        #endregion
    }
}
