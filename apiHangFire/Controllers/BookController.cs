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
using apiHangFire.HangFire;

namespace apiHangFire.Controllers
{ 
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        HangFireJobs hangFireJobs = new HangFireJobs();
        public BookController( IMediator mediator){
                
              _mediator = mediator;
        }

      [HttpGet]
       public async Task<ActionResult>  getallBooks(){
          
             var query = new GetAllBooksQuery();
             var result = await _mediator.Send(query);

             BackgroundJob.Enqueue(() => hangFireJobs.CreateJobAllbooks());

            return Ok(result);
       }

        [HttpGet("{id}")]
       public async Task<ActionResult> getBooksById(int id){
         
          var query = new GetBooksByIdQuery(id);
          var result = await _mediator.Send(query);

            BackgroundJob.Enqueue(() => hangFireJobs.GetBooksById());

          return result != null ? Ok(result) : NotFound();
       }

       [HttpPost]
       public async Task<ActionResult> CreateBook([FromBody] CreateBookCommands commnds){

            var result = await _mediator.Send(commnds);
            var jobId = BackgroundJob.Enqueue(() => hangFireJobs.CreateJobForAddBook());

            return Ok(jobId);
       }
    }
}