using Code_FirstAssignment.DTO;
using Code_FirstAssignment.Models;

namespace Code_FirstAssignment.Mappings
{
    public static class MappingExtensions
    {
        public static HospitalDTO ToDTO(this Hospital hospital)
        {
            return new HospitalDTO
            {
               HospitalName=hospital.HospitalName,
               Location=hospital.Location
            };
        }
        public static Hospital ToEntity(this HospitalDTO hospitalDTO)
        {
            return new Hospital
            {
               HospitalName=hospitalDTO.HospitalName,
               Location=hospitalDTO.Location
            };
        }
        public static List<HospitalDTO> ToDTOList(this List<Hospital> hospitals)
        {
            return hospitals.Select(hospitals => hospitals.ToDTO()).ToList();
        }
    }
}
