using System;


namespace ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta
{
	public class EtiquetaDTO
	{
		public Guid Id { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		//public HashSet<TipoEstadoSearchDTO> tipoEstado { get; set; }
	}
}