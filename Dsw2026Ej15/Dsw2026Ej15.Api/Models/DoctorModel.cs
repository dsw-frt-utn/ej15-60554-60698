namespace Dsw2026Ej15.Api.Models
{
    public record DoctorModel
    {
        public record Request(string Name, string LicenseNumber, Guid IdSpeciality);
        public record Response(Guid Id, string Name, string LicenseNumber, string NameSpeciality);
    }
}
