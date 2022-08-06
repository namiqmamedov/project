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
    public class DrugStoreController
    {
        private DrugStoreRepository _drugStoreRepository;
        private OwnerRepository _ownerRepository;
        private DrugRepository _drugRepository;
        public DrugStoreController()
        {
            _drugStoreRepository = new DrugStoreRepository();
            _ownerRepository = new OwnerRepository();
            _drugRepository = new DrugRepository();
        }

        public void Create()
        {              
            var owners = _ownerRepository.GetAll();
            if (owners.Count != 0)
            {                         
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore name");
                string name = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore address");
                string address = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore contact number");
                string number = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All owners");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID - {owner.ID} Fullname - {owner.Name} {owner.Surname}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter owner ID:");
                string id = Console.ReadLine();
                int ownerID;
                bool result = int.TryParse(id, out ownerID);
                if (result)
                {
                    var dbOwner = _ownerRepository.Get(o => o.ID == ownerID);

                    if (dbOwner != null)
                    {
                        DrugStore drugStore = new DrugStore
                        {
                            Name = name,
                            Address = address,
                            ContactNumber = number,
                            Owner = dbOwner,
                        };

                        _drugStoreRepository.Create(drugStore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{drugStore.Name} Address:{drugStore.Address} ContactNumber:{drugStore.ContactNumber} Owner:{drugStore.Owner.Name}");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, $"Owner doesn't exist with this ID");
                        goto ID;

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter owner ID in correct format");
                    goto ID;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, $"You must create owner before creating of drugstore");
            }

        }

        public void Update()
        {
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All list");
                foreach (var drugstore in drugStores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Owner ID - {drugstore.Owner.ID} Owner Name - {drugstore.Owner.Name} Drugstore name - {drugstore.Name} Drugstore Address - {drugstore.Address}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter owner ID");
                string id = Console.ReadLine();
                int ownerID;
                bool result = int.TryParse(id, out ownerID);
                if (result)
                {
                    var dbDrugStore = _drugStoreRepository.Get(d => d.ID == ownerID);
                    if (dbDrugStore != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore new name");
                        string Name = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore new address");
                        string Address = Console.ReadLine();

                    ContactNumber: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore new contact number");
                        string Number = Console.ReadLine();

                        var updatedStore = new DrugStore
                        {
                            Name = Name,
                            Address = Address,
                            ContactNumber = Number,
                        };
                        _drugStoreRepository.Update(updatedStore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{updatedStore.Name} {updatedStore.Address} {updatedStore.ContactNumber} is updated to successfully");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Owner doesn't exist with this ID");
                        goto ID;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter owner ID in correct format");
                    goto ID;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There are not any owner");
            }
        }

        public void Delete()
        {
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugstore list");
                foreach (var drugstore in drugStores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Owner ID -- {drugstore.Owner.ID} Owner Name -- {drugstore.Owner.Name} Drugstore Name -- {drugstore.Name} Drugstore Address -- {drugstore.Address} Contact Number -- {drugstore.ContactNumber}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter owner ID");
                string id = Console.ReadLine();
                int ownerID;
                var result = int.TryParse(id, out ownerID);
                if (result)
                {
                    var drugstore = _drugStoreRepository.Get(o => o.ID == ownerID);
                    if (drugstore != null)
                    {
                        string allInfo = $"{drugstore.Name} {drugstore.Address}";
                        _drugStoreRepository.Delete(drugstore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{allInfo} is deleted  ");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Drugstore doesn't exist with this ID");
                        goto ID;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter owner ID in correct format");
                    goto ID;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There are not any drugstore");
            }
        }

        public void GetAll()
        {
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugstore list");
                foreach (var drugstore in drugStores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Owner - {drugstore.Owner.Name} Drugstore Name - {drugstore.Name} Drugstore Address - {drugstore.Address} Drugstore Contact Number - {drugstore.ContactNumber}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is not any drugstores");
            }
        }

        public void GetAllDrugStoresByOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All owner list");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID -- {owner.ID} Fullname -- {owner.Name} {owner.Surname}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter owner ID");
                string id = Console.ReadLine();
                int ownerID;
                var result = int.TryParse(id, out ownerID);
                if (result)
                {
                    var dbOwner = _ownerRepository.Get(o => o.ID == ownerID);
                    if (dbOwner != null)
                    {
                        var ownerDrugStore = _drugStoreRepository.GetAll(o => o.Owner.ID == ownerID);
                        if (ownerDrugStore.Count != 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugstore of the owner");
                            foreach (var ownerdrugstore in ownerDrugStore)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"ID - {ownerdrugstore.ID} Drugstore Name  - {ownerdrugstore.Name} Drugstore Address {ownerdrugstore.Address}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is no owner in this drugstore");
                           
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Including owner doesn't exist");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is not any owner");
            }
        }

        public void Sale()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugs list");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Drugs ID - {drug.ID} Drugs list - {drug.Name} Price - {drug.Price} Count - {drug.Count} ");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugs ID");
                string id = Console.ReadLine();
                int drugsID;
                bool result = int.TryParse(id, out drugsID);
                if (result)
                {
                    var dbDrugs = _drugRepository.Get(d => d.ID == drugsID);
                    if (dbDrugs != null && dbDrugs.Count> 0)
                    {
                    Count: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please, enter drug count");
                        string count = Console.ReadLine();
                        int dbCount;
                        result = int.TryParse(count, out dbCount);
                        if (result)
                        {
                            if (dbCount<=dbDrugs.Count)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow,$"Price -- {dbCount * dbDrugs.Price}");
                                dbDrugs.Count-=dbCount;
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "You have exceeded the number of drugs");
                                goto Count;
                            }
                            if (dbCount == 0)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "It is not possible to receive");
                                goto Count;
                                
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter count in correct format");
                            goto Count;
                        }

                        
                        
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed,"Drugs doesn't exist with this ID");
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
    }
}
