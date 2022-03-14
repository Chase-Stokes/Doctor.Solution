using System.Collections.Generic;

namespace DoctorOffice.Models
{
  public class Patient
  {
    public Patient()
    {
      this.JoinEntities = new HashSet<DocPatient>();
    }
    public int PatientId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public virtual ICollection<DocPatient> JoinEntities { get; }
  }
}