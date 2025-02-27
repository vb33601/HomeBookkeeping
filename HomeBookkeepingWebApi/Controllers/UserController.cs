﻿using HomeBookkeepingWebApi.Domain.DTO;
using HomeBookkeepingWebApi.Domain.Paging;
using HomeBookkeepingWebApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HomeBookkeepingWebApi.Controllers
{
    [Route("api/")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userSer;
        public UserController(IUserService userSer)=> _userSer = userSer;

        /// <summary>
        /// Список всех пользователей.
        /// </summary>
        /// <returns>Вывод всех пользователей</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /users
        ///     
        ///        PageNumber: Номер страницы   // Введите номер страницы, которую нужно показать с списоком всех пользователей.
        ///        PageSize: Размер страницы    // Введите размер страницы, какое количество пользователей нужно вывести.
        ///
        /// </remarks> 
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="404"> Список всех пользователей не найден. </response>
        [HttpGet]
        [Route("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsers([FromQuery] PagingQueryParameters paging)
        {
            var users = await _userSer.GetServiceAsync(paging);
            if (users is null)
            {
                return NotFound(users);
            }
            var metadata = new
            {
                users.Result.TotalCount,
                users.Result.PageSize,
                users.Result.CurrentPage,
                users.Result.TotalPages,
                users.Result.HasNext,
                users.Result.HasPrevious
            };
            Response?.Headers?.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(users);
        }

        /// <summary>
        /// Вывод пользователя по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Вывод данных пользователя</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /user/{id:int}
        ///     
        ///        Id: 0   // Введите id пользователя, которого нужно показать.
        ///     
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="400"> Недопустимое значение ввода </response>
        /// <response code="404"> Пользователь не найдена </response>
        [HttpGet]
        [Route("user/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            var user = await _userSer.GetByIdServiceAsync(id);
            if (user.Result is null)
            {
                return NotFound(user);
            }
            return Ok(user);
        }

        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns>Создаётся пользователь</returns>
        /// <remarks>
        /// 
        ///     Свойство ["userId" и "сreditСard"] указывать не обязательно.
        /// 
        /// Образец ввовда данных:
        ///
        ///     POST /user
        ///     
        ///     {
        ///       "userId": 0,                    // id пользователя.
        ///       "fullName": "string",           // Полное имя пользователя.
        ///       "сreditСard": [                 // Данные кредитной карты.
        ///         {
        ///           "сreditСardId": 0,          // id кредитной карты.
        ///           "userId": 0,                // id пользователя, которому принадлежит кредитная карта.
        ///           "cardName": "string",       // Hазвание кредитной карты.
        ///           "userFullName": "string",   // Полное имя пользователя, которому принадлежит кредитная карта.
        ///           "number": "string",         // Номер кредитной карты.
        ///           "r_Account": "string",      // Расчетный счёт крединой карты.
        ///           "sum": 0                    // Баланс кредитной карты.
        ///         }         
        ///       ],                            
        ///       "email": "string",              // Электронная почта.
        ///       "phoneNumber": "string"         // Номер телефона.
        ///     }
        ///
        /// </remarks>
        /// <response code="201"> Пользователь создан. </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        [HttpPost]
        [Route("user")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDTO)
        {
            var user = await _userSer.CreateServiceAsync(userDTO);
            if (user.Result is null)
            {
                return BadRequest(user);
            }
            return CreatedAtAction(nameof(GetUsers), userDTO);
        }

        /// <summary>
        /// Редактирование пользователя.
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns>Обновление пользователя.</returns>
        /// <remarks>
        /// Образец ввовда данных:
        ///
        ///     PUT /user
        ///     
        ///     {
        ///       "userId": 0,                    // id пользователя.
        ///       "fullName": "string",           // Полное имя пользователя.
        ///       "сreditСard": [                 // Данные кредитной карты.
        ///         {
        ///           "сreditСardId": 0,          // id кредитной карты.
        ///           "userId": 0,                // id пользователя, которому принадлежит кредитная карта.
        ///           "cardName": "string",       // Hазвание кредитной карты.
        ///           "userFullName": "string",   // Полное имя пользователя, которому принадлежит кредитная карта.
        ///           "number": "string",         // Номер кредитной карты.
        ///           "r_Account": "string",      // Расчетный счёт крединой карты.
        ///           "sum": 0                    // Баланс кредитной карты.
        ///         }         
        ///       ],                            
        ///       "email": "string",              // Электронная почта.
        ///       "phoneNumber": "string"         // Номер телефона.
        ///     }
        ///
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="404"> Пользователь не найден. </response>
        [HttpPut]
        [Route("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO userDTO)
        {
            var user = await _userSer.UpdateServiceAsync(userDTO);
            if (user.Result is null)
            {
                return NotFound(user);
            }
            return Ok(user);
        }

        /// <summary>
        /// Удаление пользователя.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Пользователь удаляется.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     DELETE /user/{id}
        ///     
        ///        Id: 0   // Введите id пользователя, которого нужно удалить.
        ///     
        /// </remarks>
        /// <response code="204"> Пользователь удалён. (нет содержимого) </response>
        /// <response code="400"> Недопустимое значение ввода </response>
        /// <response code="404"> Пользователь c указанным id не найден. </response>
        [HttpDelete]
        [Route("user/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            var user = await _userSer.DeleteServiceAsync(id);
            if (user.Result is false)
            {
                return NotFound(user);
            }
            return NoContent();
        }

        /// <summary>
        /// Вывод данных пользователя по полному имени.
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns>Вывод данных пользователя</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /user/{fullName}
        ///     
        ///        fullName: Иван Иванов   // Введите полное имя пользователя, которого нужно показать.
        ///     
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="404"> Пользователь не найден. </response>
        [HttpGet]
        [Route("user/{fullName}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFullNameUser(string fullName)
        {
            var user = await _userSer.GetByFullNameServiceAsync(fullName);
            if (user.Result is null)
            {
                return NotFound(user);
            }
            return Ok(user);
        }
    }
}
