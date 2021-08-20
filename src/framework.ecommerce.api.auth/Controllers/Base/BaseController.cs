using framework.ecommerce.auth.domain.Dto.Base;
using framework.ecommerce.auth.domain.Enum;
using framework.ecommerce.util;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace framework.ecommerce.auth.Controllers.Base
{
    /// <summary>
    /// BaseController
    /// </summary>
    [ApiController]
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Erros
        /// </summary>
        protected ICollection<string> Erros = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="statusResponse"></param>
        /// <returns></returns>
        protected ActionResult CustomResponse<T>(T result = null, StatusCodeApi statusResponse = StatusCodeApi.Ok) where T : class
        {
            var response = new Response<T>();

            if (IsValid())
            {
                response.Object = result;
                response.Success = true;

                if (statusResponse == StatusCodeApi.Created)
                    return StatusCode(201, response);
                else
                    return Ok(response);
            }
            else
            {
                response.Messages = Erros.ToList();
                response.Success = false;

                if (Erros.Contains(Constantes.NENHUM_REGISTRO_ENCONTRADO))
                {
                    return NotFound(response);
                }
                else if (Erros.Contains(Constantes.ACESSO_NEGADO))
                {
                    return Forbid();
                }
                return BadRequest(response);
            }

        }

        /// <summary>
        /// CustomResponse
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AddError(erro.ErrorMessage);
            }

            return CustomResponse<object>();
        }

        /// <summary>
        /// CustomResponse
        /// </summary>
        /// <param name="validationResult"></param>
        /// <returns></returns>
        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AddError(erro.ErrorMessage);
            }

            return CustomResponse<object>();
        }

        /// <summary>
        /// IsValid
        /// </summary>
        /// <returns></returns>
        protected bool IsValid()
        {
            return !Erros.Any();
        }
        /// <summary>
        /// AddError
        /// </summary>
        /// <param name="erro"></param>
        protected void AddError(string erro)
        {
            Erros.Add(erro);
        }

        /// <summary>
        /// ClearErrors
        /// </summary>
        protected void ClearErrors()
        {
            Erros.Clear();
        }

        /// <summary>
        /// Condition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expressao"></param>
        /// <returns></returns>
        public Expression<Func<T, bool>> Condition<T>(Expression<Func<T, bool>> expressao)
        {
            return expressao;
        }

    }
}
