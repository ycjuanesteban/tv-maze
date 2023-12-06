using System.Net;

namespace TvMaze.Client.Http.Extensions
{
    public static class ValidateHttpResponseExtension
    {
        public static async Task ValidateStatusCodes(this HttpResponseMessage response, CancellationToken cancellationToken = default)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            switch ((int)response.StatusCode)
            {
                case (int)HttpStatusCode.BadRequest:
                    throw new HttpRequestException("Bad request", null, statusCode: HttpStatusCode.BadRequest);
                case (int)HttpStatusCode.NotFound:
                    throw new HttpRequestException("Not found", null, statusCode: HttpStatusCode.NotFound);
            }

            response.EnsureSuccessStatusCode();
        }
    }
}
