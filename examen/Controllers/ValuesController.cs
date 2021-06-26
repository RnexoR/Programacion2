using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


		//Consultar Datos
		[HttpGet]
		public ActionResult Get()
		{
			using (Models.pruebaContext db = new Models.pruebaContext())
			{
				var lst = (from d in db.Personas select d).ToList();

				return Ok(lst);
			}
		}

		//Insertar Datos
		[HttpPost]
		public ActionResult Post([FromBody] Models.Request.personaRequest model)
		{
			using (Models.pruebaContext db = new Models.pruebaContext())
			{
				Models.Persona oPersona = new Models.Persona();
				oPersona.Nombre = model.Nombre;
				oPersona.Edad = model.Edad;
				db.Personas.Add(oPersona);
				db.SaveChanges();
			}
			return Ok();
		}

		//Editar Datos
		[HttpPut]
		public ActionResult Put([FromBody] Models.Request.personaRequest model)
		{
			using (Models.pruebaContext db = new Models.pruebaContext())
			{
				Models.Persona oPersona = db.Personas.Find(model.Id);
				oPersona.Nombre = model.Nombre;
				oPersona.Edad = model.Edad;
				db.Entry(oPersona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				db.SaveChanges();
			}
			return Ok();
		}

		//Eliminar Datos
		[HttpPut]
		public ActionResult Delete([FromBody] Models.Request.personaRequest model)
		{
			using (Models.pruebaContext db = new Models.pruebaContext())
			{
				Models.Persona oPersona = db.Personas.Find(model.Id);
				db.Personas.Remove(oPersona);
				db.SaveChanges();
			}
			return Ok();
		}


	}
}
