﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.BussinesLogic.ApplicationResponse;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;

using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Net;

namespace ServicesDeskUCABWS.Controllers
{
    [Route("Ticket"),ApiController]
    public class TicketController
    {
        private readonly ITicketDAO _ticketDAO;
        private readonly IMapper _mapper;
        public TicketController(IMapper mapper, ITicketDAO ticketDAO)
        {
            _mapper = mapper;
            _ticketDAO = ticketDAO;
        }

        [HttpPost, Route("Guardar")]
        public ApplicationResponse<string> crearTicketCtrl([FromBody] TicketNuevoDTO nuevoTicket)
        {
            return _ticketDAO.crearTicket(nuevoTicket);
        }

        [HttpGet, Route("Obtener/{id}")]
        public ApplicationResponse<TicketInfoCompletaDTO> obtenerTicketPorIdCtrl(string id)
        {
            return _ticketDAO.obtenerTicketPorId(new Guid(id));
        }

        // No esta listo
        [HttpGet,Route("Lista/{departamentoId}/{opcion}")]
        public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerTicketsPorEstadoYDepartamentoCtrl(string departamentoId, string opcion)
        {
            return _ticketDAO.obtenerTicketsPorEstadoYDepartamento(new Guid(departamentoId), opcion);
        }

<<<<<<< HEAD
        /*[HttpPut, Route("anadirBitacora")]
        public ApplicationResponse<string> anadirALaBitacoraCtrl([FromBody] BitacoraTicketDTO tickets)
        {
            var respuesta = new ApplicationResponse<string>();
            try
            {
                //_ticketDAO.anadirALaBitacora(tickets.ticketDTO);
                //respuesta.Data = $"Bitacora del ticket{tickets.ticketDTO.Id} modificada";
                respuesta.Message = "Proceso Exitoso";
                respuesta.StatusCode = HttpStatusCode.OK;
                respuesta.Exception = null;
            }
            catch (Exception ex)
            {
                respuesta.Data = "No se pudo añadir la bitacora al ticket";
                respuesta.Message = ex.Message;
                respuesta.Success = false;
                //respuesta.Exception = ex.InnerException.ToString();
            }
            return respuesta;
        [HttpPut, Route("cambiarEstadoTicket/{ticketId}/{estadoId}")]
        public ApplicationResponse<string> cambiarEstadoTicketCtrl(string ticketId, string estadoId)
        {
=======
        [HttpPut, Route("cambiarEstadoTicket/{ticketId}/{estadoId}")]
        public ApplicationResponse<string> cambiarEstadoTicketCtrl(string ticketId, string estadoId)
        {
>>>>>>> d526b598ac596331fb4246c13686f83d90789e4c
            return _ticketDAO.cambiarEstadoTicket(new Guid(ticketId), new Guid(estadoId));
        }

        [HttpGet, Route("obtenerBitacorasTicket/{ticketId}")]
        public ApplicationResponse<List<TicketBitacorasDTO>> obtenerBitacorasCtrl(string ticketId)
        {
            return _ticketDAO.obtenerBitacoras(new Guid(ticketId));
        }
        [HttpPut, Route("Merge")]
        public ApplicationResponse<string> mergeTicketsCtrl([FromBody] TicketsMergeDTO ticketsMerge)
        {
            return _ticketDAO.mergeTickets(ticketsMerge.ticketPrincipalId, ticketsMerge.ticketsSecundariosId);
        }

        /*[HttpGet,Route("Familia/{id}")]
        public ApplicationResponse<List<Ticket>> obtenerFamiliaTicketCtrl(string id)
        {
            var respuesta = new ApplicationResponse<List<Ticket>>();
            try
            {
<<<<<<< HEAD
                //respuesta.Data =  _ticketDAO.mergeTickets(ticketsMerge.ticketPrincipal, ticketsMerge.tickets);
=======
>>>>>>> d526b598ac596331fb4246c13686f83d90789e4c
                respuesta.Data = _ticketDAO.obtenerFamiliaTickets(new Guid(id));
                respuesta.Message = "Proceso Exitoso";
                respuesta.StatusCode = HttpStatusCode.OK;
                respuesta.Exception = null;
            }
            catch (Exception ex)
            {
                respuesta.Data = null;
                respuesta.Message = ex.Message;
                respuesta.Success = false;
                //respuesta.Exception = ex.InnerException.ToString();
            }
            return respuesta;
        }

        [HttpPut, Route("Reenviar")]
        public ApplicationResponse<string> crearTicketHijoCtrl([FromBody] TicketPaternoDTO ticketPaterno)
        {
            var respuesta = new ApplicationResponse<string>();
            try
            {
                //respuesta.Data = _ticketDAO.crearTicketHijo(ticketPaterno.ticketPadre, ticketPaterno.ticketHijo);
                respuesta.Message = "Proceso Exitoso";
                respuesta.StatusCode = HttpStatusCode.OK;
                respuesta.Exception = null;
            }
            catch (Exception ex)
            {
                respuesta.Data = "No se pudo añadir la bitacora al ticket";
                respuesta.Message = ex.Message;
                respuesta.Success = false;
                //respuesta.Exception = ex.InnerException.ToString();
            }
            return respuesta;
        }*/

        //DEVOLVER FAMILIA DE TICKET DADO EL ID DE UN TICKET(ticket_id)
    }
}