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
    public class DrugGistController
    {
        private DrugGistRepository _drugGistRepository;
        private DrugStoreRepository _drugStoreRepository;
        public DrugGistController()
        {
            _drugGistRepository = new DrugGistRepository();
            _drugStoreRepository = new DrugStoreRepository();
        }

        #region Create
        public void Create()
        {
                
            var drugstores = _drugStoreRepository.GetAll();
            if (drugstores.Count != 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter druggist name");
                string name = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter druggist surname");
                string surname = Console.ReadLine();

                Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter druggist age");
                string age = Console.ReadLine();
                byte drugGistAge;
                bool result = byte.TryParse(age, out drugGistAge);
                if (result)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter druggist experience");
                    string experience = Console.ReadLine();
                    byte drugGistExperience;
                    bool result1 = byte.TryParse(experience, out drugGistExperience); 

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugstores");
                    foreach (var drugstore in drugstores)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $" ID - {drugstore.ID} Name - {drugstore.Name}");
                    }
                ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore ID");
                    string id = Console.ReadLine();
                    int drugstoreID;
                    bool result2 = int.TryParse(id, out drugstoreID);
                    if (result2)
                    {
                        var dbDrugStore = _drugStoreRepository.Get(d => d.ID == drugstoreID);
                        if (dbDrugStore != null)
                        {
                            DrugGist drugGist = new DrugGist
                            {
                                Name = name,
                                Surname = surname,
                                Age = drugGistAge,
                                Experience = drugGistExperience,
                            };
                            _drugGistRepository.Create(drugGist);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name - {drugGist.Name} Surname - {drugGist.Surname} Age - {drugGist.Age} Experience - {drugGist.Experience}");
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
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter age in correct format");
                    goto Age;
                }
                
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "You must create drugstore before creating of druggist");
            }

        }
        #endregion

        #region Update
        public void Update()
        {
            var druggists = _drugGistRepository.GetAll();
            if (druggists.Count > 0)
            {
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID - {druggist.ID} Name - {druggist.Name} Surname - {druggist.Surname} {druggist.Age} {druggist.Experience}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter druggist ID");
                string id = Console.ReadLine();
                int druggistID;
                bool result = int.TryParse(id, out druggistID);
                if (result)
                {
                    var dbdrugGist = _drugGistRepository.Get(d => d.ID == druggistID);
                    if (dbdrugGist != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter druggist new name");
                        string name = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter druggist new surname");
                        string surname = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter druggist new age");
                        string age = Console.ReadLine();
                        byte drugGistAge;
                        result = byte.TryParse(age, out drugGistAge);
                        if (result)
                        {

                        Experience: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter druggist new experience");
                            string experience = Console.ReadLine();
                            byte drgExperience;
                            var result1 = byte.TryParse(experience, out drgExperience);
                            if (result1)
                            {
                                var updatedDrugGist = new DrugGist
                                {
                                    ID = druggistID,
                                    Name = name,
                                    Surname = surname,
                                    Age = drugGistAge,
                                    Experience = drgExperience,
                                };
                                _drugGistRepository.Update(updatedDrugGist);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{updatedDrugGist.Name} {updatedDrugGist.Surname} {updatedDrugGist.Age} {updatedDrugGist.Experience} is updated to successfully");
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter experience in correct format");
                                goto Experience;
                            }

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter age in correct format");
                        }
                        
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Druggist doesn't exist with this ID");
                        goto ID;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There are not any druggist");
                }
            }
            
        }
        #endregion

        #region Delete
        public void Delete()
        {
            var druggists = _drugGistRepository.GetAll();
            if (druggists.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All druggist list");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID - {druggist.ID} Name - {druggist.Name} Surname - {druggist.Surname} Age - {druggist.Age}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter druggist ID");
                string id = Console.ReadLine();
                int drugGistID;
                bool result = int.TryParse(id, out drugGistID);
                if (result)
                {
                    var druggist = _drugGistRepository.Get(d => d.ID == drugGistID);
                    if (druggist != null)
                    {
                        string AllInfo = $"{druggist.Name} {druggist.Surname}";
                        _drugGistRepository.Delete(druggist);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{AllInfo} is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Druggist doesn't exist with this ID");
                        goto ID;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter druggist ID in correct format");
                    goto ID;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There are not any druggist");
            }
        }
        #endregion

        #region GetAll
        public void GetAll()
        {
            var druggists = _drugGistRepository.GetAll();
            if (druggists.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All druggist list");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID -- {druggist.ID} Name -- {druggist.Surname} Surname -- {druggist.Surname} Age -- {druggist.Age} Experience -- {druggist.Experience}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is not any druggists");
            }
        }
        #endregion

        #region GetALllDrugGistByDrugStore
        public void GetAllDrugGistByDrugstore()
        {
            var drugstores = _drugStoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All drugstore list");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID -- {drugstore.ID} Name -- {drugstore.Name} Address -- {drugstore.Address} ");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore ID");
                string id = Console.ReadLine();
                int drugStoreID;
                var result = int.TryParse(id, out drugStoreID);
                if (result)
                {
                    var dbDrugStore = _drugStoreRepository.Get(d => d.ID == drugStoreID);
                    if (dbDrugStore != null)
                    {
                        var drugGistStore = _drugGistRepository.GetAll(d => d.ID == drugStoreID);
                        if (drugGistStore.Count != 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "All druggist of the drugstore");
                            foreach (var druggistStore in drugGistStore)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"ID -- {druggistStore.ID} Druggist Name - {druggistStore.Name}  Druggist Surname -- {druggistStore.Surname}  Druggist Age -- {druggistStore.Age} Druggist Experience -- {druggistStore.Experience}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is no drugstore in this druggist");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Druggist doesn't exist with this ID");
                        goto ID;

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter druggist ID in correct format");
                    goto ID;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is not any druggist");
            }
        }

    }
    #endregion
}
