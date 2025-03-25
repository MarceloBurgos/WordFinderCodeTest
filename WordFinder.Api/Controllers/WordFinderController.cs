using Microsoft.AspNetCore.Mvc;
using WordFinder.Api.Models;
using WordFinder.Domain;

namespace WordFinder.Api.Controllers;

[ApiController]
public class WordFinderController(ILogger<WordFinderController> logger) : ControllerBase
{
    [HttpPost("find-words")]
    public IActionResult FindWords(WordFinderFeed feed)
    {
        logger.LogInformation("Matrix {matrix}. Words to find {words}", feed.Matrix, feed.WordsToFind);
        var wordFinderProcessor = new WordFinderProcessor(feed.Matrix);
        return Ok(wordFinderProcessor.Find(feed.WordsToFind));
    }
}
