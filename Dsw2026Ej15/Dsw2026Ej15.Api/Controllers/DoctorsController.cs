using Dsw2026Ej15.Api.Models;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using Dsw2026Ej15.Domain.Exceptions;

namespace Dsw2026Ej15.Api.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IPersistence _persistence;

        public DoctorsController(IPersistence persistence)
        {
            _persistence = persistence;
        }

        //POST - Insertar un nuevo medico
        [HttpPost]
        async public Task<IActionResult> NewDoctor([FromBody]DoctorModel.Request doctorModel)
            //La clase del 19/06/2026 el profe indico que se deben hacer asincronos los metodos de la persistencia, yo ya los tenia de esta forma, recalco por si surge el por que esta esto asi.
        {

            //Validacion de nombre, licencia y especialidad
            if (string.IsNullOrWhiteSpace(doctorModel.Name) || string.IsNullOrWhiteSpace(doctorModel.LicenseNumber))
            {
                throw new ValidationException("Name y LicenseNumber son requeridos."); //Fracaso = 400
            }
            
            var _speciality = await _persistence.GetByIdSpecialityAsync(doctorModel.IdSpeciality); //Obtengo la especialidad a partir del id que me llega en el request
            if (_speciality == null)
            {
                throw new ValidationException("Especialidad no existente."); //Fracaso = 400
            }

            //Logica de insercion de medico, creandose activo
            var newDoctor = new Doctor(doctorModel.Name, doctorModel.LicenseNumber, _speciality); //No pongo isActive, ya que por defecto sera true.
            await _persistence.AddDoctor(newDoctor);

            return Created(); //Exito = 201
        }

        //GET - Obtener todos los medicos activos
        [HttpGet]
        async public Task<IActionResult> GetDoctors()
        {
            var _doctorsList = await _persistence.GetByAllDoctorsAsync(); //Obtiene los doctores

            //throw new InvalidOperationException("Prueba de error 500");

            //Logica para obtener los doctores ACTIVOS
            var response = _doctorsList.Where(d => d.IsActive).Select(d => new DoctorModel.Response(
                    d.Id, 
                    d.Name, 
                    d.LicenseNumber, 
                    d.Speciality!.Name
            )); 

            return Ok(response); // Exito 200 incluso si no hay medicos activos, devuelva la lista.
        }

        //GET - Obtener un medico activo a partir de su id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var _doctor = await _persistence.GetByIdDoctorAsync(id);

            //El médico debe existir y estar activo
            if (_doctor == null || !_doctor.IsActive)
            {
                return NotFound("El medico no existe o no esta activo");
            }

            var response = new DoctorModel.Response(
                _doctor.Id,
                _doctor.Name,
                _doctor.LicenseNumber,
                _doctor.Speciality!.Name
            );

            return Ok(response);
        }

        //DELETE - establecer como inactivo al médico (borrado logico)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            var _doctor = await _persistence.GetByIdDoctorAsync(id);

            //El doctor debe existir y estar activo
            if (_doctor == null || !_doctor.IsActive)
            {
                return NotFound("El medico no existe o no esta activo"); //Fracaso = 404 Not Found si no se encuentra el médico o no está activo
            }

            //Logica de borrado logico del doctor. 
            await _persistence.DeleteDoctor(_doctor);

            return NoContent(); //Exito = 204 no content
        }

    }
}
