using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DungeonApi.Models
{
  public class Monster
  {
    public Monster()
    {      
      this.MainTypes = new HashSet<MonsterMainType>();
      this.Behaviors = new HashSet<MonsterBehavior>();
      this.Armors = new HashSet<MonsterArmor>();   
      this.Weapons = new HashSet<MonsterWeapon>();      
    }
    public int MonsterId { get; set; }
    [Required]
    public string MonsterName { get; set; }
    public virtual ICollection<MonsterMainType> MainTypes { get; set; }
    public virtual ICollection<MonsterBehavior> Behaviors { get; set; }
    public virtual ICollection<MonsterArmor> Armors { get; set; }
    public virtual ICollection<MonsterWeapon> Weapons { get; set; }
  }
}