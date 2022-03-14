namespace DoctorOffice.Models
{
  public class DocPatient
  {
    public int DocPatientId { get; set; }
    public int PatientId { get; set; }
    public int DocId { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual Doc Doc { get; set; }
  }
}