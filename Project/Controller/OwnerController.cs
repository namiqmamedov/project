using Core.Entities;
using Core.Helper;
using DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controller
{
    public class OwnerController
    {
        private OwnerRepository _ownerRepository;

        public OwnerController()
        {
            _ownerRepository = new OwnerRepository();
        }


        #region Create
        public void Create()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter owner name:");
            string name = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter owner surname:");
            string surname = Console.ReadLine();

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} {surname} is created successfully");
            Owner owner = new Owner
            {
                Name = name,
                Surname = surname,
            };
            _ownerRepository.Create(owner);
            
        }
        #endregion

        #region Update
        public void Update()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID - {owner.ID}  Fullname - {owner.Name} {owner.Surname}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter owner ID");
                string id = Console.ReadLine();
                int chosenID;
                var result = int.TryParse(id, out chosenID);
                if (result)
                {
                    var dbOwner = _ownerRepository.Get(o => o.ID == chosenID);
                    if (dbOwner != null)
                    {
                        string oldName = dbOwner.Name;
                        string oldSurname = dbOwner.Surname;

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please, enter owner new name");
                        string newName = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please, enter owner new surname");
                        string newSurname = Console.ReadLine();

                        var updatedOwner = new Owner
                        {
                            ID = dbOwner.ID,
                            Name = newName,
                            Surname = newSurname,
                        };
                        _ownerRepository.Update(updatedOwner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{oldName} {oldSurname} is updated to {updatedOwner.Name} {updatedOwner.Surname}");


                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Owner doens't exist with this ID");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There are not any owner");
            }

        }

        #endregion

        #region Delete

        public void Delete()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All owner list");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID - {owner.ID} Fullname - {owner.Name} {owner.Surname}");
                }
                ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter owner ID");
                string id = Console.ReadLine();
                int ownerID;
                var result = int.TryParse(id, out ownerID);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.ID == ownerID);
                    if (owner != null)
                    {
                        string fullName = $"{owner.Name} {owner.Surname}";
                        _ownerRepository.Delete(owner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{fullName} is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Owner doesn't exist with this ID");
                        goto ID;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Enter ID in correct format");
                    goto ID;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There are not any owners");
            }

        }
        #endregion

        #region GetAll
        public void GetAll()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All owner list");
                foreach (var owner in owners)
                {
                                                        
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID -- {owner.ID} Fullname -- {owner.Name} {owner.Surname}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There are not any owners");
            }
        }

        #endregion
    }
}












