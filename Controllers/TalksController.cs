﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreCodeCamp.Data;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CoreCodeCamp.Controllers
{
    [Route("api/camps/{moniker}/[controller]")]
    [ApiController]
    public class TalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICampRepository _repository;
        private readonly LinkGenerator _linkGenerator;

        public TalksController(ICampRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<TalkModel[]>> GetAll(string moniker)
        {
            try
            {
                var talks = await _repository.GetTalksByMonikerAsync(moniker);

                if(!talks.Any())
                {
                    return NotFound($"No talks found for {moniker}");
                }

                _mapper.Map<TalkModel[]>(talks);

                return Ok(talks);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{talkId:int}")]
        public async Task<ActionResult<TalkModel>> Get(string moniker, int talkId, bool includeSpeaker = false)
        {
            try
            {
                var talk = await _repository.GetTalkByMonikerAsync(moniker, talkId, includeSpeaker);

                if (talk == null)
                {
                    return NotFound($"No talk found for {moniker}");
                }

                _mapper.Map<TalkModel>(talk);

                return Ok(talk);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}