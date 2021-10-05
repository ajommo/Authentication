using System;

using Microsoft.AspNetCore.Mvc;

using Game.Authentication.Models;
using Game.Database;

namespace Game.Authentication.Controllers
{
    [Route("api")]
    [ApiController]
    public class CredentialsController
    {
        private readonly DatabaseContext database;

        public CredentialsController(DatabaseContext database)
        {
            this.database = database;
        }

        [HttpPost]
        [Route("credentials")]
        public ActionResult<Credentials> PostCredentials([FromBody] Credentials credentials)
        {
            var account = database.GetAccount(credentials.Username, credentials.Password);
            if (account == null)
            {
                return new UnauthorizedResult();
            }
            account.Token = Guid.NewGuid();
            database.SaveChanges();
            return new Credentials(account);
        }

        [HttpDelete]
        [Route("credentials")]
        public ActionResult<Credentials> DeleteCredentials([FromBody] Credentials credentials)
        {
            var account = database.GetAccount(credentials.Id, (Guid)credentials.Token);
            if (account == null)
            {
                return new UnauthorizedResult();
            }
            account.Token = null;
            database.SaveChanges();
            return new Credentials(account);
        }
    }
}
