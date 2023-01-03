﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.DTO.DepartamentoDTO;
using ServiceDeskUCAB.Models.DTO.GrupoDTO;

namespace ServiceDeskUCAB.Servicios.ModuloDepartamento
{
    public interface IServicioDepartamento_API
    {
        Task<JObject> RegistrarDepartamento(DepartamentoModel dept);
        Task<JObject> EditarDepartamento(DepartamentoModel dept);
        Task<JObject> EliminarDepartamento(Guid id);
        Task<DepartamentoModel> MostrarInfoDepartamento(Guid id);
        Task<List<DepartamentoModel>> ListaDepartamento();
        Task<List<DepartamentoModel>> ListaDepartamentoNoAsociado();
    }
}