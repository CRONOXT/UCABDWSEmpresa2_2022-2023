﻿using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Votos_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestVotos_Ticket
{

    [TestClass]
    public class TestVotar
    {
        Mock<IDataContext> context;
        private readonly Votos_TicketService VotoDAO;
        private readonly Mock<ITicketDAO> ticketDAO;
        private readonly IMapper mapper;
        private readonly Mock<INotificacion> notificacion;

        public TestVotar()
        {
            var myProfile = new List<Profile>
            {
                new TipoEstadoMapper(),
                new EtiquetaMapper(),
                new EtiquetaTipoEstadoMapper(),
                new Mappers()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myProfile));
            mapper = new Mapper(configuration);
            ticketDAO = new Mock<ITicketDAO>();
            context = new Mock<IDataContext>();
            notificacion = new Mock<INotificacion>();
            VotoDAO = new Votos_TicketService(context.Object, ticketDAO.Object,mapper, notificacion.Object);
            context.SetupDbContextData();
        }

        [TestMethod]
        public void CaminoFelizVotarJerarquico()
        {
            //arrange
            var Voto = new Votos_TicketDTOCreate()
            {
                IdTicket = "5992E4A2-4737-42FB-88E2-FBC37EF26751",
                IdUsuario = "C035D2FC-C0E2-4AE0-9568-4A3AC66BB81A",
                comentario = "Excelente",
                voto = "Aprobado"
            };
            //act
            var result = VotoDAO.Votar(Voto);
            //assert

            Assert.IsTrue(result.Success == true);
            Assert.AreEqual(result.Data.comentario, Voto.comentario);
            Assert.AreEqual(result.Data.voto, Voto.voto);

        }

        [TestMethod]
        public void CaminoFelizVotarParalelo()
        {
            //arrange
            var Voto = new Votos_TicketDTOCreate()
            {
                IdTicket = "132A191C-95AE-4538-8E78-C5EDD3092552",
                IdUsuario = "C035D2FC-C0E2-4AE0-9568-4A3AC66BB81A",
                comentario = "Muy Mal",
                voto = "Rechazado"

            };
            //act
            var result = VotoDAO.Votar(Voto);

            //assert
            Assert.IsTrue(result.Success == true);
            Assert.AreEqual(result.Data.comentario, Voto.comentario);
            Assert.AreEqual(result.Data.voto, Voto.voto);

        }

        [TestMethod]
        public void EntrarExceptionsControl()
        {
            //arrange
            var Voto = new Votos_TicketDTOCreate()
            {
                IdTicket = "5992E4A2-4737-42FB-88E2-FBC37EF26751",
                IdUsuario = "C035D2FC-C0E2-4AE0-9568-4A3AC66BB81A",
                comentario = "Excelente",
                voto = "Aprobadojyh"

            };
            //act
            var result = VotoDAO.Votar(Voto);
            //assert

            Assert.IsTrue(result.Success == false);
            Assert.IsTrue(result.Data == null);
        }

        

    }
}