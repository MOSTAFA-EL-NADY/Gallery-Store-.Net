﻿
global using AutoMapper;
global using Gallery.Dto;
global using Gallery.Extensions;
global using Gallery.Features.Account.Command.Login;
global using Gallery.Features.Account.Command.Register;
global using Gallery.Features.Albums.Command.Delete;
global using Gallery.Features.Albums.Command.Post;
global using Gallery.Features.Albums.Command.Put;
global using Gallery.Features.Albums.Query.GetAll;
global using Gallery.Features.Albums.Query.GetById;
global using Gallery.Features.Images.Command.Delete;
global using Gallery.Features.Images.Command.Post;
global using Gallery.Features.Images.Query;
global using Gallery.Features.Users.Query;
global using Gallery.GallleryStoreContext;
global using Gallery.Helper;
global using Gallery.Interface;
global using Gallery.MiddleWare.ExceptionHandler;
global using Gallery.Models;
global using Gallery.Repository;
global using Gallery.Services;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.OData;
global using Microsoft.AspNetCore.OData.Query;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.ChangeTracking;
global using Microsoft.Extensions.FileProviders;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.IdentityModel.Tokens.Jwt;
global using System.Linq.Expressions;
global using System.Net;
global using System.Reflection;
global using System.Security.Claims;
global using System.Text;
