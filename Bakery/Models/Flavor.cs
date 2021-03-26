using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakery.Models
{
  public class Flavor
  {
    public Flavor()
    {
      JoinEntities = new HashSet<FlavorTreat>();
    }

    public int FlavorId { get; set; }

    public virtual ApplicationUser User { get; set; }
    
    [Required(ErrorMessage = "Please enter a flavor name")]
    [Display(Name="Flavor")]
    public string FlavorName { get; set; }

    [Required(ErrorMessage = "Please enter a flavor description")]
    [Display(Name="Description")]
    public string FlavorDescription { get; set; }
    
    public virtual ICollection<FlavorTreat> JoinEntities { get; }
  }
}