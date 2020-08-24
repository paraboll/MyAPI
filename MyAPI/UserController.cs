using Microsoft.AspNetCore.Mvc;
using MyAPI.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserRepository userRepository;

        public UserController(UserRepository userRepository)
        {
            //UserRepository userRepository внедрен через DI в StartUP -> ConfigureServices.
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Метод выводит в JSON формате всех пользователей из бд.
        /// Пример вызова (GET): api/user/getusers
        /// </summary>
        /// <returns>Список пользователей в JSON формате</returns>
        [Route("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        /// <summary>
        /// Метод выводит в JSON формате всех пользователя из бд с определенный ID.
        /// Пример вызова (GET): api/user/getuser/5
        /// </summary>
        /// <param name="id">ID пользователя</param>
        /// <returns>Пользователь в JSON формате</returns>
        [Route("GetUser/{id}")]
        public User GetUser(int id)
        {
            return userRepository.GetByID(id);
        }

        /// <summary>
        /// Добавление пользователя в бд.
        /// Пример вызова (POST): api/user/adduser?name=fdsgsd&age=17
        /// </summary>
        /// <param name="user">Данные о пользователе которые необходимо добавить (Name, Age)</param>
        [Route("AddUser")]
        public void AddUser(User user)
        {
            if (ModelState.IsValid)
                userRepository.Add(user);
        }

        /// <summary>
        /// Метод обновляет данные о пользователе.
        /// Пример вызова (PUT): api/user/adduser?ad=17&name=Нормальное Имя&age=77
        /// </summary>
        /// <param name="id">Id пользователя, которого обновляем</param>
        /// <param name="user">Новая информация о нем (Name, Age)</param>
        [Route("UpdateUser/{id}")]
        public void Put(int id, User user)
        {
            user.Id = id;
            if (ModelState.IsValid)
                userRepository.Update(user);
        }

        /// <summary>
        /// Метод удаляет пользователя по Id из бд.
        /// Пример вызова (DELETE): api/user/deleteuser/17
        /// </summary>
        /// <param name="id">Id пользователя, которого нужно удалить</param>
        [Route("DeleteUser/{id}")]
        public void DeleteUser(int id)
        {
            userRepository.Delete(id);
        }

        /// <summary>
        /// Добавляем в БД тестовый dataFrame.
        /// Пример выхзова (POST): api/user/adddataframe
        /// </summary>
        [Route("AddDataFrame")]
        public void AddDataFrame()
        {
            userRepository.AddDataFrame();
        }
    }
}
