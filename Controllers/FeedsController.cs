﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trendlogg.Data;
using Trendlogg.Models;

namespace Trendlogg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedsController : ControllerBase
    {
        private readonly TrendLoggContext _context;

        public FeedsController(TrendLoggContext context)
        {
            _context = context;
        }

        // GET: api/Feeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feed>>> GetFeeds()
        {
            return await _context.Feeds.ToListAsync();
        }

        // GET: api/Feeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feed>> GetFeed(int id)
        {
            var feed = await _context.Feeds.FindAsync(id);

            if (feed == null)
            {
                return NotFound();
            }

            return feed;
        }

        // PUT: api/Feeds/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeed(int id, Feed feed)
        {
            if (id != feed.PointID)
            {
                return BadRequest();
            }

            _context.Entry(feed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Feeds
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Feed>> PostFeed(Feed feed)
        {
            _context.Feeds.Add(feed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeed", new { id = feed.PointID }, feed);
        }

        // DELETE: api/Feeds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Feed>> DeleteFeed(int id)
        {
            var feed = await _context.Feeds.FindAsync(id);
            if (feed == null)
            {
                return NotFound();
            }

            _context.Feeds.Remove(feed);
            await _context.SaveChangesAsync();

            return feed;
        }

        private bool FeedExists(int id)
        {
            return _context.Feeds.Any(e => e.PointID == id);
        }
    }
}