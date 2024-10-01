using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MDP.Common.Helpers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptionController : ControllerBase
    {
        // POST api/encryption/encrypt
        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return BadRequest("Input cannot be empty.");

            try
            {
                var encryptedText = KeyHelper.Encrypt(plainText);
                return Ok(new { EncryptedText = encryptedText });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/encryption/decrypt
        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return BadRequest("Input cannot be empty.");

            try
            {
                var decryptedText = KeyHelper.Decrypt(cipherText);
                return Ok(new { DecryptedText = decryptedText });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
