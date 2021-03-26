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
    
    public string FlavorName { get; set; }

    public string FlavorDescription { get; set; }
    
    public virtual ICollection<FlavorTreat> JoinEntities { get; }
  }
}