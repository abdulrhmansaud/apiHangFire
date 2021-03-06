using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System;
using Hangfire;
using Application.CQRS.Book.Commands;
using Application.CQRS.Book.Queries;

namespace apiHangFire.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController( IMediator mediator){
                
              _mediator = mediator;
        }

      [HttpGet]
       public async Task<ActionResult>  getallBooks(){
          
             var query = new GetAllBooksQuery();
             var result = await _mediator.Send(query);
            return Ok(result);
       }

        [HttpGet("{id}")]
       public async Task<ActionResult> getBooksById(int id){
         
          var query = new GetBooksByIdQuery(id);
          var result = await _mediator.Send(query);

          return result != null ? Ok(result) : NotFound();
       }

       [HttpPost]
       public async Task<ActionResult> CreateBook([FromBody] CreateBookCommands commnds){
            try
            {
                await _mediator.Send(commnds);
                return Ok("Book added Successfully");
            }
            catch (Exception ex)
            {
               return StatusCode(500,ex);
            }
       }
    }
}