﻿using BusinessLayer.Interface;
using CommonLayer.DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooApplication.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        INoteBL noteBl;
        public NotesController(INoteBL noteBl)
        {
            this.noteBl = noteBl;
        }

        [HttpGet("GetAllNotes")]
        public IActionResult Get()
        {
            IEnumerable<Note> note = this.noteBl.GetAll();
            return Ok(note);
        }
        [HttpGet("GetNoteById/{id}")]
        public IActionResult GetNoteById(int id)
        {
            Note note = this.noteBl.GetNoteById(id);
            if (note == null)
            {
                return NotFound("The Note couldn't be found.");
            }
            return Ok(note);
        }

        [HttpPost("AddNotes")]
        public ActionResult AddNotes(Note note)
        {
            try
            {
                this.noteBl.AddNotes(note);
                return this.Ok(new { success = true, message = "Notes Added Successful " });
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        [HttpDelete("DeleteNote")]
        public IActionResult DeleteNote(Note note)
        {
            try
            {
                this.noteBl.DeleteNote(note.NoteID);
                return Ok(new { success = true, message = "Notes Deleted " });
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = "Note is null" });
            }
        }
    }
}


     

        