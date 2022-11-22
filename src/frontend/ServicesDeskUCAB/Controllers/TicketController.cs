﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServicesDeskUCAB.Models;
using ServicesDeskUCAB.Servicios;
using ServicesDeskUCAB.ViewModel;

namespace ServicesDeskUCAB.Controllers
{
    public class TicketController : Controller
    {
        private readonly IServicioTicketAPI _servicioTicketAPI;
        private readonly IServicioPrioridadAPI _servicioPrioridadAPI;

        public TicketController(IServicioPrioridadAPI servicioPrioridadAPI)
        {
            //_servicioTicketAPI = servicioTicketAPI;
            _servicioPrioridadAPI = servicioPrioridadAPI;
        }

        public async Task<IActionResult> Index(string departamentoId,string opcion)
        {
            ViewBag.opcion = opcion;
            List<Ticket> lista = await _servicioTicketAPI.Lista(departamentoId,opcion);
            return View(lista);
        }

        public async Task<IActionResult> Ticket()
        {
            TicketNuevoViewModel ticketNuevoViewModel = new TicketNuevoViewModel
            {
                ticket = new Ticket(),
                prioridades = await _servicioPrioridadAPI.Lista(),
                departamentos = new List<Departamento>(),
                tipo_tickets = new List<Tipo_Ticket>()
            };
            return View(ticketNuevoViewModel);
        }
        public async Task<IActionResult> Merge(string departamentoId,string ticketId)
        {
            TicketMergeViewModel ticketMergeViewModel = new TicketMergeViewModel()
            {
                ticket = await _servicioTicketAPI.Obtener(ticketId),
                familiaTicket = new Familia_Ticket(),
                tickets = await _servicioTicketAPI.Lista(departamentoId, "Abiertos")
            };
            return View(ticketMergeViewModel);
        }

        public async Task<IActionResult> Details(string ticketId)
        {
            TicketDetailsViewModel ticketDetailsViewModel = new TicketDetailsViewModel()
            {
                ticket = await _servicioTicketAPI.Obtener(ticketId),
                familiaTicket = await _servicioTicketAPI.FamiliaTicket(ticketId),
                //bitacoraTicket = await _servicioTicketAPI.BitacoraTicket(ticketId),
                //estados = await _servicioEstadoAPI.Estados()
            };
            return View(ticketDetailsViewModel);
        }

        public async Task<IActionResult> Reenviar(string ticketId)
        {
            TicketReenviarViewModel ticketReenviarViewModel = new TicketReenviarViewModel()
            {
                ticket = await _servicioTicketAPI.Obtener(ticketId),
                ticketReenviado = new Ticket(),
                //departamentos = await _servicioDepartamentoAPI(),
                //prioridades = await _servicioPrioridadAPI(),
                //tipo_tickets = await _servicioTipoTicketAPI()
            };
            return View(ticketReenviarViewModel);
        }

        public IActionResult GuardarCambios()
        {
            return View();
        }
    }
}

