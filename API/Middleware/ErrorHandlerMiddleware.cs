﻿using Application.Common.Dto.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
using System.Text.Json;
using Application.Common.Exceptions;

namespace API.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };

                switch (error)
                {
                    case ApiException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
