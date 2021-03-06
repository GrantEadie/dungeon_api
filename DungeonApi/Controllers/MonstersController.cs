using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DungeonApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DungeonApi.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class MonstersController : ControllerBase
  {
    private DungeonApiContext _db;

    public MonstersController(DungeonApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Monster>> Get(int Id)
    {
      var query = _db.Monsters.AsQueryable();

      if (Id != 0)
      {
        query = query.Where(entry => entry.MonsterId == Id);
      }
      
      return query.ToList();
    }

    [HttpPost]
    public void Post([FromBody] Monster monster, int MainTypeId)
    {
      _db.Monsters.Add(monster);
      if (MainTypeId != 0)
      {
        _db.MonsterMainTypes.Add(new MonsterMainType() { MainTypeId = MainTypeId, MonsterId = monster.MonsterId });
      }
      _db.SaveChanges();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Monster monster)
    {
      monster.MonsterId = id;
      _db.Entry(monster).State = EntityState.Modified;
      _db.SaveChanges();
    }
    
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var monsterToDelete = _db.Monsters.FirstOrDefault(entry => entry.MonsterId == id);
      _db.Monsters.Remove(monsterToDelete);
      _db.SaveChanges();
    }
  }
}



