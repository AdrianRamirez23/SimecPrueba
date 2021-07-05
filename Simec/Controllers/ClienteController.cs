using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simec.Context;
using Simec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DBSimecContext context;
        public ClienteController(DBSimecContext context)
        {
            this.context = context;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public List<Cliente> Get()
        {
            return context.Cliente.ToList();
        }

        // GET api/<ClienteController>/5
        [HttpGet("{IdCliente}")]
        public Cliente Get(string IdCliente)
        {
            var cliente = context.Cliente.FirstOrDefault(c => c.IdCliente == IdCliente);
            return cliente;
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Cliente.Add(cliente);
                    context.SaveChanges();
                    return Ok();
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{IdCliente}")]
        public ActionResult Put(string IdCliente, [FromBody] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (IdCliente == cliente.IdCliente)
                    {
                        var client = context.Cliente.FirstOrDefault(c => c.IdCliente == cliente.IdCliente);

                        if (cliente == null)
                        {
                            return NotFound();
                        }
                        else
                        {
                            context.Remove(client);
                            context.Cliente.Add(cliente);
                            context.SaveChanges();
                            return Ok();
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{IdCliente}")]
        public ActionResult Delete(string IdCliente)
        {
            var cliente = context.Cliente.FirstOrDefault(c => c.IdCliente == IdCliente);

            if (cliente == null)
            {
                return NotFound();
            }
            else
            {
                context.Cliente.Remove(cliente);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
