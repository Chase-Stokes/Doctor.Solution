using System.Collections.Generic;

namespace DoctorOffice.Models
{
  public class Doc
  {
    public Doc()
    {
      this.JoinEntities =new HashSet<DocPatient>();
    }
    public int DocId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<DocPatient> JoinEntities { get; set; }
  }
}