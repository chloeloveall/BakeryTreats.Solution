using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakery.Models
{
  public class Treat
  {
    public Treat()
    {
      JoinEntities = new HashSet<FlavorTreat>();
    }

    public int TreatId { get; set; }
    
    [Required(ErrorMessage = "Please enter a treat name")]
    [Display(Name="Treat")]
    public string TreatName { get; set; }

    public virtual ICollection<FlavorTreat> JoinEntities { get; }
  }
}