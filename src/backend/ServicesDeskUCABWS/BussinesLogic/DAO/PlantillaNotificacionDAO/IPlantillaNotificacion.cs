﻿using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacioneDAO
{
    public interface IPlantillaNotificacion
    {
        public List<PlantillaNotificacionDTO> ConsultaPlantillas();
        public PlantillaNotificacionDTO ConsultarPlantillaGUID(Guid id);
        public PlantillaNotificacionDTO ConsultarPlantillaTitulo(string titulo);
        public PlantillaNotificacionDTO ConsultarPlantillaTipoEstadoID(Guid id);
        public PlantillaNotificacionDTO ConsultarPlantillaTipoEstadoTitulo(string tituloTipoEstado);
        public Boolean RegistroPlantilla(PlantillaNotificacionDTOCreate plantilla);
        public Boolean ActualizarPlantilla(PlantillaNotificacionDTOCreate plantilla, Guid id);
        public Boolean EliminarPlantilla(Guid id);
        //public Boolean ValidarRelacionPlantillaTipo(Guid tipoEstadoId);
    }
}
