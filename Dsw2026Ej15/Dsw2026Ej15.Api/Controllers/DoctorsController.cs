using Dsw2026Ej15.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dsw2026Ej15.Api.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : Controller
    {
        //POST - Insertar un nuevo medico
        [HttpPost]
        public IActionResult NewDoctor(string name, string licenseNumber, Speciality speciality)
        {
            //Realizar logica de insercion de medico
            //Requiere validaciones donde name y licensenumeber sean requeridos, y specialityid exista
            //El medico se debe crear activo
            //Exito = 201
            //Fracaso = 400 - indicando el motivo
            return Ok("Mensaje de exito");
        }

        //GET - Obtener todos los medicos activos
        [HttpGet]
        public IActionResult GetDoctors()
        {
            //Logica para obtener los doctores ACTIVOS
            //Exito = 200 incluso si no hay medicos activos, con que devuelva la lista.
            return Ok("Lista de doctores aqui");
        }

        //GET - Obtener un medico activo a partir de su id
        [HttpGet("/{id}")]
        public IActionResult GetDoctorById(Guid idBuscado)
        {
            //Logica para obtener al doctor
            return Ok("Doctor encontrado aqui");
        }

        //DELETE - establecer como inactivo al médico (borrado logico)
        [HttpDelete]
        public IActionResult DeleteDoctor(Guid idBuscado)
        {
            //Logica de borrado logico del doctor.
            //El doctor debe existir y estar activo
            //Exito = 204 no content
            //Fracaso = 404 Not Found si no se encuentra el médico o no está activo
            return Ok();
        }

    }
}
