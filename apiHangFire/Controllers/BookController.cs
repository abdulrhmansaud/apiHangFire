using Microsoft.AspNetCore.Mvc;
using apiHangFire.Model;
using apiHangFire.Data;
using System.Collections.Generic;
using AutoMapper;
using apiHangFire.Dtos;
using MediatR;
using apiHangFire.Queries;
using System.Threading.Tasks;
using apiHangFire.Commands;
using System;
using Hangfire;

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

            var result = await _mediator.Send(commnds);

            var jobId = BackgroundJob.Enqueue(() => CreateJobForAddBook());
            return Ok(jobId);
       }

        public void CreateJobForAddBook()
        {
            //Logic to Mail the user
            Console.WriteLine($"The Book Was  Created Succesfully");
        }

    }
}