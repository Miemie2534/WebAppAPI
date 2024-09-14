using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppAngularAPI.Models;

namespace WebAppAngularAPI.Controllers
{
    [Route("Car/[controller]")]
    [ApiController]
    public class ViewCarController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        public ViewCarController(AppDBContext dbContext)
        {
            _dbContext=dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarList>>> GetAllCar()
        {
            var db = await _dbContext.CarList.ToListAsync();

            return Ok(db);
        }

        [HttpGet("id")]
        public async Task<ActionResult<List<CarList>>> GetCar(int id)
        {
            var db = await _dbContext.CarList.FindAsync(id);

            if (db == null)
            {
                return NotFound();
            }

            return Ok(await _dbContext.CarList.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<CarList>>> AddListCar(CarList carList)
        {
            _dbContext.CarList.Add(carList);
            await _dbContext.SaveChangesAsync();

            return Ok(carList);
        }

        [HttpDelete]
        public async Task<ActionResult<List<CarList>>> DeleteCar(int id)
        {
            var db = await _dbContext.CarList.FindAsync(id);

            if (db == null)
            {
                return NotFound();
            }

            _dbContext.CarList.Remove(db);
            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.CarList.ToListAsync());
        }

        [HttpPut("id")]
        public async Task<ActionResult<List<CarList>>> UpdateAllCar(int id)
        {
            var db = await _dbContext.CarList.FindAsync(id);

            if (db == null)
            {
                return NotFound();
            }

            db.Id = db.Id;
            db.Name = db.Name;
            db.Model = db.Model;
            db.color = db.color;
            db.Pirce = db.Pirce;

            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.CarList.ToListAsync());
        }
    }
}
